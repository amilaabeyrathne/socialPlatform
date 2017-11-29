using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Virtusa.SocialPlatform.Common.Models;

namespace Virtusa.SocialPlatform.Common.Interfaces
{
    public interface IAttendanceBusiness
    {
        Task<IEnumerable<AttendanceModel>> GetAttendanceById(int empId);
        int CreateAttendances(AttendanceModel attendanceModel);
        Task<IEnumerable<CompetitionModel>> GetCompetitionsAsync();
        Task<IEnumerable<SessionModel>> GetSessionAsync();
        Task<IEnumerable<AttendanceModel>> GetAllAttendancesAsync(int? sessionId, int? competitionId);
        int DeleteAttendances(int? sessionId, int? competitionId, int empId);
    }
}
