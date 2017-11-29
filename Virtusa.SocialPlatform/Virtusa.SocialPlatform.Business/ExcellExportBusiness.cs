using System;
using System.Collections.Generic;
using System.Text;
using Virtusa.SocialPlatform.Common.Utility;
using Virtusa.SocialPlatform.Common.Interfaces;
using Virtusa.SocialPlatform.Common.Models;

namespace Virtusa.SocialPlatform.Business
{
    public class ExcellExportBusiness:IExcellExportBusiness
    {
        IExcelExxportDataAccess orderData;
        ExportToExcel<dynamic> exporter;
        public ExcellExportBusiness(IExcelExxportDataAccess order)
        {
            orderData = order;
        }


        public string ExportData(string path)
        {
            exporter = new ExportToExcel<dynamic>();
            var list = orderData.GetAllOrders().Result;
            exporter.ExportDataSet(exporter.MakeDataTable(list), path);
            return path;
        }
    }
}
