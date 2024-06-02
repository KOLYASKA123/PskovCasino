using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
