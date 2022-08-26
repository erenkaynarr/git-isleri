using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rolebased.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace rolebased.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelsController : ControllerBase
    {
        // GET: api/<PersonelsController>
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator,SatinAlimDepartmani,Standard")]
        public IEnumerable<Personel> Get()
        {
            using (var context = new RoleBasedContext())
            {
                return context.Personels.ToList();
            }
        }

        // GET api/<PersonelsController>/5
        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator,SatinAlimDepartmani,Standard")]
        public ActionResult<Personel> Get(int id)
        {
            using (var context = new RoleBasedContext())
            {
                var data = context.Personels.Where(data => data.PersonelId == id).FirstOrDefault();

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

        // POST api/<PersonelsController>
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator,SatinAlimDepartmani,Standard")]
        public  ActionResult<Personel> Post(Personel personels)
        {
            using  (var context = new RoleBasedContext())
            {
                if(personels != null && personels.PersonelName != null)
                {
                    context.Personels.Add(personels);
                    context.SaveChanges();
                    return Ok("Personel added");
                }
                else
                {
                    return BadRequest();
                }
            }
            
        }

        // PUT api/<PersonelsController>/5
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator,SatinAlimDepartmani,Standard")]
        public ActionResult<Personel> Put(int id,Personel personels)
        {
            using (var context =new RoleBasedContext())
            {
                var data = context.Personels.Where(data => data.PersonelId==id).FirstOrDefault();

                if(data == null)
                {
                    return NotFound();
                }
                else
                {
                    data.PersonelName = personels.PersonelName;
                    data.PersonelSurname = personels.PersonelSurname;
                    try
                    {
                        context.Personels.Update(data);
                        context.SaveChanges();
                        return personels;
                    }
                    catch(Exception)
                    {
                        return NotFound();
                    }
                }
            }
        }

        // DELETE api/<PersonelsController>/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator,SatinAlimDepartmani,Standard")]
        public ActionResult<Personel> Delete(int id)
        {
            using (var context = new RoleBasedContext())
            {
                var data = context.Personels.Where(data => data.PersonelId == id).FirstOrDefault();
                if (data == null)
                {
                    return NotFound();
                }
                else
                {
                    context.Personels.Remove(data);
                    context.SaveChanges();
                    return data;
                }
            }
        }
    }
}
