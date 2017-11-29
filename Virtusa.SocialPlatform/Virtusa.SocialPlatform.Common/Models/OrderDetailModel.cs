using System;
using System.Collections.Generic;
using System.Text;

namespace Virtusa.SocialPlatform.Common.Models
{
    public class OrderDetailModel
    {
        public int Id { get; set; }

        public int ItemId { get; set; }

        public int Quantity { get; set; }

        public string Date { get; set; }

        public int EmployeeId { get; set; }

        public double Total { get; set; }

        public string Size { get; set; }
    }
}
