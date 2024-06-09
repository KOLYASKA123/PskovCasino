using System.ComponentModel.DataAnnotations.Schema;

namespace PskovCasino.MVVM.Model
{
    public class Tournament
    {
        public int ID { get; set; }

        public int GameSessionID { get; set; }
        public GameSession GameSession { get; set; }

        public decimal MainPrize { get; set; }
    }
}
