using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientManagementDAL;
namespace PatientManagementBusiness.Models
{
    public class PatientRegistrationModel
    {
        public Patient patient { get; set; }
        public List<Test> selectedTests { get; set; }

        public List<int> selectedTestIDs { get; set; }

        public List<Test> AllTests { get; set; }

        public List<Lab> AllLabs { get; set; }

    }
}
