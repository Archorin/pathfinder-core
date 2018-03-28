using ChroniqueOublieAPI.Models.Voie.Profil;
using ChroniqueOublieAPI.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ChroniqueOublieAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Voie/Profil")]
    public class ProfilController : Controller
    {
        private readonly IProfilServiceInterface profilService;

        public ProfilController(IProfilServiceInterface profilService)
        {
            this.profilService = profilService;
        }

        // GET: api/Profil
        [HttpGet]
        public IEnumerable<ProfilDTO> GetAll()
        {
            return this.profilService.ReadAll();
        }

        // GET: api/Profil/5
        [HttpGet("{id}")]
        public ProfilDTO Get(int id)
        {
            ProfilDTO profilDto = new ProfilDTO();
            profilDto.Id = id;
            return this.profilService.ReadById(profilDto);
        }

        // POST: api/Profil
        [HttpPost]
        public ProfilDTO Post([FromBody]ProfilDTO profilDto)
        {
            return this.profilService.Create(profilDto);
        }

        // PUT: api/Profil/5
        [HttpPut("{id}")]
        public ProfilDTO Put(int id, [FromBody]ProfilDTO profilDto)
        {
            profilDto.Id = id;
            return this.profilService.Update(profilDto);
        }

        // DELETE: api/Profil/5
        [HttpDelete("{id}")]
        public ProfilDTO Delete(int id)
        {
            ProfilDTO profilDto = new ProfilDTO();
            profilDto.Id = id;
            return this.profilService.Delete(profilDto);
        }
    }
}