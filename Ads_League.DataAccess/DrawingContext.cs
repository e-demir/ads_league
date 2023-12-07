using System;
using Ads_League.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ads_League.DataAccess
{
	public class DrawingContext : DbContext
	{
		public DbSet<Drawing> Drawings { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,57000\\\\Catalog=wiseup1;Database=ads_league;User=sa;Password=Str#ng_Passw#rd;Persist Security Info=False;Encrypt=False;");            
        }
    }
}

