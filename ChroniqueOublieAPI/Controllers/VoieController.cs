using ChroniqueOublieAPI.Models.Voie;
using ChroniqueOublieAPI.Models.Voie.Type;
using ChroniqueOublieAPI.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ChroniqueOublieAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Voie")]
    public class VoieController : Controller
    {
        private readonly IVoieServiceInterface voieService;

        public VoieController(IVoieServiceInterface voieService)
        {
            this.voieService = voieService;
        }

        // GET: api/Voie/5
        [HttpGet("{id}")]
        public VoieDTO Get(int id)
        {
            VoieDTO voieDto = new VoieDTO();
            voieDto.Id = id;
            return this.voieService.ReadById(voieDto);
        }

        // POST: api/Voie
        [HttpPost]
        public VoieDTO Post([FromBody]VoieDTO voieDto)
        {
            return this.voieService.Create(voieDto);
        }

        // PUT: api/Voie/5
        [HttpPut("{id}")]
        public VoieDTO Put(int id, [FromBody]VoieDTO voieDto)
        {
            voieDto.Id = id;
            return this.voieService.Update(voieDto);
        }

        // DELETE: api/Voie/5
        [HttpDelete("{id}")]
        public VoieDTO Delete(int id)
        {
            VoieDTO voieDto = new VoieDTO();
            voieDto.Id = id;
            return this.voieService.Delete(voieDto);
        }
    }
}