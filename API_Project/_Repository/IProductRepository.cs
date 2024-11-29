using API_Project.Models;

namespace API_Project._Repository
{
    public interface IProductRepository
    {
        public string id { get; set; }
        public void Add(Product product);
        public void Edit(Product product);
        public void Delete(int id);
        public List<Product> GetAll();
        public Product GetById(int id);
        public void Save(); 
    }
}
