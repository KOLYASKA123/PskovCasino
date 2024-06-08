﻿using System.ComponentModel.DataAnnotations.Schema;

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