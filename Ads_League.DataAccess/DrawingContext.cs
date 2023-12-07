using System;
using Ads_League.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;

namespace Ads_League.DataAccess
{
	public class DrawingContext : DbContext
	{
        IConfiguration _config;

        public DrawingContext(IConfiguration config)
        {
            _config = config;
        }

        public DbSet<Drawing> Drawings { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("AdsLeagueConnection"));            
        }
    }
}

