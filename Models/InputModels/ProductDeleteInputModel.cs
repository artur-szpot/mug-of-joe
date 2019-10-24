using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeMugWebApi.Models.InputModels
{
    /*
     * A model for validation of incoming delete requests.
     */
    public class ProductDeleteInputModel
    {
        public Guid Id { get; set; }
    }
}
