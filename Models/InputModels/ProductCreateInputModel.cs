using CoffeeMugWebApi.Models.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeMugWebApi.Models.InputModels
{
    /*
     * A model for validation of incoming create requests.
     */
    public class ProductCreateInputModel : Product
    {
        // Presently, all fields except Id are mandatory.
        // Should some fields be optional in the future, they can become instantiated here.
    }
}
