namespace LojaConstrucao.Domain.Products
{
    public class Product
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public Category Category { get; private set; }

        public decimal Price { get; private set; }

        public int StockQuantity { get; private set; }


        public Product(string name, Category category, decimal price, int stock)
        {
            ValidadeValues(name, category, price, stock);

            SetProperties(name, category, price, stock);
        }

        private void SetProperties(string name, Category category, decimal price, int stock)
        {
            Name = name;
            Category = category;
            Price = price;
            StockQuantity = stock;
        }

        private static void ValidadeValues(string name, Category category, decimal price, int stock)
        {
            DomainException.When(string.IsNullOrEmpty(name), "Nome é obrigatório");
            DomainException.When(category == null, "Categoria é obrigatória");
            DomainException.When(price < 0, "Preço é obrigatório");
            DomainException.When(stock < 0, "Quantidade no estoque é obrigatória!");
        }

        public void Update(string name, Category category, decimal price, int stock)
        {
            ValidadeValues(name, category, price, stock);

            SetProperties(name, category, price, stock);
        }

    }
}