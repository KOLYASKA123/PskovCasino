using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PskovCasino.MVVM.Model
{
    public class Client
    {
        public int ID { get; set; }
        
        public string Username { get; set; }
        
        public string Password { get; set; }
        
        [ForeignKey("ClientStatus")]
        public int ClientStatusID { get; set; }
        
        public decimal Balance { get; set; }

        public ClientStatus ClientStatus { get; set; }
    }
}
