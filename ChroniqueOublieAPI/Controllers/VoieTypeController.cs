using ChroniqueOublieAPI.Models.Maitrise.Type;
using ChroniqueOublieAPI.Models.Voie.Type;
using ChroniqueOublieAPI.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ChroniqueOublieAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Voie/Type")]
    public class VoieTypeController : Controller
    {
        private readonly IVoieTypeServiceInterface voieTypeService;

        public VoieTypeController(IVoieTypeServiceInterface voieTypeService)
        {
            this.voieTypeService = voieTypeService;
        }

        // GET: api/Maitrise/type
        [HttpGet]
        public IEnumerable<VoieTypeDTO> GetAll()
        {
            return this.voieTypeService.ReadAll();
        }

        // GET: api/Maitrise/type/5
        [HttpGet("{id}")]
        public VoieTypeDTO Get(int id)
        {
            VoieTypeDTO voieTypeDto = new VoieTypeDTO();
            voieTypeDto.Id = id;
            return this.voieTypeService.ReadById(voieTypeDto);
        }

        // POST: api/Maitrise/type
        [HttpPost]
        public VoieTypeDTO Post([FromBody]VoieTypeDTO voieTypeDto)
        {
            return this.voieTypeService.Create(voieTypeDto);
        }

        // PUT: api/Maitrise/type/5
        [HttpPut("{id}")]
        public VoieTypeDTO Put(int id, [FromBody]VoieTypeDTO voieTypeDto)
        {
            voieTypeDto.Id = id;
            return this.voieTypeService.Update(voieTypeDto);
        }

        // DELETE: api/Maitrise/type/5
        [HttpDelete("{id}")]
        public VoieTypeDTO Delete(int id)
        {
            VoieTypeDTO voieTypeDto = new VoieTypeDTO();
            voieTypeDto.Id = id;
            return this.voieTypeService.Delete(voieTypeDto);
        }
    }
}