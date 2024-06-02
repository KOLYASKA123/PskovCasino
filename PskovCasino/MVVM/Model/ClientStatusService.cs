using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PskovCasino.MVVM.Model
{
    [Keyless]
    public class ClientStatusService
    {
        [ForeignKey("Service")]
        public int ServiceID { get; set; }

        [ForeignKey("ClientStatus")]
        public int ClientStatusID { get; set; }
    }
}
