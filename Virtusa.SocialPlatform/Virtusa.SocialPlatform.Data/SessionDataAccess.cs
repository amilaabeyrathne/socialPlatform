using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtusa.SocialPlatform.Common.Interfaces;
using Virtusa.SocialPlatform.Common.Models;
using Virtusa.SocialPlatform.Data.Models;

namespace Virtusa.SocialPlatform.Data
{
    public class SessionDataAccess : ISessionDataAccess
    {
        #region private variables
        SampleContext context;
        #endregion

        #region constructors
        public SessionDataAccess(SampleContext DbContext)
        {
            context = DbContext;
        }
        #endregion

        #region public methods
        public async Task<IEnumerable<SessionModel>> GetAllSession()
        {
            IEnumerable<SessionModel> allSessionsFromDB = await context.Session.Select(x => PopulateSessionModel(x)).ToListAsync();

            return allSessionsFromDB;
        }

        public async Task<SessionModel> GetSession(int id)
        {
            Session selectedSession = await context.Session.FirstOrDefaultAsync(x => x.Id == id);

            return PopulateSessionModel(selectedSession);
        }

        public int Save(SessionModel sessionItemToAdd)
        {
            context.Session.Add(PopulateSessionDBObject(sessionItemToAdd));
            return context.SaveChanges();
        }

        public int DeleteSession(int id)
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    var session = context.Session.Where(a => a.Id == id).FirstOrDefault<Session>();
 
                    context.Entry(session).State = EntityState.Deleted;
                    context.SaveChanges();
                    dbContextTransaction.Commit();
                    return 1;

                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return 0;
                }
            }
        }

        public int EditSession(SessionModel sessionModel)
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                        var session = context.Session.Where(a => a.Id == sessionModel.Id).FirstOrDefault<Session>();
                        session = (UpdateSessionDBObject(session, sessionModel));
                        context.Entry(session).State = EntityState.Modified;
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                        return 1;

                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    return 0;
                }
            }
        }

        #endregion

        #region private methods
        private SessionModel PopulateSessionModel(Session sessionFromDB)
        {
            return new SessionModel
            {
                Id = sessionFromDB.Id,
                SessionName = sessionFromDB.SessionName,
                Trainer = sessionFromDB.Trainer,
                SessionDate = sessionFromDB.SessionDate
            };
        }

        private Session PopulateSessionDBObject(SessionModel sessionModel)
        {
            return new Session
            {
                Id = sessionModel.Id,
                SessionName = sessionModel.SessionName,
                Trainer = sessionModel.Trainer,
                SessionDate = sessionModel.SessionDate
            };
        }

        private Session UpdateSessionDBObject(Session session, SessionModel sessionModel)
        {
            try
            {
                session.SessionName = string.IsNullOrEmpty(sessionModel.SessionName) ? session.SessionName : sessionModel.SessionName; ;
                session.Trainer = string.IsNullOrEmpty(sessionModel.Trainer) ? session.Trainer : sessionModel.Trainer;
                session.SessionDate = sessionModel.SessionDate;
                return session;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        #endregion
    }
}
