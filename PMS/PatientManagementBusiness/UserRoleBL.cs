using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientManagementDAL;
using PatientManagementDAL.EntityManager;

namespace PatientManagementBusiness
{
    public class UserRoleBL :IUserRoleBL
    {
        private UserRoleManager userRoleManager;
        public UserRoleBL()
        {
            userRoleManager = new UserRoleManager();
        }
        public string GetRoleForUser(string userName)
        {
            return userRoleManager.GetRoleForUser(userName);
        }

        public User GetUser(string userName)
        {
            return userRoleManager.GetUser(userName);
        }

        public bool ValidateUser(string userName, string password)
        {
            return userRoleManager.Validate(userName, password);
        }
    }
}
