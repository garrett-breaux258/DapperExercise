using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace BestBuyBestPractices
{
    public class DapperProductRepository : IProductRepository
    {

        private readonly IDbConnection _connection;

        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO PRODUCTS (Name, Price, Category ID) VALUES (@productName, @productPrice, @productCategoryID);",
                new {productName = name, productPrice = price, productCategoryID = categoryID });
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM PRODUCTS;");
        }
    }
}
