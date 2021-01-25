using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PatientManagementBusiness;
using PatientManagementBusiness.Models;
using PatientManagementDAL;

namespace PatientManagementUI.Controllers
{
    public class TestController : Controller
    {
        private TestManagerBL dbTest = new TestManagerBL();

        // GET: Test
        [Authorize(Roles = "Admin,User")]
        public ActionResult Index()
        {
            var tests = new TestManager().FindAll(false);
            return View(tests);
        }

        // GET: Test/Details/5
        [Authorize(Roles = "Admin,User")]
        public ActionResult Details(int id)
        {
            Test test = new TestManager().Find(id);

            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // GET: Test/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            Test model = new Test();
            return View(model);
        }

        // POST: Test/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Test model)
        {
            try
            {
                // TODO: Add insert logic here
                dbTest.Save(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ex.Message.Trim();
                return View(model);
            }
        }

        // GET: Test/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            Test model = dbTest.Find(id);
            return View(model);
        }

        // POST: Test/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Test model)
        {
            try
            {
                // TODO: Add update logic here
                dbTest.Modify(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Test/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            Test test = new TestManager().Find(id);

            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // POST: Test/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var activePatients = new TestManager().FindActivePatients(id);

                if (activePatients != null && activePatients.Count() > 0)
                {
                    Test test = new TestManager().Find(id);
                    ModelState.AddModelError("InUse", "Test is already being used by a patient.");
                    return View(test);
                }
                else
                {
                    dbTest.Delete(id);
                }
                
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}