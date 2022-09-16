using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHLSystem
{
    public class Person
    {
        //Define a fully-implemented property for FullName with a private set
        private string fullName = string.Empty ;
        public string FullName
        {
            get { return fullName; }
            //Validate new values is not null or empty string whitespaces only
            
            //Validate new values contains at minimum 3 or more characters
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Full name value is required");
                }
                if(value.Trim().Length < 3)
                {
                    throw new ArgumentException("Name needs to be more than 3 characters.");
                }
                    fullName = value; 
            }
        }
        public Person(string name)
        {
            FullName = name;
        }
    }
}
