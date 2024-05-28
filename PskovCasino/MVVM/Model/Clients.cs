using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PskovCasino.MVVM.Model
{
    public class Clients
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public ClientStatus ClientStatusID { get; set; }
        public SqlMoney Balance { get; set; }
    }
}
