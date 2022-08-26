using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rolebased.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace rolebased.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        // GET: api/<CustomersController>
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator,SatinAlimDepartmani")]
        public IEnumerable<Customer> Get()
        {
            using (var context = new RoleBasedContext())
            {
                return context.Customers.ToList();
            }
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator,SatinAlimDepartmani")]
        public ActionResult<Customer> Get(int id)
        {
            using (var context = new RoleBasedContext())
            {
                var data = context.Customers.Where(data => data.CustomerId == id).FirstOrDefault();

                if (data == null)
                {
                    return NotFound();
                }
                else
                {
                    return data;
                }
            }
        }

        // POST api/<CustomersController>
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator,SatinAlimDepartmani")]
        public ActionResult<Customer> Post(Customer customers)
        {
            using (var context = new RoleBasedContext())
            {
                if (customers != null && customers.CustomerName != null)
                {
                    context.Customers.Add(customers);
                    context.SaveChanges();
                    return Ok("Customer added");
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator,SatinAlimDepartmani")]
        public ActionResult<Customer> Put(int id,Customer customers)
        {
            using (var context = new RoleBasedContext())
            {
                var data = context.Customers.Where(data => data.CustomerId == id).FirstOrDefault();

                if (data == null)
                {
                    return NotFound();
                }
                else
                {
                    data.CustomerName = customers.CustomerName;
                    data.CustomerSurname = customers.CustomerSurname;
                    try
                    {
                        context.Customers.Update(data);
                        context.SaveChanges();
                        return customers;
                    }
                    catch (Exception)
                    {
                        return NotFound();
                    }
                }
            }
        }
    }
}
