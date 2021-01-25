using PatientManagementBusiness.Models;
using PatientManagementDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementBusiness
{
    public class LabManagerBL : ILabManagerBL
    {
        private LabManager labManager;
        public LabManagerBL()
        {
            labManager = new LabManager();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Lab Find(int id)
        {
            return labManager.Find(id);
        }

        public List<Lab> List()
        {
            return labManager.FindAll().ToList();
        }

        public void Modify(Lab lab)
        {
            throw new NotImplementedException();
        }

        public void Save(Lab lab)
        {
            throw new NotImplementedException();
        }
    }
}
