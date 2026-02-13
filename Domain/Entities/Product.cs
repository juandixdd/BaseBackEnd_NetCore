namespace BaseBackend.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        public decimal Price { get; private set; }

        private Product() { }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public void Update(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
