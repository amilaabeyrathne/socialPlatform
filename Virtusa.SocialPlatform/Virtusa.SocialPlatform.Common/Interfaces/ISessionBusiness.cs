using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Virtusa.SocialPlatform.Common.Models;

namespace Virtusa.SocialPlatform.Common.Interfaces
{
    public interface ISessionBusiness
    {
        Task<SessionModel> GetSession(int id);   
        Task<IEnumerable<SessionModel>> GetAllSession();
        int AddSession(SessionModel sessionItemToAdd);
        int DeleteSession(int id);
        int EditSession(SessionModel sessionModel);
    }
}
