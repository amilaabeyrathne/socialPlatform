using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Virtusa.SocialPlatform.Data.Models
{
    public class SampleContext : DbContext
    {
        public SampleContext(DbContextOptions<SampleContext> options)
            : base(options)
        { }

        public DbSet<Sample> Samples { get; set; }

        public DbSet<News> News { get; set; }

        public DbSet<Competition> Competition { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Tiers> Tiers { get; set; }
        public DbSet<Cegs> Cegs { get; set; }
        public DbSet<Teams> Teams { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<CompetitionRules> CompetitionRules { get; set; }
        public DbSet<Memberships> Memberships { get; set; }
        public DbSet<Participants> Participants { get; set; }
        public DbSet<Session> Session { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
    }
}
