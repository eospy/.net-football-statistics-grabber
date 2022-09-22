using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistic_grabber
{
    /// <summary>
    /// supporting class for connecting couple of request results
    /// </summary>
    public class Updateclass
    {
        public Updateclass(int team1id, int team2id, string referee, int? goals1, int? goals2)
        {
            Team1id = team1id;
            Team2id = team2id;
            Referee = referee;
            Goals1 = goals1;
            Goals2 = goals2;
        }

        public int Team1id { get; set; }
        public int Team2id { get; set; }
        public string Referee { get; set; }
        public int? Goals1 { get; set; }
        public int? Goals2 { get; set; }
    }
}
