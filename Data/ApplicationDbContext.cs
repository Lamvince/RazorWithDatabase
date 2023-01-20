using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamPlayers.Models;

namespace TeamPlayers.Data
{
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {}


        public DbSet<Team>? Teams { get; set; }
        public DbSet<Player>? Players { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // validation
            builder.Entity<Player>().Property(m => m.TeamName).IsRequired();
            builder.Entity<Team>().Property(p => p.TeamName).HasMaxLength(30);

            // naming the table "Team" and "Player"
            // default is Teams and Players (plural)
            builder.Entity<Team>().ToTable("Team");
            builder.Entity<Player>().ToTable("Player");

            // method in SeedData.cs
            builder.Seed();
        } 
    }
}