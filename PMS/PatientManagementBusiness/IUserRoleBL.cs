using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientManagementDAL;

namespace PatientManagementBusiness
{
    public interface IUserRoleBL
    {        
        string GetRoleForUser(string username);
    }
}
