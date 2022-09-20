using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHLSystem
{
    public class Team
    {
        private string teamName = String.Empty;
        public Coach Coach { get; private set; } = null!;

        public List<Player> Players { get; } = new List<Player>();

        public void AddPlayer(Player newPlayer)
        {
            if(newPlayer == null)
            {
                throw new ArgumentNullException("Player is required.");
            }
            if(Players.Count >= 3)
            {
                throw new ArgumentException("Team cannot have more than 23 players.");
            }
            bool primaryNumFound = false;
            foreach(Player searchPlayer in Players)
            {
                if(searchPlayer.PrimaryNo == newPlayer.PrimaryNo)
                {
                    primaryNumFound = true;
                    break;
                }
            }
            if (primaryNumFound)
            {
                throw new ArgumentException("Primary No is already in use.");
            }
            Players.Add(newPlayer);
        }

        public string TeamName
        {
            get { return teamName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("TeamName is required");
                }
                teamName = value;
            }
        }
        public int TotalPlayerPoints
        {
            get
            {
                int totalPoints = 0;
                foreach(Player player in Players)
                {
                    totalPoints += player.Points;
                }
                return totalPoints;
            }
        }
        public Team(string teamName, Coach coach)
        {
            if (coach == null)
            {
                throw new ArgumentNullException("Coach is required.");
            }
            TeamName = teamName;
            Coach = coach;
            
        }
        public override string ToString()
        {
            return $"{TeamName}, {Coach}";
        }
    }
}
