using System;
using System.Collections.Generic;
using System.Text;
using MMABooksDBClasses;

using NUnit.Framework;
using MMABooksBusinessClasses;

namespace MMABooksTests
{
    public class ProductTests
    {
        private Product def;
        private Product p;

        [SetUp]
        public void SetUp()
        {
            def = new Product();
            p = new Product("A21Z", "C# Textbook", 77.50m, 27);
        }

        [Test]
        public void TestConstructor()
        {
            Assert.IsNotNull(def);
            Assert.AreEqual(null, def.ProductCode);
            Assert.AreEqual(null, def.Description);
            Assert.AreEqual(0.0m, def.Price);
            Assert.AreEqual(0, def.Quantity);

            Assert.IsNotNull(p);
            Assert.AreEqual("A21Z", p.ProductCode);
            Assert.AreEqual("C# Textbook", p.Description);
            Assert.AreEqual(77.50m, p.Price);
            Assert.AreEqual(27, p.Quantity);
        }
        [Test]
        public void TestProductCode()
        {
            p.ProductCode = "Z44A";
            Assert.AreNotEqual("A21Z", p.ProductCode);

            //Testing 5 characters when limit is 4.
            //Assert.Throws<ArgumentOutOfRangeException>(() => p.ProductCode = "A123Z");
            

        }

        [Test]
        public void TestProductDescription()
        {
            p.Description = "New Textbook";
            Assert.AreNotEqual("C# Textbook", p.Description);

            //Limit is 50. Testing with 60
            Assert.Throws<ArgumentOutOfRangeException>(() => p.Description = "123456789012345678901234567890123456789012345678901234567890");
        }

        [Test]

        public void TestProductPrice()
        {
            p.Price = 25.00m;
            Assert.AreNotEqual(75.50m, p.Price);

            //Limit is $100. Testing with 101.50
            Assert.Throws<ArgumentOutOfRangeException>(() => p.Price = 101.50m);
        }

        [Test]

        public void TestProductQuantity() 
        {
            p.Quantity = 1;
            Assert.AreNotEqual(27, p.Quantity);

            Assert.Throws<ArgumentOutOfRangeException>(() => p.Quantity = 1001);
        }

    }
}
