using System;
using System.Collections.Generic;

namespace GICDashboardMicroservices.Models
{
    public partial class UsersInfo
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmailId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CustomerId { get; set; }

        public CompanyId Customer { get; set; }
    }
}
