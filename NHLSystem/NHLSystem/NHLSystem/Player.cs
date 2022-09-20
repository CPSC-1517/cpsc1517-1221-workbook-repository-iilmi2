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
        public Player(string fullName, Position pos, int primNo, int goals, int assists) : base(fullName)
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
    }
}
