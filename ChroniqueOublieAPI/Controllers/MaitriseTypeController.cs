using ChroniqueOublieAPI.Models.Maitrise.Type;
using ChroniqueOublieAPI.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ChroniqueOublieAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Maitrise/Type")]
    public class MaitriseTypeController : Controller
    {
        private readonly IMaitriseTypeServiceInterface maitriseTypeService;

        public MaitriseTypeController(IMaitriseTypeServiceInterface maitriseTypeService)
        {
            this.maitriseTypeService = maitriseTypeService;
        }

        // GET: api/Maitrise/type
        [HttpGet]
        public IEnumerable<MaitriseTypeDTO> GetAll()
        {
            return this.maitriseTypeService.ReadAll();
        }

        // GET: api/Maitrise/type/5
        [HttpGet("{id}")]
        public MaitriseTypeDTO Get(int id)
        {
            MaitriseTypeDTO maitriseTypeDto = new MaitriseTypeDTO();
            maitriseTypeDto.Id = id;
            return this.maitriseTypeService.ReadById(maitriseTypeDto);
        }

        // POST: api/Maitrise/type
        [HttpPost]
        public MaitriseTypeDTO Post([FromBody]MaitriseTypeDTO maitriseTypeDto)
        {
            return this.maitriseTypeService.Create(maitriseTypeDto);
        }

        // PUT: api/Maitrise/type/5
        [HttpPut("{id}")]
        public MaitriseTypeDTO Put(int id, [FromBody]MaitriseTypeDTO maitriseTypeDto)
        {
            maitriseTypeDto.Id = id;
            return this.maitriseTypeService.Update(maitriseTypeDto);
        }

        // DELETE: api/Maitrise/type/5
        [HttpDelete("{id}")]
        public MaitriseTypeDTO Delete(int id)
        {
            MaitriseTypeDTO maitriseTypeDto = new MaitriseTypeDTO();
            maitriseTypeDto.Id = id;
            return this.maitriseTypeService.Delete(maitriseTypeDto);
        }
    }
}