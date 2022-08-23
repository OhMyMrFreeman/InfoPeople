using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoPeople.Data
{
    class Human
    {
        private string dateFormat = "dd-MM-yyyy";
        public Human(string firstName, string lastName, string birthday)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
        }
        public string FirstName { get; private set; } 

        public string LastName { get; private set; }

        public int Age { get; private set; }


        private DateTime? birthday;
        public string Birthday
        {
            get { return birthday?.ToString(dateFormat); }

            private set
            {
                birthday = DateTime.Parse(value.Replace(':','-'));
                Age = DateTime.Now.Year - Convert.ToDateTime(birthday).Year;
            }
        }

    }
}
