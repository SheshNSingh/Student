using PatientManagementBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientManagementDAL;

namespace PatientManagementBusiness
{
    public interface ITestManagerBL
    {
        void Save(Test test);
        List<Test> List();
        void Modify(Test test);
        void Delete(int id);
        Test Find(int id);
    }
}
