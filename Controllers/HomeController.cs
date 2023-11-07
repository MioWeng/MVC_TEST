using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_TEST.Models;
using MVC_TEST.Repository;



namespace MVC_TEST.Controllers
{
    public class HomeController : Controller
    {
        EmployeesRepository myEmployeesRepository = new EmployeesRepository();

        // GET: Home
        public ActionResult Index()
        {
            return View(myEmployeesRepository.GetList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employees Employees)
        {
            try
            {
                myEmployeesRepository.Create(Employees);  //新增人員
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
      
        public ActionResult Delete(int ID)
        {
            try
            {
                return View(myEmployeesRepository.QueryEmployeesToID(ID));  //查詢人員
            }
            catch
            {
                return View();
            }       
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int ID)
        {
            try
            {
                myEmployeesRepository.Delete(ID);  //刪除人員
                return RedirectToAction("Index");
            }
            catch 
            {
                return View();
            }
        }

        public ActionResult Edit(int ID)
        {
            try
            {
                return View(myEmployeesRepository.QueryEmployeesToID(ID));  //查詢人員
            }
            catch
            {
                return View();
            }
        }

        [HttpPost, ActionName("Edit")]
        public ActionResult EditConfirmed(Employees Employees)
        {
            try
            {
                myEmployeesRepository.Edit(Employees);  //修改
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}