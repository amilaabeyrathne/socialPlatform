using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Virtusa.SocialPlatform.Common.Interfaces;
using Virtusa.SocialPlatform.Common.Models;
using Virtusa.SocialPlatform.Data.Models;
using System.Threading.Tasks;
using System.Linq;

namespace Virtusa.SocialPlatform.Data
{
    public class AttendanceDataAccess : IAttendanceDataAccess
    {
        #region private variables
        private SampleContext context;
        #endregion

        #region constructors
        public AttendanceDataAccess(SampleContext dbcontext)
        {
            context = dbcontext;
        }

        #endregion

        #region public methods

        public int CreateAttendances(AttendanceModel attendanceModel)
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                        var attendance = (PopulateAttendanceDBObject(attendanceModel));
                        context.Attendance.Add(attendance);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                        return 1;
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    return 0;
                }
            }
        }

        public int DeleteAttendances(int? sessionId, int? competitionId, int empId)
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    if (sessionId != null && sessionId > 0)
                    {
                        var attendance = context.Attendance.Where(a => a.EmployeeId == empId && a.SessionId == sessionId).FirstOrDefault<Attendance>();
                        context.Entry(attendance).State = EntityState.Deleted;
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                        return 1;
                    }
                    else if (competitionId != null && competitionId > 0)
                    {
                        var attendance = context.Attendance.Where(a => a.EmployeeId == empId && a.CompetitionId == competitionId).FirstOrDefault<Attendance>();
                        context.Entry(attendance).State = EntityState.Deleted;
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                        return 1;
                    }
                    else
                    {
                        return 1;
                    }

                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return 0;
                }
            }
        }

        public async Task<IEnumerable<AttendanceModel>> GetAllAttendancesAsync(int? sessionId, int? competitionId)
        {
            IEnumerable<AttendanceModel> attendance = null;
            try
            {
                if (sessionId != null && sessionId > 0)
            {
                    IEnumerable<AttendanceModel> allNewsFromDB = await context.Attendance.Where(x => x.SessionId == sessionId).Select(x => PopulateAttendanceModel(x)).ToListAsync();
                }
                else if (competitionId != null && competitionId > 0)
            {
                    IEnumerable<AttendanceModel> allNewsFromDB = await context.Attendance.Where(x => x.CompetitionId == competitionId).Select(x => PopulateAttendanceModel(x)).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }        
            return attendance;
        }

        public async Task<IEnumerable<CompetitionModel>> GetCompetitionsAsync()
        {
            var competition = context.Competition.ToListAsync<Competition>();
            var newcompetitionModel = AutoMapper.Mapper.Map<IEnumerable<CompetitionModel>>(competition.Result);
            return newcompetitionModel;
        }

        public async Task<IEnumerable<SessionModel>> GetSessionAsync()
        {
            var session = context.Session.ToListAsync<Session>();
            var newSessionModel = AutoMapper.Mapper.Map<IEnumerable<SessionModel>>(session.Result);
            return newSessionModel;
        }

        public async Task<IEnumerable<AttendanceModel>> GetAttendanceById(int empId)
        {
            IEnumerable<AttendanceModel> attendance = null;
            try
            {
                if (empId != null && empId > 0)
                {
                    IEnumerable<AttendanceModel> allNewsFromDB = await context.Attendance.Where(x => x.EmployeeId == empId).Select(x => PopulateAttendanceModel(x)).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return attendance;
        }

        #endregion

        #region private methods

        private Attendance PopulateAttendanceDBObject(AttendanceModel attendanceModel)
        {
            return new Attendance
            {
                EmployeeId = attendanceModel.EmployeeId,
                EmployeeName = attendanceModel.EmployeeName,
                SessionId = attendanceModel.SessionId,
                CompetitionId = attendanceModel.CompetitionId,
                CreatedBy = attendanceModel.CreatedBy,
                DateCreated = attendanceModel.DateCreated,
                IsDelete = attendanceModel.IsDelete
            };
        }

        private AttendanceModel PopulateAttendanceModel(Attendance attendanc)
        {
            return new AttendanceModel
            {
                EmployeeId = attendanc.EmployeeId,
                EmployeeName = attendanc.EmployeeName,
                SessionId = attendanc.SessionId,
                CompetitionId = attendanc.CompetitionId,
                CreatedBy = attendanc.CreatedBy,
                DateCreated = attendanc.DateCreated,
                IsDelete = attendanc.IsDelete
            };
        }

        #endregion

    }
}
