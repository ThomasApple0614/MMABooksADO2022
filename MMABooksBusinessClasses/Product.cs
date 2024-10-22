using System;
using System.Collections.Generic;
using System.Text;

namespace MMABooksBusinessClasses
{
    public class Product
    {
        private string productCode;
        private string description;
        private decimal price;
        private int quantity;

        public Product() { }

        public Product(string code, string description, decimal price, int quantity) 
        {
            ProductCode = code;
            Description = description;
            Price = price;
            Quantity = quantity;
        }

        public string ProductCode
        {
            get
            {
               return productCode;
            }
            set 
            {
                if (value.Length !=4)
                        throw new ArgumentOutOfRangeException("Please provide a 4 character product code");
                productCode = value;
            }

        }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                if (value.Length > 0 && value.Length < 50)
                    description = value;
                else
                    throw new ArgumentOutOfRangeException("Please give a description less than 50 characters");
            }
        }
        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value < 100.00m)
                {

                    price = value;
                }
                else
                    throw new ArgumentOutOfRangeException("Value must be below $100");

            }
        }
        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                if(value < 1000)
                    quantity = value;
                else
                    throw new ArgumentOutOfRangeException("Quantity must be below 1000");
            }
        }


        public override string ToString()
        {
            return base.ToString();
        }


    }
}
