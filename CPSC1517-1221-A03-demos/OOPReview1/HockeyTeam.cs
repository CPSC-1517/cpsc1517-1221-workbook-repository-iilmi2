using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOPReview1
{
    public class NHL_Team
    {
        
        private string name;
        private NHLConference conference;
        private NHLDivision division;
        private string city;
        private int gamesPlayed;
        private int wins;
        private int losses;
        private int overtimeLosses;
        private int points;

        public string Name
        {
            get { return name; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Cannot contain nothing.");
                }
                name = value.Trim(); 
            }
        }
        public NHLConference Conference
        {
            get; private set; 
        }
        public NHLDivision Division
        {
            get; private set;
        }
        public string City
        {
            get { return city; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Cannot contain nothing.");
                }
                city = value.Trim();
            }

        }
        public int GamesPlayed
        {
            get { return gamesPlayed; }
            set 
            {
                if(value >= 1)
                {
                    gamesPlayed = value;
                }
                else
                {
                    throw new Exception("Value is invalid");
                }
                
            }
        }
        public int Wins
        {
            get { return wins; }
            set 
            {   if(value >= 0)
                {
                   wins = value; 
                }
                else
                {
                    throw new Exception("Value is invalid");
                }

            }
        }
        public int Losses
        {
            get { return losses; }
            set
            {
                if (value >= 0)
                {
                    losses = value;
                }
                else
                {
                    throw new Exception("Value is invalid");
                }

            }
        }
        public int OvertimeLossses
        {
            get { return overtimeLosses; }
            set
            {
                if (value >= 0)
                {
                    overtimeLosses = value;
                }
                else
                {
                    throw new Exception("Value is invalid");
                }

            }
        }
        public int Points
        {
            get
            {
                return (Wins * 2) + OvertimeLossses;
            }
        }
        public NHL_Team(NHLConference conf,NHLDivision div, string n,string c)
        {
            Conference = conf;
            Division = div;
            Name = n;
            City = c;
        }
        public override string ToString()
        {
            return $"{Conference},{Division},{Name},{City},{GamesPlayed},{Wins},{Losses},{OvertimeLossses}";
        }

    }
}
