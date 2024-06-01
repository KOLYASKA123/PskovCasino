using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PskovCasino.MVVM.Model
{
    [Keyless]
    public class ClientStatusServices
    {
        public Services ServiceID { get; set; }
        public ClientStatus ClientStatusID { get; set; }
    }
}
