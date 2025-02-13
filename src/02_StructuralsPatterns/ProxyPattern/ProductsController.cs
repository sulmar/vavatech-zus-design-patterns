namespace ProxyPattern
{
    public class ProductsController(IProductRepository productRepository)
    {
        public Product Get(int id) => productRepository.Get(id);
    }

   
}
