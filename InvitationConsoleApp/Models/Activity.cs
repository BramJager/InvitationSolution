using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvitationConsoleApp.Models
{
    class Activity
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public Activity(string name)
        {
            this.Name = name;
        }
        public Activity():this("Activiteit")
        {

        }
    }
}
