using DemoWebAPI.DBContextLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoWebAPI.Controllers
{
    public class EmployeeSecurity
    {
        public static bool Login(string username, string password)
        {
            using (DBContextKinhDoanh entities = new DBContextKinhDoanh())
            {
                return entities.users.Any(user =>
                       user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase)
                                          && user.PassWork == password);
            }
        }
    }
}