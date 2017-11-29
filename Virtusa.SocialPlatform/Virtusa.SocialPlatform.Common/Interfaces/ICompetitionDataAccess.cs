using System;
using System.Collections.Generic;
using System.Text;
using Virtusa.SocialPlatform.Common.Models;

namespace Virtusa.SocialPlatform.Common.Interfaces
{
    public interface ICompetitionDataAccess
    {
        List<CompetitionModel> GetCompetition(int id);
        string Save(CompetitionModel model);
        List<CompetitionModel> GetAll();

        string Delete(long id);

        string Update(CompetitionModel Model);
    }
}
