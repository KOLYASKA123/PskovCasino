using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PskovCasino.MVVM.Model
{
    public class GameParticipants
    {
        public Clients ClientID { get; set; }
        public GameSessions GameSessionID { get; set; }
        public decimal InitialPayment { get; set; }
        public decimal WinPayment { get; set; }
    }
}
