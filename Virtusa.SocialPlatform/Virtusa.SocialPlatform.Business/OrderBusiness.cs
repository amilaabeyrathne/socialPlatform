using System;
using System.Collections.Generic;
using System.Text;
using Virtusa.SocialPlatform.Common.Interfaces;
using Virtusa.SocialPlatform.Common.Models;

namespace Virtusa.SocialPlatform.Business
{
    public class OrderBusiness : IOrderBussiness
    {
        IOrderDataAccess data;
        public OrderBusiness(IOrderDataAccess dataAccess)
        {
            data = dataAccess;
        }

        //public int CreateOrder(OrderDetailModel orderDetailModel)
        //{
        //    return data.CreateOrder(orderDetailModel);
        //}

        //public List<ItemModel> GetItemDetails()
        //{
        //    return data.GetItemDetails();
        //}

        public int makeOrder(OrderModel orderModel)
        {
            return data.makeOrder(orderModel);
        }
    }
}
