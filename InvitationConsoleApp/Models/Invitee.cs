using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvitationConsoleApp.Models
{
    class Invitee : Person
    {
        public Invitee(string firstname, string surnameprefix, string surname, Sex sex) 
        {
            this.Surname = surname;
            this.FirstName = firstname;
            this.SurnamePrefix = surnameprefix;

            if (this.SurnamePrefix == string.Empty)
            {
                this.FullName = $"{this.Surname}, {this.FirstName}";
            }
            else
            {
                this.FullName = $"{this.Surname}, {this.FirstName} {this.SurnamePrefix}";
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
        public Invitee(string firstname, string surname) : this(firstname, string.Empty, surname, Sex.Unknown)
        {
        }
        public Invitee() : this(string.Empty, string.Empty)
        {

        }
    }
}

