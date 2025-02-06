using Roshtaty.Core.Entites;
using Roshtaty.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshtaty.Core.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {

        //Without Specs
        //Get All
        Task<IEnumerable<T>> GetAllAsync();

        //Get By Id
        Task<T> GetByIDAsync(int id);




        //With Specs
        Task<IEnumerable<T>> GetAllWithSpcsAsync(ISpecifications<T> Specs);


        Task<T> GetByIdWithSpcsAsync(ISpecifications<T> Specs);



    }
}
