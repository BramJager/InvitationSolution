namespace InvitationConsoleApp.Models
{
    internal class Person
    {
        /*NEVER MAKE A PUBLIC FIELD THING
        //Fully implemented property procedure
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }*/

        //Auto implemented property procedure
        public ContactMethod Contact { get; set; }
        public Sex Sex { get; set; }
        public string PostalAdress { get; set; }
        public string TelephoneNumber { get; set; }
        public string Salutation { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string SurnamePrefix { get; set; }
        public string FullName { get; set; }
        public Person(string firstname, string surnameprefix, string surname, Sex sex)
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

            if (sex == 0)
            {
                this.Salutation = "Mr.";
            }
            else
            {
                this.Salutation = sex == (Sex)1 ? "Ms." : "Mx.";
            }

        }
        public Person(string firstname, string surname):this(firstname, string.Empty, surname, Sex.Unknown)
        {

        }
        public Person():this(string.Empty, string.Empty)
        {

        }
    }
}