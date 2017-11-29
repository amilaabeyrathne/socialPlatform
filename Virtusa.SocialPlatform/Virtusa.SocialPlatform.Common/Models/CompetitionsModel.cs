using System;
using System.Collections.Generic;
using System.Text;

namespace Virtusa.SocialPlatform.Common.Models
{
    public class CompetitionsModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public long EventCode { get; set; }
        public string Description { get; set; }
        public DateTime RegistrationEndDate { get; set; }

    }
}
