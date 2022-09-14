using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPReview1
{
    public class Roster
    {
        private const int MinNo = 0;
        private const int MaxNo = 98;
        // Define a fully-implemented property for player number
        private int _no;
        public int No
        {
            get => _no;
            set 
            { 
                if (value < MinNo || value > MaxNo)
                {
                    throw new ArgumentOutOfRangeException($"Player number must be between {MinNo} and {MaxNo}");
                }
                _no = value;
            }
        }

        // Define a fully-implemented property player name
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name must contain text");
                }
                _name = value.Trim();
            }
        }

        // Define a auto-implemented property for Position
        public Position Position { get; set; }

        // Define a greedy constructor with parameters for no, name, and position
        public Roster(int no, string name, Position position)
        {
            No = no;
            Name = name;
            Position = position;
        }

        // override the ToString to return the No,Name,Position
        public override string ToString()
        {
            //return base.ToString();
            return $"{No},{Name},{Position}";
        }

    }
}
