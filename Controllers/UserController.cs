using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TurboNg_API.Data;
using TurboNg_API.Models;

namespace TurboNg_API.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContextClass appDbContextClass;

        public UserController(AppDbContextClass context)
        {
            appDbContextClass = context;
        }

        [HttpPost]
        [Route("api/user/add")]
        public IActionResult CreateUser(UserEntity userEntity)
        {
            if(userEntity != null)
            {
                //To check whether the username is already exist in DB
                var userNameExists = appDbContextClass.UserMaster.Where(e => (e.Name.ToLower() == userEntity.Name.ToLower()) && (e.IsActive == true)).ToList();
                if (userNameExists.Count == 0)
                {
                    appDbContextClass.UserMaster.Add(userEntity);
                    appDbContextClass.SaveChanges();
                    return Created(string.Empty, new { statusCode = 201, Message = "User name already exists" });
                }
                else
                {
                    return Ok(new { statusCode = 200, Message = "User name already exists" });
                }
            }
            else
            {
                return BadRequest(new { statusCode = 400, Message = "Form is null. Please enter data" });
            }
        }
    }
}
