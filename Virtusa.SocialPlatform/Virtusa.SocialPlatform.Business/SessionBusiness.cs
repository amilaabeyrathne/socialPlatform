using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Virtusa.SocialPlatform.Common.Interfaces;
using Virtusa.SocialPlatform.Common.Models;


namespace Virtusa.SocialPlatform.Business
{
    public class SessionBusiness : ISessionBusiness
    {
        ISessionDataAccess data;
        public SessionBusiness(ISessionDataAccess dataAccess)
        {
            data = dataAccess;
        }

        public int AddSession(SessionModel sessionItemToAdd)
        {
            return data.Save(sessionItemToAdd);
        }

        public int DeleteSession(int id)
        {
            return data.DeleteSession(id);
        }

        public int EditSession(SessionModel sessionModel)
        {
            return data.EditSession(sessionModel);
        }

        public async Task<IEnumerable<SessionModel>> GetAllSession()
        {
            return await data.GetAllSession();
        }

        public async Task<SessionModel> GetSession(int id)
        {
            return await data.GetSession(id);
        }

    }
}
