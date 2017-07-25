using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VisualTraining.Models.Database;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net.Http;
using VisualTraining.Models;

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

        //public ActionResult VisionTraining()
        //{

        //    return View();
        //}

        public ActionResult VisionTraining(int? diagnosisId)
        {
            if (diagnosisId != null)
            {
                using (var db = new VisualTraining.Models.Database.VisualTrainingModel())
                {
                    Diagnosis diagnosis = db.Diagnoses.Include(X => X.Patient).FirstOrDefault(x => x.DiagnosisID == diagnosisId);
                    // ViewBag.Diagnosis = diagnosis;

                    return View(diagnosis);
                }
            }
            else
                return View();
        }

        public ActionResult Browser()
        {
            using (var db = new VisualTraining.Models.Database.VisualTrainingModel())
            {
                List<Diagnosis> diagnosis = db.Diagnoses.Include(X => X.Patient).ToList();
                ViewBag.Diagnosis = diagnosis;
            }
            return View();
        }

        public ActionResult SavePatientDetail(string patientName, string optometrist, string dob, int numberOfSession, int? diagnosisId)
        {
            using (var db = new VisualTraining.Models.Database.VisualTrainingModel())
            {
                DateTime dateOfBirth = DateTime.Parse(dob);
                if (diagnosisId == null)
                {
                    //convert the dob to datetime

                    //check if the patient is already in the database
                    var patient = db.Patients.FirstOrDefault(x => x.DOB == dateOfBirth && x.Name.Equals(patientName, StringComparison.CurrentCultureIgnoreCase));
                    if (patient == null)
                    {
                        patient = new Models.Database.Patient();
                        patient.Name = patientName;
                        patient.DOB = dateOfBirth;
                        db.Patients.Add(patient);
                    }

                    Diagnosis diagnosi = new Diagnosis();
                    diagnosi.NoOfSession = numberOfSession;
                    diagnosi.Optometrist = optometrist;
                    diagnosi.PatientID = patient.PatientID;
                    db.Diagnoses.Add(diagnosi);

                    int result = db.SaveChanges();
                    if (result > 0)
                        return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    Diagnosis diagnosis = db.Diagnoses.Include(X => X.Patient).FirstOrDefault(x => x.DiagnosisID == diagnosisId);
                    diagnosis.Patient.Name = patientName;
                    diagnosis.Patient.DOB = dateOfBirth;
                    diagnosis.NoOfSession = numberOfSession;
                    diagnosis.Optometrist = optometrist;
                    int result = db.SaveChanges();
                    //  if (result > 0)
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }


            }

            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveConditions(ConditionsModel selectedCondition)
        {
            using (var db = new VisualTraining.Models.Database.VisualTrainingModel())
            {
                var conditionLines = db.ConditionLines.Where(x => x.DiagnosisID == selectedCondition.DiagnosisId).ToList();
                //foreach(var conditionId in selectedCondition.SelectedConditions)
                //{
                    
                //}

                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
        }

        //public ActionResult Get

    }
}