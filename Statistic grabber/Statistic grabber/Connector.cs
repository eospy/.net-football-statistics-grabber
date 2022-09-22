using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading;
using System.IO;

namespace Statistic_grabber
{
    public class Connector
    {
        /// <summary>
        /// Get stats of chosen team
        /// </summary>
        public Statdeser.Response Getstats(int league, int team, int season)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("x-rapidapi-key", "defcf1a5c32c433f22c44645029934c2");
            httpClient.DefaultRequestHeaders.Add("x-rapidapi-host", "v3.football.api-sports.io");
            var jsonstring = httpClient.GetStringAsync("https://v3.football.api-sports.io/teams/statistics/?league=" + league + "&season=" + season + "&team=" + team);
            var root = JsonConvert.DeserializeObject<Statdeser.Rootobject>(jsonstring.Result);
            var resp = JsonConvert.DeserializeObject<Statdeser.Response>(JsonConvert.SerializeObject(root.response));
            return resp;
        }
       /// <summary>
       /// Get fixtures of league at specific season
       /// </summary>
       /// <param name="league"></param>
       /// <param name="season"></param>
       /// <returns></returns>
        public List<Updateclass> Getleaguefixtures(int league, int season)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("x-rapidapi-key", "410f0c55c6msh5494bff701e5b88p13fa66jsnc6132d3fc24a");
            httpClient.DefaultRequestHeaders.Add("x-rapidapi-host", "api-football-beta.p.rapidapi.com");
            List<Updateclass> list = new List<Updateclass>();
            var jsonstring = httpClient.GetStringAsync("https://api-football-beta.p.rapidapi.com/fixtures/?league=" + league + "&season=" + season);
            var root = JsonConvert.DeserializeObject<Fixdeser.Rootobject>(jsonstring.Result);
            var resp = JsonConvert.DeserializeObject<Fixdeser.Response[]>(JsonConvert.SerializeObject(root.response));
            for (int i = 0; i < resp.Length; i++)
            {
                list.Add(new Updateclass(resp[i].teams.home.id, resp[i].teams.away.id, resp[i].fixture.referee, resp[i].goals.home, resp[i].goals.away));
            }
            return list;
        }

        
        /// <summary>
        /// Get stats by fixture id
        /// </summary>
        /// <param name="fixtureid"></param>
        /// <returns></returns>
        public Statsdb Getfixturestats(int fixtureid)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("x-rapidapi-key", "410f0c55c6msh5494bff701e5b88p13fa66jsnc6132d3fc24a");
            httpClient.DefaultRequestHeaders.Add("x-rapidapi-host", "api-football-beta.p.rapidapi.com");
            var jsonstring = httpClient.GetStringAsync("https://api-football-beta.p.rapidapi.com/fixtures/statistics/?fixture=" + fixtureid);
            var root = JsonConvert.DeserializeObject<Fixturedeser.Rootobject>(jsonstring.Result);
            var resp = JsonConvert.DeserializeObject<Fixturedeser.Response[]>(JsonConvert.SerializeObject(root.response));
            var stat1 = JsonConvert.DeserializeObject<Fixturedeser.Statistic[]>(JsonConvert.SerializeObject(resp[0].statistics));
            var stat2 = JsonConvert.DeserializeObject<Fixturedeser.Statistic[]>(JsonConvert.SerializeObject(resp[1].statistics));
           
            var json2 = httpClient.GetStringAsync("https://api-football-beta.p.rapidapi.com/fixtures/lineups/?fixture=" + fixtureid);

            var root2 = JsonConvert.DeserializeObject<Flupdeser.Rootobject>(json2.Result);
            var resp2 = JsonConvert.DeserializeObject<Flupdeser.Response[]>(JsonConvert.SerializeObject(root2.response));

            Statsdb statsdb = new Statsdb(
                resp[0].team.name, resp[0].team.id, resp2[0].formation, Convert.ToInt32(stat1[0].value), Convert.ToInt32(stat1[2].value), Convert.ToInt32(stat1[4].value), Convert.ToInt32(stat1[5].value), Convert.ToInt32(stat1[6].value), Convert.ToInt32(stat1[7].value), Convert.ToInt32(stat1[8].value), Convert.ToInt32(stat1[9].value.ToString().Remove(2)), Convert.ToInt32(stat1[10].value), Convert.ToInt32(stat1[11].value), Convert.ToInt32(stat1[12].value), Convert.ToInt32(stat1[13].value), Convert.ToInt32(stat1[15].value.ToString().Remove(2)), resp[1].team.name, resp[1].team.id, resp2[1].formation, Convert.ToInt32(stat2[0].value), Convert.ToInt32(stat2[2].value), Convert.ToInt32(stat2[4].value), Convert.ToInt32(stat2[5].value), Convert.ToInt32(stat2[6].value), Convert.ToInt32(stat2[7].value), Convert.ToInt32(stat2[8].value), Convert.ToInt32(stat2[9].value.ToString().Remove(2)), Convert.ToInt32(stat2[10].value), Convert.ToInt32(stat2[11].value), Convert.ToInt32(stat2[12].value), Convert.ToInt32(stat2[13].value), Convert.ToInt32(stat2[15].value.ToString().Remove(2)));
            return statsdb;

        }
        /// <summary>
        /// Adding team list in database
        /// </summary>
        /// <param name="leagueid"></param>
        /// <param name="season"></param>
        public void GetTeams(int leagueid, int season)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("x-rapidapi-key", "defcf1a5c32c433f22c44645029934c2");
            httpClient.DefaultRequestHeaders.Add("x-rapidapi-host", "v3.football.api-sports.io");
            var jsonstring = httpClient.GetStringAsync("https://v3.football.api-sports.io/standings/?league=" + leagueid + "&season=" + season);
            var root = JsonConvert.DeserializeObject<Stdeser.Rootobject>(jsonstring.Result);
            var resp = JsonConvert.DeserializeObject<Stdeser.Response[]>(JsonConvert.SerializeObject(root.response));
            var leag = JsonConvert.DeserializeObject<Stdeser.League>(JsonConvert.SerializeObject(resp[0].league));
            var stan = JsonConvert.DeserializeObject<Stdeser.Standing[][]>(JsonConvert.SerializeObject(leag.standings));

            using (TeamContext db = new TeamContext())
            {
                for (int i = 0; i < stan[0].Length; i++)
                {
                    db.Teamsdbs.Add(new Teamsdb(leagueid, stan[0][i].team.name, stan[0][i].team.id));
                    db.SaveChanges();
                }
            }
        }
        /// <summary>
        /// Get standings of league
        /// </summary>
        /// <param name="leagueid"></param>
        /// <param name="season"></param>
        /// <returns></returns>
        public List<Team> Getstandings(int leagueid, int season)
        {
            HttpClient httpClient = new HttpClient();
            List<Team> teams = new List<Team>();
            httpClient.DefaultRequestHeaders.Add("x-rapidapi-key", "410f0c55c6msh5494bff701e5b88p13fa66jsnc6132d3fc24a");
            httpClient.DefaultRequestHeaders.Add("x-rapidapi-host", "api-football-beta.p.rapidapi.com");
            var jsonstring = httpClient.GetStringAsync("https://api-football-beta.p.rapidapi.com/standings/?league=" + leagueid + "&season=" + season);
            var root = JsonConvert.DeserializeObject<Stdeser.Rootobject>(jsonstring.Result);
            var resp = JsonConvert.DeserializeObject<Stdeser.Response[]>(JsonConvert.SerializeObject(root.response));
            var leag = JsonConvert.DeserializeObject<Stdeser.League>(JsonConvert.SerializeObject(resp[0].league));
            var stan = JsonConvert.DeserializeObject<Stdeser.Standing[][]>(JsonConvert.SerializeObject(leag.standings));


            for (int i = 0; i < stan[0].Length; i++)
            {
                teams.Add(new Team(i + 1, stan[0][i].team.id, stan[0][i].form));

            }
            return teams;
        }

        /// <summary>
        /// Get team by its name from database
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Teamsdb GetTeambyname(string name)
        {
            Teamsdb teamsbyname;
            List<Teamsdb> findedteams = new List<Teamsdb>();
            using (TeamContext db = new TeamContext())
            {
                var teams = db.Teamsdbs;
                teamsbyname = (from t in teams where t.Name == name select t).FirstOrDefault();
                if (teamsbyname == null)
                { 
                    findedteams = Searchteam(name);
                    teamsbyname = findedteams.FirstOrDefault();
                }
            }

            return teamsbyname;
        }

        /// <summary>
        /// Searching teams in database
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Teamsdb> Searchteam(string name)
        {
            List<Teamsdb> teamsbyname;
            using (TeamContext db = new TeamContext())
            {
                var teams = db.Teamsdbs;
                //teamsbyname =( from t in teams where t.Name == name select t).ToList();
                teamsbyname = (from team in teams
                               where team.Name.Contains(name)
                               select team).ToList();
            }

            return teamsbyname;
        }
    }
    //additional classes
    public class Team
    {
        public Team(int standing, int id, string form)
        {
            Id = id;
            Standing = standing;
            Form = form;
        }
        public int Id;
        public int Standing;
        public string Form;
    }
    public class Roundfix
    {
        public Roundfix(int team1id, int team2id, string team1name, string team2name, string referee)
        {
            Team1id = team1id;
            Team2id = team2id;
            Team1name = team1name;
            Team2name = team2name;
            Referee = referee;
        }
        public int Team1id;
        public int Team2id;
        public string Team1name;
        public string Team2name;
        public string Referee;
    }
    public class Fixturedetails
    {
        public Fixturedetails(int team1id, int team2id, string referee, int actualscored1, int actualscored2, string actualresult, string team1name, string team2name)
        {
            Team1id = team1id;
            Team2id = team2id;
            Referee = referee;
            Actualscored1 = actualscored1;
            Actualscored2 = actualscored2;
            Actualresult = actualresult;
            Team1name = team1name;
            Team2name = team2name;
        }
        public int Team1id;
        public int Team2id;
        public string Referee;
        public int Actualscored1;
        public int Actualscored2;
        public string Actualresult;
        public string Team1name;
        public string Team2name;
    }
    public class Anotherone
    {
        public Anotherone(int team1id, int team2id, string referee)
        {
            Team1id = team1id;
            Team2id = team2id;
            Referee = referee;
        }
        public int Team1id;
        public int Team2id;
        public string Referee;
    }
}
