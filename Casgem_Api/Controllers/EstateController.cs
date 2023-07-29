
using DataAccessLayer.Abstract;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System;
using System.Xml.Linq;

namespace Casgem_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateController : ControllerBase
    {
        private readonly IEstateService _estateService;

        public EstateController(IEstateService estateService)
        {
            _estateService = estateService;
        }

        [HttpGet("Listeleme")]
        public ActionResult<List<Estate>> GetListAll()
        {
            return _estateService.GetListAll();
        }

        [HttpGet("GetByID")]
        public ActionResult<Estate> GetById(string id)
        {
            var essate = _estateService.GetById(id);
            

            return essate;
        }
        [HttpPost("Ekleme")]
        public ActionResult<Estate> Post([FromBody] Estate estate)
        {
            estate.Id = ObjectId.GenerateNewId().ToString();
            _estateService.Insert(estate);

            return CreatedAtAction(nameof(GetById), new { id = estate.Id }, estate);
        }


        [HttpPut("Güncelleme")]
        public ActionResult Put(string id, [FromBody] Estate estate)
        {
            var existingEssate = _estateService.GetById(id);
         

            _estateService.Update(id, estate);
            return NoContent();
        }

        [HttpDelete("Silme")]
        public ActionResult Delete(string id)
        {
            var essate = _estateService.GetById(id);
          

            _estateService.Delete(essate.Id);
            return Ok();
        }



    }
}
