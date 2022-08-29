using System;
using System.ComponentModel;

namespace InfoPeople.Data
{
    class Human
    {
        readonly string dateFormat = "dd-MM-yyyy";
        public Human(string firstName, string lastName, string middleName, string birthday)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            Birthday = birthday;
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public int Age { get; set; }


        private DateTime? birthday;

        public string Birthday
        {
            get { return $"{birthday?.ToString(dateFormat)}"; }

            set
            {
                if(value != null && DateTime.TryParse(value.Replace(':', '-'), out var rezult))
                {
                    birthday = rezult;
                    Age = DateTime.Now.Year - Convert.ToDateTime(birthday).Year;
                    if(DateTime.Today.Month < birthday.Value.Month)
                    {
                        Age--;
                    }
                    else if(DateTime.Today.Month == birthday.Value.Month)
                    {
                        if(DateTime.Today.Day < birthday.Value.Day)
                        {
                            Age--;
                        }
                    }
                }
                else
                {
                    Age = -1;
                }
            }
        }
    }
}
