using System;
using System.Collections.Generic;
using System.Text;
using Virtusa.SocialPlatform.Common.Interfaces;
using Virtusa.SocialPlatform.Common.Models;

namespace Virtusa.SocialPlatform.Business
{
    public class CompetitionBusiness : ICompetitionBusiness
    {
        #region class veriables

        ICompetitionDataAccess dataAccess;

        #endregion

        #region constructors

        public CompetitionBusiness(ICompetitionDataAccess data)
        {
            dataAccess = data;
        }

        #endregion

        #region public methods

        public List<CompetitionModel> GetAll()
        {
            return dataAccess.GetAll();
        }

        public List<CompetitionModel> GetCompetition(int id)
        {
            return dataAccess.GetCompetition(id);
        }

        public string Save(CompetitionModel model)
        {
           return dataAccess.Save(model);
        }

        public string Delete(long id)
        {
            return dataAccess.Delete(id);
        }


        public string Update(CompetitionModel model)
        {
            return dataAccess.Update(model);
        }
        #endregion
    }
}
