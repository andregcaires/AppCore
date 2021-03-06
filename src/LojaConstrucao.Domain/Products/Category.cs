namespace LojaConstrucao.Domain.Products
{
    public class Category : Entity
    {

        public string Name { get; private set; }


        public Category(string name)
        {
            ValidateAndSetName(name);
        }

        private void ValidateAndSetName(string name)
        {
            DomainException.When(string.IsNullOrEmpty(name), "Nome é obrigatório");

            Name = name;
        }

        public void Update(string name){
            ValidateAndSetName(name);
        }

    }

}