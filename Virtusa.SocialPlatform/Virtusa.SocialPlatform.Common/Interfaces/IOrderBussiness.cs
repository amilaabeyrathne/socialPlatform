using System;
using System.Collections.Generic;
using System.Text;
using Virtusa.SocialPlatform.Common.Models;

namespace Virtusa.SocialPlatform.Common.Interfaces
{
    public interface IOrderBussiness
    {
       // List<ItemModel> GetItemDetails();

       // int CreateOrder(OrderDetailModel orderDetailModel);

        int makeOrder(OrderModel orderModel);


    }
}
