﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CBevInc
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WebDBEntities : DbContext
    {
        public WebDBEntities()
            : base("name=WebDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Finished_Goods> Finished_Goods { get; set; }
        public virtual DbSet<Raw_Materials> Raw_Materials { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
    }
}
