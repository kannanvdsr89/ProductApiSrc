using ProductAPI.ContextMiddleware;
using ProductAPI.Controllers;
using ProductAPI.Modules;

namespace ProductAPI.Services
{
    public class ProductDetailsService : IProductDetailsService
    {
        private ProductDBContext _Context;
        private readonly ILogger<ProductDetailsService> _logger;
        public ProductDetailsService(ProductDBContext productDBContext, ILogger<ProductDetailsService> logger)
        {
            _Context = productDBContext;
            _logger = logger;
        }
        public ResponseModel DeleteProductDetails(int productId)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                product_details product_Details = GetProductDetailsById(productId);
                if (product_Details != null)
                {

                    _Context.Remove<product_details>(product_Details);
                    _Context.SaveChanges();
                    responseModel.IsSuccess = true;
                    responseModel.Messsage = "Product Details Removed Successfully for Product Id = " + productId;
                    _logger.LogInformation("Product Details Removed Successfully for Product Id = " + productId);
                }
                else
                {
                    responseModel.IsSuccess = false;
                    responseModel.Messsage = "Product Details not found for Product Id = " + productId;
                    throw new Exception("Product details not found for this Id=" + productId.ToString());
                }
            }
            catch (Exception ex)
            {
                responseModel.IsSuccess = false;
                responseModel.Messsage = "Error : " + ex.Message;
                _logger.LogError(ex, ex.Message);
            }
            return responseModel;
        }

        public product_details GetProductDetailsById(int productId)
        {
            product_details product_Details = new product_details();
            try
            {
                product_Details = _Context.Find<product_details>(productId);
                if (product_Details == null)
                {
                    throw new Exception("Product details not found for this Id=" + productId.ToString());
                }
                _logger.LogInformation("Product found for the product Id = " + productId.ToString());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            return product_Details;
        }

        public List<product_details> GetProductList()
        {
            List<product_details> product_Details = new List<product_details>();
            try
            {
                product_Details = _Context.Set<product_details>().ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }
            _logger.LogInformation("All Product details are returned.");
            return product_Details;
        }

        public ResponseModel SaveProductDetails(product_details _product_Details)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                product_details product_Details = GetProductDetailsById(_product_Details.product_id);
                if (product_Details != null)
                {
                    product_Details.product_description = _product_Details.product_description;
                    product_Details.product_name = _product_Details.product_name;
                    product_Details.product_code = _product_Details.product_code;
                    product_Details.product_company = _product_Details.product_company;
                    product_Details.product_category_code = _product_Details.product_category_code;
                    _Context.Update<product_details>(product_Details);
                    _Context.SaveChanges();
                    responseModel.Messsage = "Product Details Updated Successfully";
                }
                else
                {
                    _Context.Add<product_details>(_product_Details);
                    _Context.SaveChanges();
                    responseModel.Messsage = "Product Details Inserted Successfully";
                }
                responseModel.IsSuccess = true;
                _logger.LogInformation(responseModel.Messsage);
            }
            catch (Exception ex)
            {
                responseModel.IsSuccess = false;
                responseModel.Messsage = "Error : " + ex.Message;
                _logger.LogError(ex, ex.Message);
            }
            return responseModel;
        }
    }
}
