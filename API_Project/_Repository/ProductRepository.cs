using API_Project.Models;

namespace API_Project._Repository
{
    public class ProductRepository: IProductRepository
    {
        public string id { get; set; }
        AppDBContext context;
        public ProductRepository(AppDBContext context)
        {
            this.context = context;
            id = Guid.NewGuid().ToString();
        }

        public void Add(Product product)
        {
            context.Add(product);
            Save();
        }
        public void Delete(int id)
        {
           Product product = GetById(id);
            context.Remove(product);
            Save();
        }
        public void Edit(Product product)
        {
            context.Update(product);
        }
        public List<Product> GetAll()
        {
           return context.products.ToList();
        }
        public Product GetById(int id)
        {
            return context.products.FirstOrDefault(p => p.Id == id);
            
        }
        public void Save()
        {
            context.SaveChanges();
        }

    }
}
