using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ProxyPattern
{
    public interface IProductRepository
    {
        Product Get(int id);
    }

    // Proxy (Pośrednik) - Caching Proxy
    public class CacheProductRepository : IProductRepository
    {
        // Real Subject
        private readonly IProductRepository realRepository;

        private IDictionary<int, Product> products;

        public CacheProductRepository(IProductRepository repository)
        {
            products = new Dictionary<int, Product>();
            this.realRepository = repository;
        }

        public void Add(Product product)
        {
            products.Add(product.Id, product);
        }

        public Product Get(int id)
        {
            if (products.TryGetValue(id, out Product product))
            {
                product.CacheHit++;

                return product;
            }
            else
            {
                product = realRepository.Get(id); // Użycie RealSubject

                if (product != null)
                {
                    Add(product);
                }

                return product;
            }
        }

    }

}
