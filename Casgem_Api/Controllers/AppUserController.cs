using DataAccessLayer.Abstract;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Casgem_API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserService _userService;

        public AppUserController(IAppUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("Listeleme")]
        public ActionResult<List<AppUser>> GetListAll()
        {
            return _userService.GetListAll();
        }

        [HttpGet("ID'ya Göre")]
        public ActionResult<AppUser> GetById(string id)
        {
            var user = _userService.GetById(id);

            return user;
        }

        [HttpPost("Ekleme")]
        public ActionResult<AppUser> Post([FromBody] AppUser user)
        {
            user.Id = ObjectId.GenerateNewId().ToString();
            _userService.Insert(user);

            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        [HttpPut("Güncelleme")]
        public ActionResult Put(string id, [FromBody] AppUser user)
        {
            var existingEssate = _userService.GetById(id);


            _userService.Update(id, user);
            return NoContent();
        }

        [HttpDelete("delete")]
        public ActionResult Delete(string id)
        {
            var essate = _userService.GetById(id);


            _userService.Delete(essate.Id);
            return Ok($"User with id = {id} deleted");
        }

        [HttpGet("filter")]
        public ActionResult<List<AppUser>> GetByFilter([FromQuery] string? userName = null)
        {
            var user = _userService.GetByFilter(userName);


            return Ok(user);
        }
    }
}