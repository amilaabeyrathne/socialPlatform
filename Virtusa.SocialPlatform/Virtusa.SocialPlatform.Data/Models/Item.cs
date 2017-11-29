using System;
using System.Collections.Generic;
using System.Text;

namespace Virtusa.SocialPlatform.Data.Models
{
    public class Item
    {
        /// <summary>
        /// get or set ItemId
        /// </summary>
        public int ItemId { get; set; }
        /// <summary>
        /// get or set ItemName
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// get or set Size
        /// </summary>
        public string Size { get; set; }
        /// <summary>
        /// get or set ItemPrice
        /// </summary>
        public double ItemPrice { get; set; }

        /// <summary>
        /// get or ser Order Items
        /// </summary>
        //public virtual ICollection<OrderItem> OrderItems { get; set; }

    }
}
