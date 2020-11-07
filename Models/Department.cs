using DemoWebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DemoWebAPI.Models
{
    public class Department
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDDE { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<Employee> Employees { get; set; }
    }
}