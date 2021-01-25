using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientManagementDAL;

namespace PatientManagementDAL
{
    public class LabManager : IEntityManager<Lab>
    {
        PatientDBEntities db = new PatientDBEntities();
        public IQueryable<Lab> FindAll(bool onlyActive = true)
        {
            return onlyActive ? this.db.Labs.Where(p => p.IsActive == onlyActive) : this.db.Labs;
        }

        public Lab Find(int id)
        {
            return this.db.Labs.Find(id);
        }

        public void Save(Lab lab)
        {
            this.db.Labs.Add(lab);
            this.db.SaveChanges();
        }

        public void Modify(Lab lab)
        {
            db.Entry(lab).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Lab lab = this.Find(id);
            db.Labs.Remove(lab);
            db.SaveChanges();
        }

        public void Dispose()
        {
            this.db.Dispose();
        }
    }
}
