using System;
using System.Collections.Generic;
using System.Text;

namespace Virtusa.SocialPlatform.Common.Models
{
    public class RegistrationModel
    {
        public int ParticipantId { get; set; }
        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public int CompetitionsId { get; set; }

        public string TeamName { get; set; }
        public List<TeamsModel> teamMembers { get; set; }

        public int CegId { get; set; }

        public int TierId { get; set; }
        public string Contact { get; set; }

        public bool IsGroup { get; set; }
        public string CompetitionName { get; set; }

        public string TeamPath { get; set; }
        public int TeamId { get; set; }

    }
}
