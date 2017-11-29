using System;
using System.Collections.Generic;
using System.Text;

namespace Virtusa.SocialPlatform.Common.Models
{
    public class ParticipentModel
    {
        public int TeamId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int CompetitionId { get; set; }
        public string ContactNo { get; set; }
    }
}
