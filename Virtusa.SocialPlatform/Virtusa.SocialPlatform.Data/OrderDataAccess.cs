using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Virtusa.SocialPlatform.Common.Interfaces;
using Virtusa.SocialPlatform.Common.Models;
using Virtusa.SocialPlatform.Data.Models;
using AutoMapper;
using System.Threading.Tasks;

namespace Virtusa.SocialPlatform.Data
{
    public class OrderDataAccess : IOrderDataAccess
    {
        SampleContext context;

        public OrderDataAccess(SampleContext dbContext)
        {
            context = dbContext;
        }

        //public int CreateOrder(OrderDetailModel orderDetailModel)
        //{
        //    context.OrderDetails.Add(PopulateOrderDetailDBObject(orderDetailModel));
        //    return context.SaveChanges();
        //}

        //public List<ItemModel> GetItemDetails()
        //{
        //    //List<Item> itemList = (from item in context.Items
        //    //                       select item).ToList();

        //    List<Item> itemList = context.Items.Select(x => x).ToList();

        //    Mapper.Initialize(cfg =>
        //    {
        //        cfg.CreateMap<Item, ItemModel>();
        //    });

        //    List<ItemModel> modelList = new List<ItemModel>();

        //    foreach (Item item in itemList)
        //    {
        //        ItemModel model = Mapper.Map<ItemModel>(item);
        //        modelList.Add(model);
        //    }

        //    //context.Items.Select(x => PopulateNewsModel(x)).ToListAsync()
        //    //context.Items.FindAsync()
        //    return modelList;
        //}

        public int makeOrder(OrderModel orderModel)
        {
            double total;
            total = orderModel.Quantity * orderModel.TotalPrice;
            orderModel.TotalPrice = total;
            context.Orders.Add(PopulateOrderDBObject(orderModel));
            return context.SaveChanges();
        }

        public async Task<IEnumerable<OrderModel>> GetAllOrders()
        {
            IEnumerable<OrderModel> allNewsFromDB = await context.Orders.Select(x =>PopulateOrederModel(x)).OrderByDescending(x => x.OrderDate).ToListAsync();

            return allNewsFromDB;
        }


        private Order PopulateOrderDBObject(OrderModel orderModel)
        {

            return new Order
            {

                EmployeeId = orderModel.EmployeeId,
                OrderDate = orderModel.OrderDate,
                Quantity = orderModel.Quantity,
                Size = orderModel.Size,
                OrderId = orderModel.OrderId,
                TotalPrice = orderModel.TotalPrice

            };

        }

        private OrderModel PopulateOrederModel(Order orderFromDb)
        {
            return new OrderModel
            {
                EmployeeId = orderFromDb.EmployeeId,
                OrderDate = orderFromDb.OrderDate,
                Quantity = orderFromDb.Quantity,
                Size = orderFromDb.Size,
                OrderId = orderFromDb.OrderId,
                TotalPrice = orderFromDb.TotalPrice
            };
        }
    }
}
