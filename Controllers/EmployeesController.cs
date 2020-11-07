using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Description;
using DemoWebAPI.DBContextLayer;

namespace DemoWebAPI.Controllers
{
    [RoutePrefix("ok")]
    public class EmployeesController : ApiController
    {
        private DBContextKinhDoanh db = new DBContextKinhDoanh();

        // GET: api/Employees
      
        [Route("chon")]
        [BasicAuthentication]
        public IHttpActionResult Getemployees()
        {
          // string username = Thread.CurrentPrincipal.Identity.Name;
            using (DBContextKinhDoanh entities = new DBContextKinhDoanh())
            {
                //switch (username.ToLower())
               // {
                  //  case "nam":
                        return Ok(entities.employees.ToList());
                           
                    
                  //  default:
                      //  return NotFound();
               // }
            }
        }
        [Route("huy")]
        public IHttpActionResult Getemployeesok()
        {
            
            using (DBContextKinhDoanh entities = new DBContextKinhDoanh())
            {
                
                        return Ok(entities.employees.ToList());


                   
                
            }
        }

        // GET: api/Employees/5
        [ResponseType(typeof(Employee))]
        public IHttpActionResult GetEmployee(int id)
        {
            Employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT: api/Employees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployee(int id, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.ID)
            {
                return BadRequest();
            }

            db.Entry(employee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Employees
        [ResponseType(typeof(Employee))]
        public IHttpActionResult PostEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.employees.Add(employee);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employee.ID }, employee);
        }

        // DELETE: api/Employees/5
        [ResponseType(typeof(Employee))]
        public IHttpActionResult DeleteEmployee(int id)
        {
            Employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            db.employees.Remove(employee);
            db.SaveChanges();

            return Ok(employee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeExists(int id)
        {
            return db.employees.Count(e => e.ID == id) > 0;
        }
    }
}