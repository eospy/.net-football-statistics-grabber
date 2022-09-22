using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistic_grabber
{

     class Program
    {
        static void Main(string[] args)
        {
            //usage example
            Connector c = new Connector();
            var fixtures = c.Getstats(39,33, 2021);
            Console.WriteLine(fixtures.team.name);
            Console.ReadKey();
        }
    }
}