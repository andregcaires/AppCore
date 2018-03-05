using LojaConstrucao.Domain.Dtos;

namespace LojaConstrucao.Domain.Products
{
    public class CategoryStorage
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryStorage(IRepository<Category> categoryRepository){
            _categoryRepository = categoryRepository;
        }

        public void Store(int id, string name){
            //DomainException.When(dto == null, "Categoria inválida!");

            var category = _categoryRepository.GetById(id);
            if(category == null){
                category = new Category(name);
                _categoryRepository.Save(category);
            }
            else{
                category.Update(name);
            }
        }
    }
}