using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace PskovCasino.MVVM.Model
{
    [Keyless]
    public class GameParticipant
    {
        public int ClientID { get; set; }
        public Client Client { get; set; }

        public int GameSessionID { get; set; }
        public GameSession GameSession { get; set; }

        public decimal InitialPayment { get; set; }

        public decimal WinPayment { get; set; }
    }
}
