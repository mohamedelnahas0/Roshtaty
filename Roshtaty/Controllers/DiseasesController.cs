using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Roshtaty.Core.Entites;
using Roshtaty.Core.Repositories;
using Roshtaty.Core.Specifications;
using Roshtaty.DTOS;

namespace Roshtaty.Controllers
{
 
    public class DiseasesController : ApiBaseController
    {
        private readonly IGenericRepository<Disease> _diseseRepo;
        private readonly IMapper _mapper;

        public DiseasesController(IGenericRepository<Disease> DiseseRepo , IMapper mapper)
        {
            _diseseRepo = DiseseRepo;
            _mapper = mapper;
        }
        //GET ALL Diseases

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Disease>>> GetDiseases()
        {
            var Specs = new DiseasesSpecifications();
            var Diseases = await _diseseRepo.GetAllWithSpcsAsync(Specs);
            var MappedDiseases = _mapper.Map<IEnumerable<Disease>, IEnumerable<DiseasesToReturnDTO>>(Diseases);

            return Ok(MappedDiseases);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Disease>> GetDiseases(int id)
        {
            var specs = new DiseasesSpecifications(id);
            var Diseases = await _diseseRepo.GetByIdWithSpcsAsync(specs);
            var mappedDiseases = _mapper.Map<Disease, DiseasesToReturnDTO>(Diseases);
            return Ok(mappedDiseases);
        }

    }
}
