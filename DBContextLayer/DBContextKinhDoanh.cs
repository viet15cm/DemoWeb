using DemoWebAPI.Controllers;
using DemoWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace DemoWebAPI.DBContextLayer
{
    public class DBContextKinhDoanh : DbContext
    {
        public  DBContextKinhDoanh() : base("name=QLKD")
        {
        }

        public DbSet<User> users { get; set; }

        public DbSet<Employee> employees { get; set; }
        public DbSet<Department> departments { get; set; }
    }
}