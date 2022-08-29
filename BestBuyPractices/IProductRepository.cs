using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyPractices
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();
        void CreateProduct(string productName, double price, int categoryID, int onSale, int stockLevel);
    }
}
