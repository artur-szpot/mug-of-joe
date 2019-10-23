using CoffeeMugWebApi.Models.DataTypes;

namespace CoffeeMugWebApi.Models.InputModels
{
    /*
     * A model for validation of incoming update requests.
     */
    public class ProductUpdateInputModel : Product
    {
        public bool createIfNotFound = false;

        /*
         * Updates the given Product instance with the values passed to this model.
         */
        public static Product Update(Product product, ProductUpdateInputModel model)
        {
            product.Name = model.Name;
            product.Price = model.Price;
            return product;
        }

        /*
         * Creates a ProductCreateInputModel based on the values passed to this model.
         */
        public static ProductCreateInputModel Create(ProductUpdateInputModel model)
        {
            ProductCreateInputModel createModel = new ProductCreateInputModel();
            createModel.Name = model.Name;
            createModel.Price = model.Price;
            return createModel;
        }
    }
}
