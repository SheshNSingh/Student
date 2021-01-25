using PatientManagementBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientManagementDAL;

namespace PatientManagementBusiness
{
    public interface ILabManagerBL
    {
        void Save(Lab lab);
        List<Lab> List();
        void Modify(Lab lab);
        void Delete(int id);
        Lab Find(int id);
    }
}
