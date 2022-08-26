using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rolebased.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace rolebased.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        // GET: api/<DepartmentsController>
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public IEnumerable<Department> Get()
        {
            using (var context = new RoleBasedContext())
            {
                return context.Departments.ToList();
            }
        }

        // GET api/<DepartmentsController>/5
        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public ActionResult<Department> Get(int id)
        {
            using (var context = new RoleBasedContext())
            {
                var data = context.Departments.Where(data => data.Id == id).FirstOrDefault();

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
    }
}
