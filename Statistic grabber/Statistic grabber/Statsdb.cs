using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistic_grabber
{
    /// <summary>
    /// storing fixture stats in database
    /// </summary>
    public class Statsdb
    {
        public Statsdb(string team1name, int team1id, string formation1, int shotsongoal1, int totalshots1, int shotsinside1, int shotsoutside1, int fouls1, int corners1, int offsides1, int possession1, int yellowcards1, int redcards1, int saves1, int totalasses1, int passespercent1, string team2name, int team2id, string formation2, int shotsongoal2, int totalshots2, int shotsinside2, int shotsoutside2, int fouls2, int corners2, int offsides2, int possession2, int yellowcards2, int redcards2, int saves2, int totalasses2, int passespercent2)
        {
            Team1name = team1name;
            Team1id = team1id;
            Formation1 = formation1;
            Shotsongoal1 = shotsongoal1;
            Totalshots1 = totalshots1;
            Shotsinside1 = shotsinside1;
            Shotsoutside1 = shotsoutside1;
            Fouls1 = fouls1;
            Corners1 = corners1;
            Offsides1 = offsides1;
            Possession1 = possession1;
            Yellowcards1 = yellowcards1;
            Redcards1 = redcards1;
            Saves1 = saves1;
            Totalasses1 = totalasses1;
            Passespercent1 = passespercent1;
            Team2name = team2name;
            Team2id = team2id;
            Formation2 = formation2;
            Shotsongoal2 = shotsongoal2;
            Totalshots2 = totalshots2;
            Shotsinside2 = shotsinside2;
            Shotsoutside2 = shotsoutside2;
            Fouls2 = fouls2;
            Corners2 = corners2;
            Offsides2 = offsides2;
            Possession2 = possession2;
            Yellowcards2 = yellowcards2;
            Redcards2 = redcards2;
            Saves2 = saves2;
            Totalasses2 = totalasses2;
            Passespercent2 = passespercent2;
        }
        public Statsdb(int hometeamid,int awayteamid,string referee)
        {
           Team1id = hometeamid;
           Team2id = awayteamid;
           Referee=referee;
        }
        public Statsdb() { }
        public static Statsdb[] GetStatsdb()
        {
            Statsdb[] statsmassive;
            using (StatsContext db = new StatsContext())
            {
                var fixtures = db.Statsdbs;
                statsmassive=fixtures.ToArray();
            }
            return statsmassive;
        }

        public int Id { get; set; }
        
        public string Referee { get; set; }
        public int? Goals1 { get; set; }
        public int? Goals2 { get; set; }
        public string Team1name { get; set; }
        public int Team1id { get; set; }
        public string Formation1 { get; set; }
        public int? Shotsongoal1 { get; set; }
        public int? Totalshots1 { get; set; }
        public int? Shotsinside1 { get; set; }
        public int? Shotsoutside1 { get; set; }
        public int? Fouls1 { get; set; }
        public int? Corners1 { get; set; }
        public int? Offsides1 { get; set; }
        public int? Possession1 { get; set; }
        public int? Yellowcards1 { get; set; }
        public int? Redcards1 { get; set; }
        public int? Saves1 { get; set; }
        public int? Totalasses1 { get; set; }
        public int? Passespercent1 { get; set; }


        public string Team2name { get; set; }
        public int Team2id { get; set; }

        public string Formation2 { get; set; }
        public int? Shotsongoal2 { get; set; }
        public int? Totalshots2 { get; set; }
        public int? Shotsinside2 { get; set; }
        public int? Shotsoutside2 { get; set; }
        public int? Fouls2 { get; set; }
        public int? Corners2 { get; set; }
        public int? Offsides2 { get; set; }
        public int? Possession2 { get; set; }
        public int? Yellowcards2 { get; set; }
        public int? Redcards2 { get; set; }
        public int? Saves2 { get; set; }
        public int? Totalasses2 { get; set; }
        public int? Passespercent2 { get; set; }
    }
}
