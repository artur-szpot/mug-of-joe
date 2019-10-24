using CoffeeMugWebApi.Models.DataTypes;

namespace CoffeeMugWebApi.Models.InputModels
{
    /*
     * A model for validation of incoming update requests.
     */
    public class ProductUpdateInputModel : Product
    {
        public bool createIfNotFound = false;
    }
}
