using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistic_grabber
{
    /// <summary>
    /// Automatically generated class from api request (fixture advanced details)
    /// </summary>
    public class Flupdeser
    {

        public class Rootobject
        {
            public string get { get; set; }
            public Parameters parameters { get; set; }
            public object[] errors { get; set; }
            public int results { get; set; }
            public Paging paging { get; set; }
            public Response[] response { get; set; }
        }

        public class Parameters
        {
            public string fixture { get; set; }
        }

        public class Paging
        {
            public int current { get; set; }
            public int total { get; set; }
        }

        public class Response
        {
            public Team team { get; set; }
            public Coach coach { get; set; }
            public string formation { get; set; }
            public Startxi[] startXI { get; set; }
            public Substitute[] substitutes { get; set; }
        }

        public class Team
        {
            public int id { get; set; }
            public string name { get; set; }
            public string logo { get; set; }
            public Colors colors { get; set; }
        }

        public class Colors
        {
            public Player player { get; set; }
            public Goalkeeper goalkeeper { get; set; }
        }

        public class Player
        {
            public string primary { get; set; }
            public string number { get; set; }
            public string border { get; set; }
        }

        public class Goalkeeper
        {
            public string primary { get; set; }
            public string number { get; set; }
            public string border { get; set; }
        }

        public class Coach
        {
            public int id { get; set; }
            public string name { get; set; }
            public string photo { get; set; }
        }

        public class Startxi
        {
            public Player1 player { get; set; }
        }

        public class Player1
        {
            public int id { get; set; }
            public string name { get; set; }
            public int number { get; set; }
            public string pos { get; set; }
            public string grid { get; set; }
        }

        public class Substitute
        {
            public Player2 player { get; set; }
        }

        public class Player2
        {
            public int id { get; set; }
            public string name { get; set; }
            public int number { get; set; }
            public string pos { get; set; }
            public object grid { get; set; }
        }

    }
}
