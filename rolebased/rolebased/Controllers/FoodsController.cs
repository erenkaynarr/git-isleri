using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rolebased.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace rolebased.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        // GET: api/<FoodsController>
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator,SatinAlimDepartmani")]
        public IEnumerable<Food> Get()
        {
            using (var context = new RoleBasedContext())
            {
                return context.Foods.ToList();
            }
        }

        // GET api/<FoodsController>/5
        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator,SatinAlimDepartmani")]
        public ActionResult<Food> Get(int id)
        {
            using (var context = new RoleBasedContext())
            {
                var classes = context.Foods.Where(data => data.FoodId == id).FirstOrDefault();

                if (classes == null)
                {
                    return NotFound();
                }
                else
                {
                    return classes;
                }
            }
        }

        // POST api/<FoodsController>
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator,SatinAlimDepartmani")]
        public ActionResult<Food> Post(Food foods)
        {
            using (var context = new RoleBasedContext())
            {
                if (foods != null && foods.FoodName != null)
                {
                    context.Foods.Add(foods);
                    context.SaveChanges();
                    return Ok("Food added");
                }
                else
                {
                    return BadRequest();
                }
            }

        }

        // PUT api/<FoodsController>/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator,SatinAlimDepartmani")]
        public ActionResult<Food> Put(int id,Food foods)
        {
            using (var context = new RoleBasedContext())
            {
                var data = context.Foods.Where(data => data.FoodId == id).FirstOrDefault();

                if (data == null)
                {
                    return NotFound();
                }
                else
                {
                    data.FoodName = foods.FoodName;
                    data.FoodPrice = foods.FoodPrice;
                    try
                    {
                        context.Foods.Update(data);
                        context.SaveChanges();
                        return foods;
                    }
                    catch (Exception)
                    {
                        return NotFound();
                    }
                }
            }
        }

        // DELETE api/<FoodsController>/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator,SatinAlimDepartmani")]
        public ActionResult<Food> Delete(int id)
        {
            using (var context = new RoleBasedContext())
            {
                var data = context.Foods.Where(data => data.FoodId == id).FirstOrDefault();
                if (data == null)
                {
                    return NotFound();
                }
                else
                {
                    context.Foods.Remove(data);
                    context.SaveChanges();
                    return data;
                }
            }
        }
    }
}
