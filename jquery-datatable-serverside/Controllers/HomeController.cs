using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using jquery_datatable_serverside.Models;

namespace jquery_datatable_serverside.Controllers
{
    public class HomeController : Controller
    {
        private List<Customer> customers;
        public HomeController()
        {
            customers = new List<Customer>();
            customers.Add(new Customer { Id = "1", Name = "John Doe", Email = "john.doe.1@example.com" });
            customers.Add(new Customer { Id = "2", Name = "Jane Doe", Email = "jane.doe.2@example.com" });
            customers.Add(new Customer { Id = "3", Name = "Joe Bloggs", Email = "joe.bloggs.3@example.com" });
            customers.Add(new Customer { Id = "4", Name = "Jane Bloggs", Email = "jane.bloggs.4@example.com" });
            customers.Add(new Customer { Id = "5", Name = "John Smith", Email = "john.smith.5@example.com" });
            customers.Add(new Customer { Id = "6", Name = "Jane Smith", Email = "jane.smith.6@example.com" });
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Data_get()
        {


            var _start = HttpContext.Request.Form["start"];
            var _length = Request.Form["length"];

            int.TryParse(_start, out int start);
            int.TryParse(_length, out int length);


            if (length == 0)
                length = 2;

            var originalCount = customers.Count;
            var filteredCount = originalCount;

            var filteredData = customers.Skip(start).Take(length).ToList();

            var dataToReturn = new
            {
                draw = length,
                recordsTotal = originalCount,
                recordsFiltered = filteredCount,
                dataToReturn = filteredData
            };


            return Json(dataToReturn, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Data_post()
        {


            var _start = HttpContext.Request.Form["start"];
            var _length = Request.Form["length"];

            int.TryParse(_start, out int start);
            int.TryParse(_length, out int length);


            if (length == 0)
                length = 2;

            var originalCount = customers.Count;
            var filteredCount = originalCount;

            var filteredData = customers.Skip(start).Take(length).ToList();

            var dataToReturn = new
            {
                draw = length,
                recordsTotal = originalCount,
                recordsFiltered = filteredCount,
                data = filteredData
            };


            return Json(dataToReturn);
        }


    }
}