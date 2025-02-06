using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Roshtaty.Core.Entites;
using Roshtaty.Core.Repositories;
using Roshtaty.Core.Specifications;

namespace Roshtaty.Controllers
{

    public class Main_SystemsController : ApiBaseController
    {
        private readonly IGenericRepository<Main_System> _mainsystemrepo;

        public Main_SystemsController(IGenericRepository<Main_System> mainsystemrepo)
        {
            _mainsystemrepo = mainsystemrepo;
        }
        //GET ALL MainSystem

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Main_System>>>GetMainSystems()
        {
            var specs = new BaseSpecifications<Main_System>();
            var mainsystems = await _mainsystemrepo.GetAllWithSpcsAsync(specs);
            return Ok(mainsystems);
        }

        //GET_BYID

        [HttpGet("{id}")]
        public async Task<ActionResult<Main_System>> GetMainSystems(int id)
        {
            var specs = new BaseSpecifications<Main_System>();
            var mainsystems = await _mainsystemrepo.GetByIdWithSpcsAsync(specs);
            return Ok (mainsystems);
        }

        
    }
}
