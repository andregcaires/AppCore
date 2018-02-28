using LojaConstrucao.Domain.Dtos;

namespace LojaConstrucao.Domain.Products
{
    public class CategoryStorage
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryStorage(IRepository<Category> categoryRepository){
            _categoryRepository = categoryRepository;
        }

        public void Store(CategoryDto dto){
            DomainException.When(dto == null, "Categoria inválida!");

            var category = _categoryRepository.GetById(dto.Id);
            if(category == null){
                category = new Category(dto.Name);
                _categoryRepository.Save(category);
            }
            else{
                category.Update(dto.Name);
            }
        }
    }
}