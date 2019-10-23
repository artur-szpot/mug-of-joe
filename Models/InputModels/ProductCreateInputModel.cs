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
        // Presently, all fields except Id are mandatory, exactly as in the Product specification.
        // Should some fields be optional in the future, they can become instantiated here.
    }

    /*
     * Aside:
     * The same functionality could be achieved by re-creating the fields of Product in both InputModels without employing inheritance
     * and implementing a Validate() function that would check their correctness.
     * Nonetheless, since there is appropriate functionality built into .NET Core itself, it would seem contradictory to the DRY rule to do so.
     */
}
