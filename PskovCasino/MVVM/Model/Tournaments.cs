using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PskovCasino.MVVM.Model
{
    public class Tournaments
    {
        public int ID { get; set; }
        public GameSessions GameSessionID { get; set; }
        public decimal MainPrize { get; set; }
    }
}
