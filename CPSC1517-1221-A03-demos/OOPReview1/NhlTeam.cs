using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPReview1
{
    public class NhlTeam
    {
        // Define an auto-implemented property with a private set
        // for the Conference of type NhlConference 
        public NhlConferene Conference { get; private set; }

        // Define an auto-implemented property with a private set
        // for the Division of type NhlDivision
        public NhlDivision Division { get; private set; }

        // Define a fully-implemented property for the Name of type string.
        // Validate that the new name is not null or an empty string or 
        // contains just whitespaces.
        // Trim all leading and trailing whitespaces
        private string _name;   // field for the Name property
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name must contain text.");
                }
                _name = value.Trim();
            }
        }

        private string _city;
        public string City
        {
            get => _city;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("City must contain text.");
                }
                _city = value.Trim();
            }
        }

        private int _gamesPlayed;
        public int GamesPlayed
        {
            get => _gamesPlayed;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("GamesPlayed must >= 0");
                }
                _gamesPlayed = value;
            }
        }

        private int _wins;
        public int Wins 
        { 
            get => _wins; 
            set 
            { 
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Wins must be >= 0");
                }
                _wins = value;
            } 
        }

        private int _losses;
        public int Losses
        {
            get => _losses;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Losses must be >= 0");
                }
                _losses = value;
            }
        }

        private int _overtimeLosses;
        public int OvertimeLosses
        {
            get => _overtimeLosses;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("OvertimeLosses must be >= 0");
                }
                _overtimeLosses = value;
            }
        }

        public int Points   // Computed property
        {
            get => (Wins * 2) + OvertimeLosses;            
        }

        // Define an auto-implemented property with a private set for players
        public List<Roster> Players { get; private set; }

        private const int MaxPlayers = 23;
        public void AddPlayer(Roster currentPlayer)
        {
            if (Players.Count >= MaxPlayers)
            {
                throw new ArgumentException("Roster is full. Remove a player first.");
            }
            Players.Add(currentPlayer);
        }
        public void RemovePlayer(int playerNo)
        {
            // Remove from the Players list the player with the matching playerNo.
            // Throw an ArgumentException if the playerNo does not exists
            bool foundPlayer = false;
            int playerIndex = -1;
            for (int index = 0; index < Players.Count; index++)
            {
                //Roster currentPlayer = Players[index];
                //if (currentPlayer.No == playerNo)
                if (Players[index].No == playerNo)
                {
                    foundPlayer = true;
                    playerIndex = index;
                    index = Players.Count;  // stop loop
                }
            }
            //if (foundPlayer == false) 
            if (!foundPlayer)
            {
                throw new ArgumentException($"Player ${playerNo} is not on the team.");
            }
            Players.RemoveAt(playerIndex);
        }

        public NhlTeam(
            NhlConferene conferene,
            NhlDivision division,
            string name,
            string city,
            List<Roster> players)
        {
            // Create a new list of Roster if non is provided
            if (players == null)
            {
                players = new List<Roster>();
            }
            else
            {
                Players = players;
            }
            Conference = conferene;
            Division = division;
            Name = name;
            City = city;
        }
        public NhlTeam(
            NhlConferene conferene, 
            NhlDivision division,
            string name, 
            string city)
        {
            Players = new List<Roster>();

            Conference = conferene;
            Division = division;
            Name = name;
            this.City = city;
            
            GamesPlayed = 0;
            Wins = 0;
            Losses = 0;
            OvertimeLosses = 0;
        }

        public override string ToString()
        {
            //return base.ToString();
            return $"{Conference},{Division},{Name},{City},{GamesPlayed},{Wins},{Losses},{OvertimeLosses}";
        }
    }
}