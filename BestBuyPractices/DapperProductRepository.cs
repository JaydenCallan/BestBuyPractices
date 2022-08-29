using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using BestBuyPractices;
using Dapper;

namespace BestBuyPractices
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;

        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM products");
        }

        public void CreateProduct(string productName, double price, int categoryID, int onSale, int stockLevel)
        {
            _connection.Execute("INSERT INTO products (name, price, categoryID, onSale, stockLevel) VALUES (@productName, @price, @categoryID, @onSale, @stockLevel);",
                new {
                    productName = productName,
                    price = price,
                    categoryID = categoryID,
                    onSale = onSale,
                    stockLevel = stockLevel
                });
        }

        public void DeleteProduct(int productID)
        {
            _connection.Execute("DELETE FROM products WHERE productID = @productID;",
                new
                {
                    productID = productID
                });

        }

        public void UpdateProduct(int productID, string newName)
        {
            _connection.Execute("UPDATE products SET Name = @newName WHERE ProductID = @productID;",
                new
                {
                    productId = productID,
                    newName = newName,
                });
        }
    }
}