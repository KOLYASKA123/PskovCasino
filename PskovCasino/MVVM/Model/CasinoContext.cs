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

        public DbSet<Clients> Clients { get; set; }
        public DbSet<ClientStatus> ClientStatus { get; set; }
        public DbSet<ClientStatusServices> ClientStatusServices { get; set; }
        public DbSet<GameParticipants> GameParticipants { get; set; }
        public DbSet<GameSessions> GameSessions { get; set; }
        public DbSet<GameTypes> GameTypes { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<Tournaments> Tournaments { get; set; }
    }
}
