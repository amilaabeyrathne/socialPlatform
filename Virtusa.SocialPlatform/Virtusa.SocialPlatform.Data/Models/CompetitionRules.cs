using System;
using System.Collections.Generic;
using System.Text;

namespace Virtusa.SocialPlatform.Data.Models
{
    public class CompetitionRules
    {
        public int Id { get; set; }
        public int CompetitionId { get; set; }
        public string Rules { get; set; }
        public string EventCode { get; set; }
    }
}
