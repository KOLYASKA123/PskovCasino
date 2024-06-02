using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PskovCasino.MVVM.Model
{
    public class Tournament
    {
        public int ID { get; set; }

        [ForeignKey("GameSession")]
        public int GameSessionID { get; set; }

        public decimal MainPrize { get; set; }
    }
}
