using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Virtusa.SocialPlatform.Common.Interfaces;
using Virtusa.SocialPlatform.Common.Models;

namespace Virtusa.SocialPlatform.Business
{
    public class AttendanceBusiness : IAttendanceBusiness
    {
        IAttendanceDataAccess attendancedata;
        public AttendanceBusiness(IAttendanceDataAccess dataAccess)
        {
            attendancedata = dataAccess;
        }
        public int CreateAttendances(AttendanceModel attendanceModel)
        {
            return attendancedata.CreateAttendances(attendanceModel);
        }

        public int DeleteAttendances(int? sessionId, int? competitionId, int empId)
        {
            return attendancedata.DeleteAttendances(sessionId, competitionId, empId);
        }

        public async Task<IEnumerable<AttendanceModel>> GetAllAttendancesAsync(int? sessionId, int? competitionId)
        {
            return await attendancedata.GetAllAttendancesAsync(sessionId, competitionId);
        }

        public async Task<IEnumerable<AttendanceModel>> GetAttendanceById(int empId)
        {
            return await attendancedata.GetAttendanceById(empId);
        }

        public async Task<IEnumerable<CompetitionModel>> GetCompetitionsAsync()
        {
            return await attendancedata.GetCompetitionsAsync();
        }

        public async Task<IEnumerable<SessionModel>> GetSessionAsync()
        {
            return await attendancedata.GetSessionAsync();
        }
    }
}
