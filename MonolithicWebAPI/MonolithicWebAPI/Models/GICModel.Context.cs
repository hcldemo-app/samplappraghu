﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MonolithicWebAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LmsDbMyHclEntities2 : DbContext
    {
        public LmsDbMyHclEntities2()
            : base("name=LmsDbMyHclEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CompanyID> CompanyIDs { get; set; }
        public virtual DbSet<EmployeeMyhcl> EmployeeMyhcls { get; set; }
        public virtual DbSet<LMS_Transactions> LMS_Transactions { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCompany> ProductCompanies { get; set; }
        public virtual DbSet<ProductInfo> ProductInfoes { get; set; }
        public virtual DbSet<UsersInfo> UsersInfoes { get; set; }
    }
}