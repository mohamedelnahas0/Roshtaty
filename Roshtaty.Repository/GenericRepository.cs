using Microsoft.EntityFrameworkCore;
using Roshtaty.Core.Entites;
using Roshtaty.Core.Repositories;
using Roshtaty.Core.Specifications;
using Roshtaty.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshtaty.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly RoshtatyContext _roshtatyContext;

        public GenericRepository(RoshtatyContext roshtatyContext)
        {
            _roshtatyContext = roshtatyContext;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            if (typeof(T) == typeof(Category))
            {
                return (IEnumerable<T>)await _roshtatyContext.categories.Where(P => P.Id == P.MainSystemId).Include(p => p.MainSystem).ToListAsync();
            }
            return await _roshtatyContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIDAsync(int id)
        {
            return await _roshtatyContext.Set<T>().FindAsync(id); 
        }


        //Specs

        public async Task<T> GetByIdWithSpcsAsync(ISpecifications<T> Specs)
        {
            return await ApplySpecifications(Specs).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAllWithSpcsAsync(ISpecifications<T> Specs)
        {
            return await ApplySpecifications(Specs).ToListAsync();
        }


        private IQueryable<T> ApplySpecifications( ISpecifications<T> Specs )
        {
            return SpecificationEvaluator<T>.GetQuery(_roshtatyContext.Set<T>(), Specs);
        }
    }
}
