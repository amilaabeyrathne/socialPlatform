using System;
using System.Collections.Generic;
using System.Text;

namespace Virtusa.SocialPlatform.Common.Models
{
    public class OrderModel
    {
        /// <summary>
        /// get or set OrderId
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// get or set EmployeeId
        /// </summary>
        public string EmployeeId { get; set; }
        /// <summary>
        /// get or set OrderDate
        /// </summary>
        public string OrderDate { get; set; }
        /// <summary>
        /// get or set TotalPrice
        /// </summary>
        public double TotalPrice { get; set; }

        public int Quantity { get; set; }

        public string Size { get; set; }
    }
}
