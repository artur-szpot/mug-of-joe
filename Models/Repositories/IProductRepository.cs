using CoffeeMugWebApi.Models.DataTypes;
using CoffeeMugWebApi.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeMugWebApi.Models.Repositories
{
    /*
     * An interface defining the methods necessary to implement by any Product repository.
     */
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
        Task<Product> GetById(Guid id);
        Task<Guid> Create(ProductCreateInputModel model);
        Task<Product> Remove(Guid id);
        Task<bool> Update(ProductUpdateInputModel model);
    }
}
