using ChroniqueOublieAPI.Models.Maitrise;
using ChroniqueOublieAPI.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ChroniqueOublieAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Maitrise")]
    public class MaitriseController : Controller
    {
        private readonly IMaitriseServiceInterface maitriseService;

        public MaitriseController(IMaitriseServiceInterface maitriseService)
        {
            this.maitriseService = maitriseService;
        }

        // GET: api/Maitrise/5
        [HttpGet("{id}")]
        public MaitriseDTO Get(int id)
        {
            MaitriseDTO maitriseDto = new MaitriseDTO();
            maitriseDto.Id = id;
            return this.maitriseService.ReadById(maitriseDto);
        }

        // POST: api/Maitrise
        [HttpPost]
        public MaitriseDTO Post([FromBody]MaitriseDTO maitriseDto)
        {
            return this.maitriseService.Create(maitriseDto);
        }

        // PUT: api/Maitrise/5
        [HttpPut("{id}")]
        public MaitriseDTO Put(int id, [FromBody]MaitriseDTO maitriseDto)
        {
            maitriseDto.Id = id;
            return this.maitriseService.Update(maitriseDto);
        }

        // DELETE: api/Maitrise/5
        [HttpDelete("{id}")]
        public MaitriseDTO Delete(int id)
        {
            MaitriseDTO maitriseDto = new MaitriseDTO();
            maitriseDto.Id = id;
            return this.maitriseService.Delete(maitriseDto);
        }
    }
}