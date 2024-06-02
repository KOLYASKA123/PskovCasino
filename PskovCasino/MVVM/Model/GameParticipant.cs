using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PskovCasino.MVVM.Model
{
    [Keyless]
    public class GameParticipant
    {
        [ForeignKey("Client")]
        public int ClientID { get; set; }

        [ForeignKey("GameSession")]
        public int GameSessionID { get; set; }

        public decimal InitialPayment { get; set; }

        public decimal WinPayment { get; set; }
    }
}
