using PatientManagementBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientManagementDAL;
namespace PatientManagementBusiness
{
    public interface IPatientRegistrationBL
    {
        void Save(Patient patient);
        List<Patient> List();
        void Modify(Patient patient);
        void Delete(int id);
        void AddTests(int patientID, List<int> testIDs);
        void RemovePatientTests(int patientID, List<int> testIDs);
        Patient Find(int id);
    }
}
