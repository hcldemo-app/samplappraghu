//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GICCustomerApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductCompany
    {
        public int ProductCompanyID { get; set; }
        public int ProductID { get; set; }
        public int CompanyID { get; set; }
    
        public virtual CompanyID CompanyID1 { get; set; }
        public virtual ProductInfo ProductInfo { get; set; }
    }
}
