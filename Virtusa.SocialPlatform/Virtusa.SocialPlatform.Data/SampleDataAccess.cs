using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Virtusa.SocialPlatform.Common.Interfaces;
using Virtusa.SocialPlatform.Data.Models;

namespace Virtusa.SocialPlatform.Data
{
    public class SampleDataAccess : ISampleDataAccess
    {
        SampleContext context;
        public SampleDataAccess(SampleContext dbContext)
        {
            context = dbContext;
        }
        public string GetSample(int id)
        {
            return context.Samples.FirstOrDefaultAsync(x => x.Id == id).Result.Name;
        }
    }
}
