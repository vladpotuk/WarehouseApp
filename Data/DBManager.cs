using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace WarehouseApp
{
    public class DBManager
    {
        private readonly string _connectionString;

        public DBManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool TestConnection()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Products", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product product = new Product
                    {
                        Name = reader.GetString(0),
                        Type = reader.GetString(1),
                        Supplier = reader.GetString(2),
                        Quantity = reader.GetInt32(3),
                        Cost = reader.GetDecimal(4),
                        SupplyDate = reader.GetDateTime(5)
                    };
                    products.Add(product);
                }
            }
            return products;
        }

        public List<string> GetAllProductTypes()
        {
            List<string> types = new List<string>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT Type FROM Products", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    types.Add(reader.GetString(0));
                }
            }
            return types;
        }

        public List<string> GetAllSuppliers()
        {
            List<string> suppliers = new List<string>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT Supplier FROM Products", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    suppliers.Add(reader.GetString(0));
                }
            }
            return suppliers;
        }

        public Product GetProductWithMaxQuantity()
        {
            Product product = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM Products ORDER BY Quantity DESC", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    product = new Product
                    {
                        Name = reader.GetString(0),
                        Type = reader.GetString(1),
                        Supplier = reader.GetString(2),
                        Quantity = reader.GetInt32(3),
                        Cost = reader.GetDecimal(4),
                        SupplyDate = reader.GetDateTime(5)
                    };
                }
            }
            return product;
        }

        public Product GetProductWithMinQuantity()
        {
            Product product = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM Products ORDER BY Quantity ASC", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    product = new Product
                    {
                        Name = reader.GetString(0),
                        Type = reader.GetString(1),
                        Supplier = reader.GetString(2),
                        Quantity = reader.GetInt32(3),
                        Cost = reader.GetDecimal(4),
                        SupplyDate = reader.GetDateTime(5)
                    };
                }
            }
            return product;
        }

        public Product GetProductWithMinCost()
        {
            Product product = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM Products ORDER BY Cost ASC", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    product = new Product
                    {
                        Name = reader.GetString(0),
                        Type = reader.GetString(1),
                        Supplier = reader.GetString(2),
                        Quantity = reader.GetInt32(3),
                        Cost = reader.GetDecimal(4),
                        SupplyDate = reader.GetDateTime(5)
                    };
                }
            }
            return product;
        }

        public Product GetProductWithMaxCost()
        {
            Product product = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM Products ORDER BY Cost DESC", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    product = new Product
                    {
                        Name = reader.GetString(0),
                        Type = reader.GetString(1),
                        Supplier = reader.GetString(2),
                        Quantity = reader.GetInt32(3),
                        Cost = reader.GetDecimal(4),
                        SupplyDate = reader.GetDateTime(5)
                    };
                }
            }
            return product;
        }

        public List<Product> GetProductsByType(string type)
        {
            List<Product> products = new List<Product>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Products WHERE Type = @Type", connection);
                cmd.Parameters.AddWithValue("@Type", type);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product product = new Product
                    {
                        Name = reader.GetString(0),
                        Type = reader.GetString(1),
                        Supplier = reader.GetString(2),
                        Quantity = reader.GetInt32(3),
                        Cost = reader.GetDecimal(4),
                        SupplyDate = reader.GetDateTime(5)
                    };
                    products.Add(product);
                }
            }
            return products;
        }

        public List<Product> GetProductsBySupplier(string supplier)
        {
            List<Product> products = new List<Product>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Products WHERE Supplier = @Supplier", connection);
                cmd.Parameters.AddWithValue("@Supplier", supplier);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product product = new Product
                    {
                        Name = reader.GetString(0),
                        Type = reader.GetString(1),
                        Supplier = reader.GetString(2),
                        Quantity = reader.GetInt32(3),
                        Cost = reader.GetDecimal(4),
                        SupplyDate = reader.GetDateTime(5)
                    };
                    products.Add(product);
                }
            }
            return products;
        }

        public Product GetProductWithLongestTimeOnStock()
        {
            Product product = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM Products ORDER BY DATEDIFF(day, SupplyDate, GETDATE()) DESC", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    product = new Product
                    {
                        Name = reader.GetString(0),
                        Type = reader.GetString(1),
                        Supplier = reader.GetString(2),
                        Quantity = reader.GetInt32(3),
                        Cost = reader.GetDecimal(4),
                        SupplyDate = reader.GetDateTime(5)
                    };
                }
            }
            return product;
        }

        public Dictionary<string, double> GetAverageQuantityByProductType()
        {
            Dictionary<string, double> averageQuantities = new Dictionary<string, double>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT Type, AVG(Quantity) AS AvgQuantity FROM Products GROUP BY Type", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string type = reader.GetString(0);
                    double avgQuantity = reader.GetDouble(1);
                    averageQuantities.Add(type, avgQuantity);
                }
            }
            return averageQuantities;
        }
    }
}
