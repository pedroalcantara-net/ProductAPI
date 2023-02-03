using System.ComponentModel.DataAnnotations;

namespace Products.Domain.Entities
{
    public class Product
    {
        public Product(string name, float price) => (Id, Name, Price) = (0, name, price);
        public Product(int id, string name, float price) => (Id, Name, Price) = (id, name, price);

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
    }
}
