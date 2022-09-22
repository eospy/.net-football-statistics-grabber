using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace Statistic_grabber
{
    /// <summary>
    /// Entity db connection provider for teams stats storing
    /// </summary>
    class TeamContext : DbContext
    {
        public TeamContext()

            : base("DbConnection")

        { }

        public DbSet<Teamsdb> Teamsdbs { get; set; }

    }
}
