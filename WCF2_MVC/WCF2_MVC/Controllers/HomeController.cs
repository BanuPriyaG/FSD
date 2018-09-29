using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WCF2_MVC.Controllers
{
    public class HomeController : Controller
    {
        EmpService.IService1 client = new EmpService.Service1Client();
        // GET: Home
        public ActionResult Index()
        {
            var empList = client.RetreiveEmployees();
            return View(empList);
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            var emp = client.RetreiveEmployeeByID(id);
            return View(emp);
        }
        
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(EmpService.Employee emp)
        {
            try
            {
                client.AddEmployee(emp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            var emp = client.RetreiveEmployeeByID(id);
            return View(emp);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EmpService.Employee emp)
        {
            try
            {
                client.UpdateEmployee(id, emp);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            client.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}
