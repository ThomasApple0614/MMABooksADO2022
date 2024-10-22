using MMABooksBusinessClasses;
using MMABooksDBClasses;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMABooksTests
{
    public class ProductDBTests
    {
        [Test]
        public void TestGetProduct()
        {
            Product p = ProductDB.GetProduct("A4CS");
            Assert.AreEqual("A4CS", p.ProductCode);
        }

        [Test]
        public void TestCreateProduct()
        {
            Product p = new Product();
            p.Description = "C# TextBook";
            p.Price = 77.50m;
            p.Quantity = 4588;

            //String or Char?
            string ProductID = ProductDB.AddProduct(p).ToString();
            p = ProductDB.GetProduct(ProductID);
            Assert.AreEqual("Mickey Mouse", p.Description);
        }
    }
}