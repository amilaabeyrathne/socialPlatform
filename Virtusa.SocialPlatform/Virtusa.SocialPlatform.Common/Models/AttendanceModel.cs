using System;
using System.Collections.Generic;
using System.Text;

namespace Virtusa.SocialPlatform.Common.Models
{
    public class AttendanceModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int? SessionId { get; set; }
        public int? CompetitionId { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDelete { get; set; }
    }
}
