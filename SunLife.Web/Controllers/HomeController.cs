using SunLife.Web.Models;
using SunLife.Web.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SunLife.Web.Controllers
{
    public class HomeController : Controller
    {
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public CustomerRepository customerRepository = new CustomerRepository();

        [HttpPost]
        public ActionResult AddCustomer(Customer customer)
        {
            var result = customerRepository.GetByUserLogin(customer);

            return View(customer);
        }



        public ActionResult Index(Customer customer)
        {
            var data = customerRepository.GetAllCustomer(Name: customer.Name, CreateDate: customer.CreateDate);
            return View(data);
        }

        public ActionResult InsuranceInfo(string id = "")
        {
            var cus = new Customer();
            if (!string.IsNullOrEmpty(id))
                cus = customerRepository.GetById(new Guid(id)).FirstOrDefault();
            return View(cus);
        }
    }
}