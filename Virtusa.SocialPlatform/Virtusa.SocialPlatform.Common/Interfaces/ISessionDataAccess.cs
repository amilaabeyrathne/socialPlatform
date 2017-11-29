using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Virtusa.SocialPlatform.Common.Models;
namespace Virtusa.SocialPlatform.Common.Interfaces
{
    public interface ISessionDataAccess
    {
        Task<SessionModel> GetSession(int id);
        int Save(SessionModel sessionItemToAdd);
        Task<IEnumerable<SessionModel>> GetAllSession();
        int DeleteSession(int id);
        int EditSession(SessionModel sessionModel);
    }
}
