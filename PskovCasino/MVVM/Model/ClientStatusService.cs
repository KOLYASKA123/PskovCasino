using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace PskovCasino.MVVM.Model
{
    [Keyless]
    public class ClientStatusService
    {
        public int ServiceID { get; set; }
        public Service Service { get; set; }

        public int ClientStatusID { get; set; }
        public ClientStatus ClientStatus { get; set; }
    }
}
