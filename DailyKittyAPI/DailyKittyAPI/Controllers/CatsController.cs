using DailyKittyAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DailyKittyAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "dailykittyapp", IgnoreApi = false)]
    public class CatsController : Controller
    {
        private DailyKittyDBContext _context;
        public CatsController(DailyKittyDBContext context) 
        {
            _context = context;
        }

        [HttpGet("getcatsforuser/{userId}")]
        public ActionResult<IList<Cat>> GetCatsForUser (int userId)
        {
            try
            {
                var user = _context.Users.Single(user => user.Id == userId);

                //check whether user exists
                if (user == null)
                    return NotFound("Error: User with Id: " + userId.ToString() + " not found.");

                if (user.Banned != null)
                    return Unauthorized("Error: User is banned.");

                var cats = _context.Cats.Where(c => c.Id == userId).Where(c => c.Removed == null).ToList();

                if (cats == null || !cats.Any())
                    return NoContent();

                return new OkObjectResult(cats);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("createcat")]
        public ActionResult<Cat> CreateCat([FromBody]Cat catPrototype)
        {
            try
            {
                //todo check banned user and existence

                catPrototype.Id = 0;
                catPrototype.UserId = 0;//todo current user
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
