﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ProxyPattern
{
    public class DbProductRepository
    {
        private readonly IDictionary<int, Product> products;

        public DbProductRepository()
        {
            products = new Dictionary<int, Product>()
            {
                { 1, new Product(1, "Product 1", 10) },
                { 2, new Product(2, "Product 2", 20) },
                { 3, new Product(3, "Product 3", 30) },
            };
        }

        public Product Get(int id)
        {
            if (products.TryGetValue(id, out Product product))
            {
                return product;
            }
            else
                return null;
        }
    }

   
}
