using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.ObjectModel;
using PskovCasino.MVVM.ViewModel;

namespace PskovCasino.MVVM.Model
{
    public class GameSession
    {
        public int ID { get; set; }

        public int GameTypeID { get; set; }
        public GameType GameType { get; set; }

        public int MimimalParticipantsCountToStart { get; set; }

        [NotMapped]
        public ObservableCollection<GameParticipant> GameParticipants { get; set; }
    }
}
