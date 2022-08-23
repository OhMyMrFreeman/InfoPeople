using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoPeople.Data
{
    class People
    {
        private string dateFormat = "yyyy-MM-dd";
        public People(string firstName, string lastName, DateTime birthday)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
        }
        public string FirstName { get; private set; } 

        public string LastName { get; private set; }

        public int Age { get; private set; }


        private DateTime birthday;
        public DateTime Birthday
        { get { return birthday; }

            private set
            {
                birthday = value;
                Age = DateTime.Now.Year - Convert.ToDateTime(birthday).Year;
            }
        }


    }
}
