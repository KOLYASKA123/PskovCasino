using System.ComponentModel.DataAnnotations.Schema;

namespace PskovCasino.MVVM.Model
{
    public class GameSession
    {
        public int ID { get; set; }

        [ForeignKey("GameType")]
        public int GameTypeID { get; set; }

        public int MimimalParticipantsCountToStart { get; set; }
    }
}
