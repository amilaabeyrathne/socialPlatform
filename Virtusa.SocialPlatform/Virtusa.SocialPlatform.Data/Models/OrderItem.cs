using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Virtusa.SocialPlatform.Data.Models
{
    public class OrderItem
    {
        /// <summary>
        /// get or set OrderId
        /// </summary>
        //[Key, Column(Order = 0)]
        //public int OrderId { get; set; }

        ///// <summary>
        ///// get or set ItemId
        ///// </summary>
        //[Key, Column(Order = 1)]
        //public int ItemId { get; set; }

        /// <summary>
        /// get or set order
        /// </summary>
        public virtual Order Order { get; set; }

        /// <summary>
        /// get or set item
        /// </summary>
        public virtual Item  Item{ get; set; }

        /// <summary>
        /// get or set Quantity
        /// </summary>
        public int Quantity { get; set; }

        public double Total { get; set; }
    }
}
