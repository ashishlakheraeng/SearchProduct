using LumenWorks.Framework.IO.Csv;
using SearchProduct.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SearchProduct.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           
            return View();

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult AmazonProduct()
        {
            var data = csvReader();

            return View(data);
        }
        public List<AmazonProduct> csvReader()
        {
            var csvTable = new DataTable();
            using (var csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(@"C:\Users\ashish\Desktop\Ashish\results.csv")), true))
            {
                csvTable.Load(csvReader);
            }
            List<AmazonProduct> AmazonProductList = new List<AmazonProduct>();
            for (int i = 0; i < csvTable.Rows.Count; i++)
            {
                AmazonProductList.Add(new AmazonProduct { Description = csvTable.Rows[i][0].ToString(), Rating = csvTable.Rows[i][1].ToString(), 
                    ReviewCount = csvTable.Rows[i][2].ToString() ,URL= csvTable.Rows[i][3].ToString()
                });
            }
            return AmazonProductList;
        }
    }
}