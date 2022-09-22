using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistic_grabber
{
    /// <summary>
    /// Automatically generated class from api request (fixture stats)
    /// </summary>
    public class Fixturedeser
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
            public Statistic[] statistics { get; set; }
        }

        public class Team
        {
            public int id { get; set; }
            public string name { get; set; }
            public string logo { get; set; }
        }

        public class Statistic
        {
            public string type { get; set; }
            public object value { get; set; }
        }

    }
}
