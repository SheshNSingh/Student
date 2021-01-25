using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagementDAL.EntityManager
{
    public class UserRoleManager
    {
        PatientDBEntities db = new PatientDBEntities();
        public string GetRoleForUser(string userName)
        {
            var userRole = db.Users.Where(p => p.UserName == userName).FirstOrDefault().Role.RoleName;
            return userRole.Trim();
        }
        public User GetUser(string userName)
        {
            var user = db.Users.Where(p => p.UserName == userName).FirstOrDefault();
            return user;
        }

        public bool Validate(string userName, string hashedPassword)
        {
            return db.Users.Where(p => p.UserName == userName && p.Password==hashedPassword).Any();          
        }

        public void Dispose()
        {
            this.db.Dispose();
        }
    }
}
