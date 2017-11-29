using System;
using System.Collections.Generic;
using System.Text;

namespace Virtusa.SocialPlatform.Data.Models
{
    public class Participants
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int TierId { get; set; }
        public int CegId { get; set; }
        public int CompetitionId { get; set; }
        public string ContactNo { get; set; }
        public string EventCode { get; set; }
        /// <summary>
        /// The value should be true or false, if it is team participal the value should be 'true' otherwise 'false';
        /// </summary>
        public bool IsGroup { get; set; }

        public int TeamParentId { get; set; }

    }
}
