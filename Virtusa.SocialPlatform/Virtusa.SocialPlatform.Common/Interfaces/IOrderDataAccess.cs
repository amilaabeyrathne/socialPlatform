using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Virtusa.SocialPlatform.Common.Models;

namespace Virtusa.SocialPlatform.Common.Interfaces
{
    public interface IOrderDataAccess
    {
       // List<ItemModel> GetItemDetails();

       // int CreateOrder(OrderDetailModel orderDetailModel);

        int makeOrder(OrderModel orderModel);
        Task<IEnumerable<OrderModel>> GetAllOrders();
    }
}
