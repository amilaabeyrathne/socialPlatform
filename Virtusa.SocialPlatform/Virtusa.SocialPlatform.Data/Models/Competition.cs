using System;
using System.Collections.Generic;
using System.Text;

namespace Virtusa.SocialPlatform.Data.Models
{
    /// <summary>
    /// Contains properties of competition 
    /// </summary>
    public class Competition
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public long EventCode { get; set; }
        public string Description { get; set; }
        public DateTime RegistrationEndDate { get; set; }

        public DateTime EditedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
