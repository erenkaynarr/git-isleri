using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {

        private readonly JwtAuthenticationManager jwtAuthenticationManager;
        public CarController(JwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }
        
        
        
        

        [Authorize]
        [HttpGet(Name = "GetCar")]
        public ActionResult GetCars()
        {
            Car[] cars =
            {
                new()
                {
                    Factory="Mercedes",WheelProduction=831,EngineProduction=225,DoorProduction=224
                },
                new()
                {
                    Factory="Audi",WheelProduction=446,EngineProduction=179,DoorProduction=548
                },
                new()
                {
                    Factory="BMW",WheelProduction=168,EngineProduction=134,DoorProduction=221
                },
                new()
                {
                    Factory="Ferrari",WheelProduction=650,EngineProduction=217,DoorProduction=100
                }

            };
            return Ok(cars);
        }

        [AllowAnonymous]
        [HttpPost("Authorize")]
        public IActionResult AuthUser([FromBody] User usr)
        {
            var token = jwtAuthenticationManager.Authenticate(usr.UserName, usr.Password);
            if(token == null)
            {
                return Unauthorized();
            }
            
            return Ok(token);
        }
    }
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}