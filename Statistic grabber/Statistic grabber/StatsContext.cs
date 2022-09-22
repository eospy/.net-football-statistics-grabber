using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Statistic_grabber
{
    /// <summary>
    /// Entity db connection provider for fixtures stats storing
    /// </summary>
        class StatsContext : DbContext
        {
            public StatsContext()

                : base("DbConnection")

            { }

            public DbSet<Statsdb> Statsdbs { get; set; }

        }
    }

