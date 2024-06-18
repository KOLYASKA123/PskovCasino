using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PskovCasino.MVVM.Model;


namespace PskovCasino
{
    public class DatabaseFixture : IDisposable
    {
        public DbContextOptions<CasinoContext> Options { get; private set; }

        public CasinoContext Context { get; private set; }


        public DatabaseFixture()
        {
            Options = new DbContextOptionsBuilder<CasinoContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

            var context = new CasinoContext(Options);
 
            Context = context;
            Context.Database.EnsureCreated();
            SeedDatabase(Context);
        }

        private void SeedDatabase(CasinoContext context)
        {
            context.ClientStatuses.Add(new ClientStatus { Name = "Посетитель" });
            context.ClientStatuses.Add(new ClientStatus { Name = "Член клуба" });
            context.ClientStatuses.Add(new ClientStatus { Name = "VIP" });
            context.ClientStatuses.Add(new ClientStatus { Name = "Sport" });
            context.SaveChanges();

            var client = new Client
            {
                Username = "user",
                Password = BCrypt.Net.BCrypt.HashPassword("password"),
                Balance = 0,
                ClientStatusID = 1
            };

            context.Clients.Add(client);
            context.SaveChanges();

            var statuses = context.ClientStatuses.ToList();
        }

        public void Dispose()
        {

        }
    }
}
