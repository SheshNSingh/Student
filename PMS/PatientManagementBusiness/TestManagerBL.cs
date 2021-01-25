using PatientManagementBusiness.Models;
using PatientManagementDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementBusiness
{
    public class TestManagerBL : ITestManagerBL
    {
        PatientDBEntities db = new PatientDBEntities();
        private TestManager testManager;
        public TestManagerBL()
        {
            testManager = new TestManager();
        }
        public void Delete(int id)
        {
            testManager.Delete(id);
        }

        public Test Find(int id)
        {
            return testManager.Find(id);
        }

        public List<Test> List()
        {
            return testManager.FindAll().ToList();
        }

        public void Modify(Test test)
        {
            db.Entry(test).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Save(Test test)
        {
            this.db.Tests.Add(test);
            this.db.SaveChanges();
        }
    }
}
