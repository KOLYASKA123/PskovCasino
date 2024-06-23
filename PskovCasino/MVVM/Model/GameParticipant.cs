using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace PskovCasino.MVVM.Model
{
    public class GameParticipant
    {
        public int ID { get; set; }
        public int ClientID { get; set; }
        public Client Client { get; set; }

        public int GameSessionID { get; set; }
        public GameSession GameSession { get; set; }

        public decimal InitialPayment { get; set; }

        public decimal WinPayment { get; set; }
    }
}
