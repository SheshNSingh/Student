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
    public class PatientRegistrationController : Controller
    {
        // GET: PatientRegistration
        private PatientRegistrationBL db = new PatientRegistrationBL();
        private TestManagerBL dbTest = new TestManagerBL();
        private LabManagerBL dbLab = new LabManagerBL();

        [Authorize(Roles = "Admin,User")]
        public ActionResult Index()
        {
            var patients = new PatientManager().FindAll(false);
            return View(patients);
        }

        // GET: PatientRegistration/Details/5
        [Authorize(Roles = "Admin,User")]
        public ActionResult Details(int id)
        {
            Patient patient = new PatientManager().Find(id);
            List<PatientEnrollment> patientEnrollments = new PatientTestManager().FindAllByPatientID(id).ToList();
            PatientRegistrationModel patientRegistration = new PatientRegistrationModel()
            {
                patient = patient,
                selectedTests = patientEnrollments.Select(p => p.Test).ToList()
            };

            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patientRegistration);
        }

        // GET: PatientRegistration/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            PatientRegistrationModel model = new PatientRegistrationModel();
            model.AllTests = dbTest.List();
            model.AllLabs = new LabManager().FindAll().ToList();
            return View(model);
        }

        // POST: PatientRegistration/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PatientRegistrationModel model)
        {
            try
            {
                // TODO: Add insert logic here
                db.Save(model.patient);
                db.AddTests(model.patient.ID, model.selectedTestIDs);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ex.Message.Trim();
                return View(model);
            }
        }

        // GET: PatientRegistration/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            PatientRegistrationModel model = new PatientRegistrationModel()
            {
                patient = db.Find(id),
                AllTests = dbTest.List(),
                AllLabs = dbLab.List(),
                selectedTests = db.ListAllPatientRegistrations(id).Select(p => p.Test).ToList()
            };
            model.patient.Gender = model.patient.Gender.Trim();
            model.selectedTestIDs = model.selectedTests.Select(p => p.ID).ToList();
            return View(model);
        }

        // POST: PatientRegistration/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PatientRegistrationModel model)
        {
            try
            {
                // TODO: Add update logic here
                if (model.selectedTestIDs != null)
                    db.EditTests(id, model.selectedTestIDs);
                db.Modify(model.patient);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: PatientRegistration/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            Patient patient = new PatientManager().Find(id);
            List<PatientEnrollment> patientEnrollments = new PatientTestManager().FindAllByPatientID(id).ToList();
            PatientRegistrationModel patientRegistration = new PatientRegistrationModel()
            {
                patient = patient,
                selectedTests = patientEnrollments.Select(p => p.Test).ToList()
            };

            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patientRegistration);
        }

        // POST: PatientRegistration/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                db.DeleteAllTests(id);
                db.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
