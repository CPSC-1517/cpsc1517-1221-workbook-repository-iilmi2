using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPReview1
{
    public class HockeyTeam
    {
        public enum Conferences
        {
            West,
            East
        }
        public enum Divisions
        {
            Metro,
            Atlantic,
            Central,
            Pacific
        }
        private string name;
        private Conferences _conference;
        private Divisions _division;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Conferences Conference
        {
            get { return _conference; }
        }
        public Divisions Division
        {
            get { return _division; }
        }
    }
}
