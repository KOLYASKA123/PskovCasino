using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PskovCasino.MVVM.Model
{
    public class CasinoContext : DbContext
    {
        public CasinoContext(DbContextOptions<CasinoContext> options) : base(options) 
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientStatus> ClientStatuses { get; set; }
        public DbSet<ClientStatusService> ClientStatusServices { get; set; }
        public DbSet<GameParticipant> GameParticipants { get; set; }
        public DbSet<GameSession> GameSessions { get; set; }
        public DbSet<GameType> GameTypes { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
    }
}
