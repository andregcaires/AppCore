using LojaConstrucao.Domain.Dtos;

namespace LojaConstrucao.Domain.Products
{
    public class ProductStorage
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Product> _productRepository;

        public ProductStorage(IRepository<Product> productRepository, IRepository<Category> categoryRepository){

            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public void Store(ProductDto dto)
        {
            var category = _categoryRepository.GetById(dto.CategoryId);
            DomainException.When(category == null, "Categoria inválida!");

            var product = _productRepository.GetById(dto.Id);

            if(product == null){
                product = new Product(dto.Name, category, dto.Price, dto.StockQuantity);
                _productRepository.Save(product);
            }
            else{
                product.Update(dto.Name, category, dto.Price, dto.StockQuantity);
            }
        }
    }
}