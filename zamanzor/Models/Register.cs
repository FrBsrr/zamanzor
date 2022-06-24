using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zamanzor.Models
{
    public class Register
    {


        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string telno { get; set; }

        public Register(string username, string password, string name, string surname, string telno)
        {
            this.username = username;
            this.password = password;
            this.name = name;
            this.surname = surname;
            this.telno = telno;
        }
    }
}
