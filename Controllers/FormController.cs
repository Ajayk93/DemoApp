using DemoApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoApp.Controllers
{
    public class FormController : Controller
    {
        // GET: Form
        public ActionResult GetForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetForm(FormModel formModel, FormCollection formCollection)
        {
            var surname = Request.Form["SurName"];
            var SurName = formCollection["SurName"];


            if (ModelState.IsValid)
            {

                //business logic

                ModelState.Clear();
            }
            else
            {
                ModelState.AddModelError("","All fields are blank");
            }
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Add(Employee emp)
        {
            using (var empContext = new EmployeeContext())
            {
                empContext.Employees.Add(emp);
                var result = empContext.SaveChanges();

                if(result > 0)
                {
                    ViewBag.isSuccess = "User added successfully";
                }
            }
            return View();
        }

        public ActionResult Details()
        {
            var model = new List<Employee>();
            using (var empContext = new EmployeeContext())
            {
                model = empContext.Employees.ToList();
            }
            return View(model);
        }


        public ActionResult Edit(int id)
        {
            Employee model = null;
            using (var empContext = new EmployeeContext())
            {
                model = empContext.Employees.Find(id);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            using (var empContext = new EmployeeContext())
            {
                empContext.Entry(emp).State = EntityState.Modified;
                int result = empContext.SaveChanges();
                if(result > 0)
                {
                    ViewBag.Success = "update record successfully";
                }
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            Employee model = null;
            using (var empContext = new EmployeeContext())
            {
                model = empContext.Employees.Find(id);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(Employee employee)
        {
            Employee model = null;
            using (var empContext = new EmployeeContext())
            {
                var obj = empContext.Employees.Find(employee.Id);

                empContext.Employees.Remove(obj);
                int result = empContext.SaveChanges();
                if(result > 0)
                {
                    ViewBag.Success = "Record deleted successfully";
                }
                
            }
            return View(model);
        }
    }
}