using System;
using Virtusa.SocialPlatform.Common.Interfaces;

namespace Virtusa.SocialPlatform.Business
{
    public class SampleBusiness : ISampleBusiness
    {
        ISampleDataAccess data;
        public SampleBusiness(ISampleDataAccess dataAccess)
        {
            data = dataAccess;
        }

        public string GetSample(int id)
        {
            return data.GetSample(id);
        }
    }
}
