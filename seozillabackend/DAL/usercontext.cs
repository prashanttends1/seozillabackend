﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using seozillabackend.Models;


namespace seozillabackend.DAL
{
    public class usercontext:DbContext
    {
        public DbSet<user> users { get; set; }
        public DbSet<order> orders { get; set; }
        public DbSet<blog> blogs { get; set; }
        public DbSet<citation> citations { get; set; }
        public DbSet<zillablog> zillablogs { get; set; }
        public DbSet<zillaonpage> zillaonpages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public System.Data.Entity.DbSet<seozillabackend.Models.zillalinkbuilding> zillalinkbuildings { get; set; }

        public System.Data.Entity.DbSet<seozillabackend.Models.zillax> zillaxes { get; set; }

        

    }
}