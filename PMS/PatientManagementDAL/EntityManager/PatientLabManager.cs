using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientManagementDAL;

namespace PatientManagementDAL
{
    public class PatientTestManager : IEntityManager<PatientEnrollment>
    {
        PatientDBEntities db = new PatientDBEntities();
        public IQueryable<PatientEnrollment> FindAll(bool onlyActive = true)
        {
            return onlyActive ? this.db.PatientEnrollments.Where(p => p.IsActive == onlyActive) : this.db.PatientEnrollments;
        }

        public IQueryable<PatientEnrollment> FindAllByPatientID(int patientID)
        {
            return this.db.PatientEnrollments.Where(p => p.PatientID == patientID && p.IsActive == true);
        }

        public PatientEnrollment Find(int id)
        {
            return this.db.PatientEnrollments.Find(id);
        }

        public void Save(PatientEnrollment patientEnrollment)
        {
            this.db.PatientEnrollments.Add(patientEnrollment);
            this.db.SaveChanges();
        }

        public void Modify(PatientEnrollment patientEnrollment)
        {
            db.Entry(patientEnrollment).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteEnrolementByID(int patientID, int testID)
        {
            PatientEnrollment patientEnrollment = db.PatientEnrollments.Where(p => p.PatientID == patientID && p.TestID == testID).FirstOrDefault();
            Delete(patientEnrollment.ID);
        }
        public void DeleteAllEnrolementByID(int patientID)
        {
            List<PatientEnrollment> patientEnrollments = db.PatientEnrollments.Where(p => p.PatientID == patientID).ToList();
            patientEnrollments.ForEach(p=>Delete(p.ID));
        }

        public void AddEnrolementByID(int patientID, int testID)
        {
            PatientEnrollment patientEnrollment = new PatientEnrollment();
            patientEnrollment.PatientID = patientID;
            patientEnrollment.TestID = testID;
            patientEnrollment.EnrolledOn = DateTime.Now;
            patientEnrollment.IsActive = true;
            Save(patientEnrollment);
        }

        public void Delete(int id)
        {
            PatientEnrollment patientEnrollment = this.Find(id);
            db.PatientEnrollments.Remove(patientEnrollment);
            db.SaveChanges();
        }

        public void Dispose()
        {
            this.db.Dispose();
        }
    }
}
