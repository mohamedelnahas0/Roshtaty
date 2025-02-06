using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Roshtaty.Core.Entites;
using Roshtaty.Core.Repositories;
using Roshtaty.Core.Specifications;
using Roshtaty.DTOS;
using Roshtaty.Repository.Data;

namespace Roshtaty.Controllers
{
  
    public class TradeNamesController : ApiBaseController
    {
        private readonly IGenericRepository<Trades> _TradeNameRepo;
        private readonly IMapper _mapper;
        private readonly RoshtatyContext _context;

        public TradeNamesController(IGenericRepository<Trades> TradeNameRepo , IMapper mapper, RoshtatyContext context)
        {
            _TradeNameRepo = TradeNameRepo;
            _mapper = mapper;
            _context = context;
        }
        //GET ALL Diseases

        [HttpGet , Authorize]
        public async Task<ActionResult<IEnumerable<Trades>>> GetTradeNames(string sort)
        {
            var Specs = new TradesSpecification(sort);
            var TradeNames = await _TradeNameRepo.GetAllWithSpcsAsync(Specs);
            var MappedTrades = _mapper.Map<IEnumerable<Trades>, IEnumerable<TradesToReturnDTO>>(TradeNames);
            return Ok(MappedTrades);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Trades>> GetTradeNames(int id)
        {
            var specs = new TradesSpecification(id);
            var TradeNames = await _TradeNameRepo.GetByIdWithSpcsAsync(specs);
            var MappedTrades = _mapper.Map<Trades, TradesToReturnDTO>(TradeNames);

            return Ok(MappedTrades);
        }



        [HttpGet("GetTradesByActiveIngredient")]
        public async Task<IActionResult> GetTradesByActiveIngredient(
     string activeIngredientName,
     decimal strength,
     string strengthUnit,
     string sortBy = "priceAsc")
        {
            if (string.IsNullOrEmpty(activeIngredientName) || string.IsNullOrEmpty(strengthUnit))
            {
                return BadRequest("Invalid input parameters.");
            }

            var tradesQuery = _context.tradeNames
                .Include(t => t.Active_Ingredient)
                .Where(t => t.Active_Ingredient.ActiveIngredientName == activeIngredientName &&
                            t.Active_Ingredient.Strength == strength &&
                            t.Active_Ingredient.StrengthUnit == strengthUnit)
                .Select(t => new
                {
                    t.TradeName,
                    t.Dose,
                    t.PharmaceuticalForm,
                    t.PublicPrice
                });

            tradesQuery = sortBy.ToLower() switch
            {
                "priceasc" => tradesQuery.OrderBy(t => t.PublicPrice),
                "pricedesc" => tradesQuery.OrderByDescending(t => t.PublicPrice),
                "tradenameaz" => tradesQuery.OrderBy(t => t.TradeName),
                _ => tradesQuery 
            };

            var trades = await tradesQuery.ToListAsync();

            if (!trades.Any())
            {
                return NotFound("No trades found for the given active ingredient.");
            }

            return Ok(trades);
        }





      



    }
}
