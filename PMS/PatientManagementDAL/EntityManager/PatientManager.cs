using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientManagementDAL;

namespace PatientManagementDAL
{
    public class PatientManager : IEntityManager<Patient>
    {
        PatientDBEntities db = new PatientDBEntities();
        public IQueryable<Patient> FindAll(bool onlyActive = true)
        {
            return onlyActive ? this.db.Patients.Where(p => p.IsActive == onlyActive) : this.db.Patients;
        }

        public Patient Find(int id)
        {
            return this.db.Patients.Find(id);
        }

        public void Save(Patient patient)
        {
            this.db.Patients.Add(patient);
            this.db.SaveChanges();
        }

        public void Modify(Patient patient)
        {
            db.Entry(patient).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Patient patient = this.Find(id);
            db.Patients.Remove(patient);
            db.SaveChanges();
        }

        public void Dispose()
        {
            this.db.Dispose();
        }
    }
}
