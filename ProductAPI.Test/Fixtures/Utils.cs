using ProductAPI.ContextMiddleware;
using ProductAPI.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.Test.Fixtures
{
    public class Utils
    {
        internal static void InitializeForTests(ProductDBContext productDBContext)
        {
            InitializeModel(productDBContext);
            productDBContext.SaveChanges();
        }
        private static void InitializeModel(ProductDBContext productDBContext)
        {
            productDBContext.product_details.Add(
                new product_details()
                {
                    created_on = DateTime.Now,  
                    product_category_code=101,
                    product_code=Guid.NewGuid(),
                    product_company="TU",
                    product_id=1,
                    product_description="test desc",
                    product_name="Product Name"
                });
        }
    }
}
