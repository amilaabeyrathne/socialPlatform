using System;
using System.Collections.Generic;
using System.Text;

namespace Virtusa.SocialPlatform.Common.Models
{
   public class NewsModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModified { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsPublished { get; set; }
        public string Category { get; set; }
        public string EventCode { get; set; }
        public int Priority { get; set; }
        public string Summary { get; set; }

        public bool IsDeleted { get; set; }
    }
}
