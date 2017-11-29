using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Virtusa.SocialPlatform.Common.Interfaces;
using Virtusa.SocialPlatform.Common.Models;

namespace Virtusa.SocialPlatform.Controllers
{
    [Route("api/[controller]")]
    public class ExcelExportController : Controller
    {
        IExcellExportBusiness excelExport;
        public ExcelExportController(IExcellExportBusiness expoBus)
        {
            excelExport = expoBus;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string ExportTableData()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory.ToString();
            string fileName = "order.xlsx";
            path = path + fileName;
            excelExport.ExportData(path);
            return path;
        }
    }
}