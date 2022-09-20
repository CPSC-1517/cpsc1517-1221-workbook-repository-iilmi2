using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHLSystem
{
    public class Coach : Person
    {
        public DateTime StartDate { get; set; }

        public Coach(string fullName, DateTime start) : base(fullName)
        {
            StartDate = start;
        }

        public override string ToString()
        {
            return $"{FullName},{StartDate}";
        }
    }
}
