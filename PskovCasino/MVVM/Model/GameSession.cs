using System.ComponentModel.DataAnnotations.Schema;

namespace PskovCasino.MVVM.Model
{
    public class GameSession
    {
        public int ID { get; set; }

        public int GameTypeID { get; set; }
        public GameType GameType { get; set; }

        public int MimimalParticipantsCountToStart { get; set; }
    }
}
