using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VisualTraining.Models.Database;
using System.Web.Mvc;
using System.Data.Entity;

namespace VisualTraining.Controllers
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

        public ActionResult VisionTraining()
        {

            return View();
        }

        public ActionResult Browser()
        {
            using (var db = new VisualTraining.Models.Database.VisualTrainingModel())
            {
                var diagnosis = db.Diagnosis.Include(X => X.Patient).ToList();
                ViewBag.Diagnosis = diagnosis;
            }
            return View();
        }

        public ActionResult SavePatientDetail(string patientName, string optometrist, string dob, int numberOfSession)
        {
            using (var db = new VisualTraining.Models.Database.VisualTrainingModel())
            {
                //convert the dob to datetime
                DateTime dateOfBirth = DateTime.Parse(dob);
                //check if the patient is already in the database
                var patient = db.Patients.FirstOrDefault(x => x.DOB == dateOfBirth && x.Name.Equals(patientName, StringComparison.CurrentCultureIgnoreCase));
                if (patient == null)
                {
                    patient = new Models.Database.Patient();
                    patient.Name = patientName;
                    patient.DOB = dateOfBirth;
                    db.Patients.Add(patient);
                }

                Diagnosi diagnosi = new Diagnosi();
                diagnosi.NoOfSession = numberOfSession;
                diagnosi.PatientID = patient.PatientID;
                db.Diagnosis.Add(diagnosi);

                int result = db.SaveChanges();
                if (result > 0)
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);


            }

            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult Get

    }
}