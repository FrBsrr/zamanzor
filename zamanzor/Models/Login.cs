﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zamanzor.Models
{
    public class Login
    {

        public string username { get; set; }
        public string password { get; set; }
        
        public Login(string username, string password)
        {
            this.username = username;
            this.password = password;
           
        }
    }
}
