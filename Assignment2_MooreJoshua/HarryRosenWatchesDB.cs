using System;
using System.Data.Entity;
using System.Linq;
using Assignment2_MooreJoshua.Models;

namespace Assignment2_MooreJoshua
{
    /// <summary>
    /// Author: Joshua Moore
    /// Course: .Net Technologies using C#
    /// Date Created: 2024-12-01
    /// </summary>
    public class HarryRosenWatchesDB : DbContext
    {
        /// <summary>
        /// Author: Joshua Moore
        /// Course: .Net Technologies using C#
        /// Date Created: 2024-12-01
        /// </summary>
        public HarryRosenWatchesDB()
            : base()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<HarryRosenWatchesDB>());



        }

        public DbSet<Item> Items { get; set; }
    }
}
