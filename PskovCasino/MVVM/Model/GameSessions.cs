using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PskovCasino.MVVM.Model
{
    public class GameSessions
    {
        public int ID { get; set; }
        public GameTypes GameTypeID { get; set; }
        public int MimimalParticipantsCountToStart { get; set; }
    }
}
