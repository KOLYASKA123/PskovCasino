using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PskovCasino.MVVM.Model
{
    public class ClientStatus
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public ICollection<Client> Clients { get; set; }
    }
}
