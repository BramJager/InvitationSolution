using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvitationConsoleApp.Models
{
    class Organizer: Person
    {
        public Organizer(string firstname, string surnameprefix, string surname, Sex sex)
        {
            this.Surname = surname;
            this.FirstName = firstname;
            this.SurnamePrefix = surnameprefix;

            if (this.SurnamePrefix == string.Empty)
            {
                this.FullName = $"{this.FirstName} {this.Surname}";
            }
            else
            {
                this.FullName = $"{this.FirstName} {this.SurnamePrefix} {this.Surname}";
            }
            this.Sex = sex;

            if (sex == (Sex)0)
            {
                this.Salutation = "Mr.";
            }
            else
            {
                this.Salutation = sex == (Sex)1 ? "Ms." : "Mx.";
            }
        }
        public Organizer(string firstname, string surname) : this(firstname, string.Empty, surname, Sex.Unknown)
        {
        }
        public Organizer() : this(string.Empty, string.Empty)
        {

        }
    }
}

