using PatientManagementBusiness.Models;
using PatientManagementDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementBusiness
{
    public class PatientRegistrationBL : IPatientRegistrationBL
    {
        private PatientManager patientManager;
        private PatientTestManager patientTestManager;


        public PatientRegistrationBL()
        {
            patientManager = new PatientManager();
            patientTestManager = new PatientTestManager();
        }

        public void Save(Patient patient)
        {
            patientManager.Save(patient);            
        }

        public List<Patient> List()
        {
            return patientManager.FindAll().ToList();
        }

        public List<PatientEnrollment> ListAllPatientRegistrations(int patientID)
        {
            return patientTestManager.FindAllByPatientID(patientID).ToList();
        }

        public Patient Find(int id)
        {
            return patientManager.Find(id);
        }

        public void Modify(Patient patient)
        {
            patientManager.Modify(patient);
        }

        public void AddTests(int patientID, List<int> testIDs)
        {
            foreach(int testID in testIDs)
            {
                patientTestManager.AddEnrolementByID(patientID, testID);
            }
        }
        public void EditTests(int patientID, List<int> testIDs)
        {
            patientTestManager.DeleteAllEnrolementByID(patientID);
            foreach (int testID in testIDs)
            {
                patientTestManager.AddEnrolementByID(patientID, testID);
            }
        }

        public void DeleteAllTests(int patientID)
        {
            patientTestManager.DeleteAllEnrolementByID(patientID);           
        }

        public void RemovePatientTests(int patientID, List<int> testIDs)
        {
            foreach (int testID in testIDs)
            {
                patientTestManager.DeleteEnrolementByID(patientID, testID);
            }
        }

        public void Delete(int id)
        {
            patientManager.Delete(id);
        }


         // PatientRegistration 


    }
}
