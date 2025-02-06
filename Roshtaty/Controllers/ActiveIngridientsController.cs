using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Roshtaty.Core.Entites;
using Roshtaty.Core.Repositories;
using Roshtaty.Core.Specifications;
using Roshtaty.DTOS;

namespace Roshtaty.Controllers
{

    public class ActiveIngridientsController : ApiBaseController
    {
        private readonly IGenericRepository<Active_Ingredient> _ActiveIngredients;
        private readonly IMapper _mapper;

        public ActiveIngridientsController(IGenericRepository<Active_Ingredient> ActiveIngridientsRepo , IMapper mapper)
        {
            _ActiveIngredients = ActiveIngridientsRepo;
            _mapper = mapper;
        }
        //GET ALL Diseases

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Active_Ingredient>>> GetActiveIngridients()
        {
            var specs = new ActiveIngredientSpecification();
            var ActiveIngridients = await _ActiveIngredients.GetAllWithSpcsAsync(specs);
            var MappedActiveIngridients = _mapper.Map<IEnumerable<Active_Ingredient>, IEnumerable<ActiveIngridientsToReturnDTO>>(ActiveIngridients);

            return Ok(MappedActiveIngridients);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Active_Ingredient>> GetActiveIngridients(int id)
        {
            var specs = new ActiveIngredientSpecification(id);
            var ActiveIngridients = await _ActiveIngredients.GetByIdWithSpcsAsync(specs);
            var MappedActiveIngridients = _mapper.Map<Active_Ingredient, ActiveIngridientsToReturnDTO>(ActiveIngridients);

            return Ok(MappedActiveIngridients);
        }
    }
}
