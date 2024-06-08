using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

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
