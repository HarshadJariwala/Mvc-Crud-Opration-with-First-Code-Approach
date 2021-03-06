﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using mvccrud.Models;

namespace mvccrud.Models
{
    public class DetailsContext : DbContext
    {
        public DetailsContext() : base("empdatabase")
        {
           Database.SetInitializer(new MigrateDatabaseToLatestVersion<DetailsContext, mvccrud.Migrations.Configuration>());
        }
        public DbSet<Employee> employees { get; set; }

        public DbSet<City> Citys { get; set; }

        public DbSet<Country> Countrys { get; set; }

        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingEntitySetNameConvention>();
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}