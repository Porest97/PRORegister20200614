using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRORegister.SportsContacts.Models
{
    public class SportsContact
    {
        public int Id { get; set; }

        public string Club { get; set; }

        public string Team { get; set; }

        public string Role { get; set; }

        public string Sport { get; set; }

        public string District { get; set; }

        public string FirstName { get; set; }

        public string LatsName { get; set; }

        public string PhoneNumber1 { get; set; }

        public string PhoneNumber2 { get; set; }

        public string Email { get; set; }

        public string SSN { get; set; }

        public string Season { get; set; }

        public string AgeCategory { get; set; }
    }
}
