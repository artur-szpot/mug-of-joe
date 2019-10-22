using CoffeeMugWebApi.Models.DataTypes;

namespace CoffeeMugWebApi.Models.InputModels
{
    /*
     * A model for validation of incoming update requests.
     */
    public class ProductUpdateInputModel : Product
    {
        /*
         * Updates the given Product instance with the values passed to this model.
         */
        public static Product Update(Product product, ProductUpdateInputModel model)
        {
            product.Name = model.Name;
            product.Price = model.Price;
            return product;
        }
    }
}
