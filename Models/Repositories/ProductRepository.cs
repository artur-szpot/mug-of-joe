using CoffeeMugWebApi.Models.DataTypes;
using CoffeeMugWebApi.Models.Databases;
using CoffeeMugWebApi.Models.InputModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeMugWebApi.Models.Repositories
{
    /*
     * A repository class able to execute all the basic CRUD operations on the provided context.
     */
    public class ProductRepository : IProductRepository, IDisposable
    {
        private ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            this._context = context;
        }

        #region CRUD operations

        /*
         * Save the changes made to the database.
         */
        private async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        
        /*
         * Return all the Products.
         */
        public async Task<List<Product>> GetAll()
        {
            return await _context.Set<Product>().ToListAsync();
        }

        /*
         * Return the Product with a given Id.
         */
        public async Task<Product> GetById(Guid id)
        {
            return await _context.Set<Product>().FindAsync(id);
        }

        /*
         * Create a new Product and return its Id.
         */
        public async Task<Guid> Create(ProductCreateInputModel model)
        {
            Product product = model;
            _context.Set<Product>().Add(product);
            await SaveChangesAsync();
            return product.Id;
        }

        /*
         * Remove the Product with the specified Id.
         */
        public async Task<Product> Remove(Guid id)
        {
            Product found = await GetById(id);
            if (found != null)
            {
                _context.Set<Product>().Remove(found);
                await SaveChangesAsync();
            }
            return found;
        }

        /*
         * Overwrite the Product with the specified Id.
         */
        public async Task<bool> Update(ProductUpdateInputModel model)
        {
            Product product = await GetById(model.Id);

            if (product == null)
            {
                return false;
            }

            product = Product.ApplyOther(product, model);

            _context.Set<Product>().Update(product);

            try
            {
                _ = await SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoesProductExist(product.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }

        /*
         * Check whether a Product with the specified Id exists in the database.
         */
        private bool DoesProductExist(Guid id)
        {
            return _context.Set<Product>().Any(e => e.Id == id);
        }

        #endregion

        #region IDisposable Support

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (_context != null)
                    {
                        _context.Dispose();
                        _context = null;
                    }
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
