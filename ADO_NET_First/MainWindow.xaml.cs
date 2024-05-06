using System;
using System.Collections.Generic;
using System.Windows;

namespace WarehouseApp
{
    public partial class MainWindow : Window
    {
        private readonly DBManager _dbManager;

        public MainWindow()
        {
            InitializeComponent();
            _dbManager = new DBManager("YourConnectionStringHere");
            TestDatabaseConnection();
            DisplayAllProducts();
            DisplayAllProductTypes();
            DisplayAllSuppliers();
            DisplayProductWithMaxQuantity();
            DisplayProductWithMinQuantity();
            DisplayProductWithMinCost();
            DisplayProductWithMaxCost();
            DisplayProductsByType("TypeHere");
            DisplayProductsBySupplier("SupplierHere");
            DisplayProductWithLongestTimeOnStock();
            DisplayAverageQuantityByProductType();
        }

        private void TestDatabaseConnection()
        {
            if (_dbManager.TestConnection())
            {
                MessageBox.Show("Connection to the database successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Failed to connect to the database.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DisplayAllProducts()
        {
            List<Product> products = _dbManager.GetAllProducts();
           
        }

        private void DisplayAllProductTypes()
        {
            List<string> types = _dbManager.GetAllProductTypes();
            
        }

        private void DisplayAllSuppliers()
        {
            List<string> suppliers = _dbManager.GetAllSuppliers();
       
        }

        private void DisplayProductWithMaxQuantity()
        {
            Product product = _dbManager.GetProductWithMaxQuantity();
            
        }

        private void DisplayProductWithMinQuantity()
        {
            Product product = _dbManager.GetProductWithMinQuantity();
           
        }

        private void DisplayProductWithMinCost()
        {
            Product product = _dbManager.GetProductWithMinCost();
            
        }

        private void DisplayProductWithMaxCost()
        {
            Product product = _dbManager.GetProductWithMaxCost();
            
        }

        private void DisplayProductsByType(string type)
        {
            List<Product> products = _dbManager.GetProductsByType(type);
           
        }

        private void DisplayProductsBySupplier(string supplier)
        {
            List<Product> products = _dbManager.GetProductsBySupplier(supplier);
          
        }

        private void DisplayProductWithLongestTimeOnStock()
        {
            Product product = _dbManager.GetProductWithLongestTimeOnStock();
            
        }

        private void DisplayAverageQuantityByProductType()
        {
            Dictionary<string, double> averageQuantities = _dbManager.GetAverageQuantityByProductType();
        
        }

      
    }
}
