using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Virtusa.SocialPlatform.Common.Models;


namespace Virtusa.SocialPlatform.Common.Interfaces
{
    public interface IExcelExxportDataAccess
    {
         Task<IEnumerable<OrderModel>> GetAllOrders();
    }
}
