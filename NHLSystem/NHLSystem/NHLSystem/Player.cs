using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHLSystem
{
    public class Player : Person
    {
        public Position Position { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }

        private int primaryNo;

        public int PrimaryNo
        {
            get { return primaryNo; }
            set
            {
                if(value < 0 || value > 98)
                {
                    throw new ArgumentOutOfRangeException("PrimaryNo must be between 0 and 98.");
                }
                primaryNo = value;
            }
        }
        public int Points
        {
            get { return Goals + Assists; }
        }
        public Player(string fullName, int primNo, Position pos, int goals, int assists) : base(fullName)
        {
            Position = pos;
            Goals = goals;
            Assists = assists;
            PrimaryNo = primNo;
        }
        public Player(string fullName, Position pos, int primNo) : base(fullName)
        {
            Position = pos;
            PrimaryNo = primNo;
            Goals=0;
            Assists=0;
        }
        public override string ToString()
        {
            return $"{FullName}, {PrimaryNo}, {Position}, {Goals}, {Assists}, {Points}";
        }

        public static Player ParseCsv(string line)
        {
            const char Delimiter = ',';
            string[] tokens = line.Split(Delimiter);
            if(tokens.Length != 6)
            {
                throw new FormatException($"CSV line must contain exactly 6 values. {line}");
            }
            string playerName = tokens[0];
            int playerNumber = int.Parse(tokens[1]);
            Position position = (Position) Enum.Parse(typeof(Position), tokens[2]);
            int goals = int.Parse(tokens[3]);
            int assists = int.Parse(tokens[4]);
            return new Player(playerName, playerNumber, position, goals, assists);

        }
    }
}
