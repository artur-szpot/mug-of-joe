using CoffeeMugWebApi.Controllers;
using CoffeeMugWebApi.Models.Databases;
using CoffeeMugWebApi.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CoffeeMugWebApi.Models.IoC
{
    /*
     * Enum of repository types available to be chosen from the IocContainer. 
     */
    public enum IocRepositoryTypes { mySql }

    /*
     * Enum of controller types available to be chosen from the IocContainer. 
     */
    public enum IocControllerTypes { webApi }


    /*
     * Container for all the dependecies intended for being injected into the project.
     */
    public class IocContainer
    {
        private static Dictionary<string, object> _instances;

        /*
         * Initializes the static Dictionary.
         */
        static IocContainer()
        {
            _instances = new Dictionary<string, object>();
        }

        /*
         * Returns a repository of the requested type.
         */
        public static IProductRepository GetRepository(IocRepositoryTypes type)
        {
            string fullKey = type.ToString() + "Repository";

            if (_instances.ContainsKey(fullKey))
            {
                return (IProductRepository)_instances[fullKey];
            }

            switch (type)
            {
                case IocRepositoryTypes.mySql:
                    DbContextOptionsBuilder<ProductContext> mySqlOptionsBuilder = new DbContextOptionsBuilder<ProductContext>();
                    mySqlOptionsBuilder.UseMySql("Server=remotemysql.com;Port=3306;Database=8150XrSeVg;Uid=8150XrSeVg;Pwd=cUHhzSCMbt");
                    ProductRepository mySqlRepository = new ProductRepository(new ProductContext(mySqlOptionsBuilder.Options));
                    _instances.Add(fullKey, mySqlRepository);
                    return mySqlRepository;
                default:
                    return null;
            }
        }

        /*
         * Returns a controller of the requested type. If it is just being initialized, providing the repository is necessary.
         */
        public static ControllerBase GetController(IocControllerTypes type, IProductRepository repository)
        {
            string fullKey = type.ToString() + "Controller";

            if (_instances.ContainsKey(fullKey))
            {
                return (ControllerBase)_instances[fullKey];
            }

            switch (type)
            {
                case IocControllerTypes.webApi:
                    ProductController webApiController = new ProductController(repository);
                    _instances.Add(fullKey, webApiController);
                    return webApiController;
                default:
                    return null;
            }

        }
    }
}
