using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GICDashboardMicroservices.Models
{
    public partial class Dashboard
    {
        public int ProductCount { get; set; }
        public string LastProductAdded { get; set; }
        public int CustomerCount { get; set; }
        public string LastCustomerAdded { get; set; }
        public int UserCount { get; set; }
        public string LastUserAdded { get; set; }
    }
}
