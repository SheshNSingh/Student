using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientManagementDAL;

namespace PatientManagementDAL
{
    public class TestManager : IEntityManager<Test>
    {
        PatientDBEntities db = new PatientDBEntities();
        public IQueryable<Test> FindAll(bool onlyActive = true)
        {
            return onlyActive ? this.db.Tests.Where(p => p.IsActive == onlyActive) : this.db.Tests;
        }

        public IQueryable<PatientEnrollment> FindActivePatients(int testID)
        {
            return this.db.PatientEnrollments.Where(p => p.TestID == testID);
        }

        public Test Find(int id)
        {
            return this.db.Tests.Find(id);
        }

        public void Save(Test test)
        {
            this.db.Tests.Add(test);
            this.db.SaveChanges();
        }

        public void Modify(Test test)
        {
            db.Entry(test).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Test test = this.Find(id);
            if (db.Entry(test).State == EntityState.Detached)
                db.Tests.Attach(test);
            db.Tests.Remove(test);
            db.SaveChanges();
        }

        public void Dispose()
        {
            this.db.Dispose();
        }
    }
}
