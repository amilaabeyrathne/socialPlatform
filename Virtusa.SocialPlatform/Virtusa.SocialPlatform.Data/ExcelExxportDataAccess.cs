using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Virtusa.SocialPlatform.Common.Interfaces;
using Virtusa.SocialPlatform.Common.Models;
using Virtusa.SocialPlatform.Data.Models;

namespace Virtusa.SocialPlatform.Data
{
    public class ExcelExxportDataAccess: IExcelExxportDataAccess
    {
        SampleContext context;
        public ExcelExxportDataAccess(SampleContext dbContext)
        {
            this.context = dbContext;
        }

        public async Task<IEnumerable<OrderModel>> GetAllOrders()
        {
            return await new OrderDataAccess(context).GetAllOrders();
        }
    }
}
