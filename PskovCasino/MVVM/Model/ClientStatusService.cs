using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

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
