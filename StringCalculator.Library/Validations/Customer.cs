using System.Collections.Generic;

namespace StringCalculator_Library.Validations
{
    public class Customer
    {
        public string Name { get; set; }
        public List<Order> orders { get; set; }
        public List<Product> products { get; set; }
        public class Order
        {
            public string Name { get; set; }
        }
        public class Product
        {
            public string Name { get; set; }
        }
    }
}