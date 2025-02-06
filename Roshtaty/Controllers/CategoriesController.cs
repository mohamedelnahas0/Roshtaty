using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Roshtaty.Core.Entites;
using Roshtaty.Core.Repositories;
using Roshtaty.Core.Specifications;
using Roshtaty.DTOS;

namespace Roshtaty.Controllers
{
   
    public class CategoriesController : ApiBaseController
    {

        private readonly IGenericRepository<Category> _Categoryrepo;
        private readonly IMapper _mapper;

        public CategoriesController(IGenericRepository<Category> Categoryrepo, IMapper mapper)
        {
            _Categoryrepo = Categoryrepo;
            _mapper = mapper;
        }
        //GET ALL MainSystem

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>>GetCategories()
        {
            var specs = new CategorySpecifications();
            var Categories = await _Categoryrepo.GetAllWithSpcsAsync(specs);
            var mappedCategories = _mapper.Map<IEnumerable< Category>,IEnumerable<CategorisToReturnDTO>>(Categories);
            return Ok(mappedCategories);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategories(int id)
        {
            var specs = new CategorySpecifications(id);
            var Categories = await _Categoryrepo.GetByIdWithSpcsAsync(specs);
            var mappedCategories = _mapper.Map<Category, CategorisToReturnDTO>(Categories);
            return Ok(mappedCategories);
        }

    }
}
