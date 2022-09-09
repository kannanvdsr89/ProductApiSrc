using ProductAPI.Modules;

namespace ProductAPI.Services
{
    public interface IProductDetailsService
    {
        List<product_details> GetProductList();

        product_details GetProductDetailsById(int productId);

        ResponseModel SaveProductDetails(product_details _product_Details);

        ResponseModel DeleteProductDetails(int productId);

    }
}
