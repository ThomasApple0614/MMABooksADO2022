using System;
using System.Collections.Generic;
using System.Text;
using MMABooksDBClasses;

using NUnit.Framework;
using MMABooksBusinessClasses;

namespace MMABooksTests
{
    [TestFixture]
    public class CustomerTests
    {
        private Customer def;
        private Customer c;

        [SetUp]

        public void Setup()
        {
            def = new Customer();
            c = new Customer(1, "Donald Duck", "123 Main street", "Cherry hill", "NJ", "08002");
        }

        [Test]

        public void TestConstructor()
        {
            Assert.IsNotNull(def);
            Assert.AreEqual(null, def.Name);
            Assert.AreEqual(null, def.Address);
            Assert.AreEqual(null, def.City);
            Assert.AreEqual(null, def.State);
            Assert.AreEqual(null, def.ZipCode);

            Assert.IsNotNull(c);
            Assert.AreEqual("Donald Duck", c.Name);
            Assert.AreEqual("123 Main street", c.Address);
            Assert.AreEqual("Cherry hill", c.City);
            Assert.AreEqual("NJ", c.State);
            Assert.AreEqual("08002", c.ZipCode);
        }

        [Test]

        public void TestNameSetter() 
        {
            c.Name = "Luca Apple";
            Assert.AreNotEqual("Donald Duck", c.Name);

        }

        /*
        [Test]
        public void TestSettersNameTooLong()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.Name = "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890");
        }
        */
        [Test]

        public void TestAddressSetter()
        {
            c.Address = "1 Q street";
            Assert.AreNotEqual("123 Main street", c.Address);

            Assert.Throws<ArgumentOutOfRangeException>(() => c.Address = "1 Q");


        }

        [Test]
        public void TestCitySetter()
        {

        }

        [Test]
        public void TestStateSetter()
        {

        }

        [Test]
        public void TestZipSetter()
        {

        }


    }
}
