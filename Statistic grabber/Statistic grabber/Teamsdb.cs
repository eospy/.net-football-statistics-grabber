using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistic_grabber
{
    /// <summary>
    /// storing teams stats in database
    /// </summary>
    public class Teamsdb
    {
        public Teamsdb(int leagueid,string name,int teamid)
        {
            Leagueid = leagueid;
            Name = name;
            TeamId = teamid;
        }
        public Teamsdb() { }
        public int Id { get; set; }
        public int Leagueid { get; set; }
        public string Name { get; set; }
        public int TeamId { get; set; }
    }
}
