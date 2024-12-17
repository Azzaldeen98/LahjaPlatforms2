using Domain.ShareData.Base;

namespace Domain
{
    public interface IRepository<T> where T : class
    {
     
        T GetAll();

    }
    public class Repository<T> : IRepository<T> where T : class,new()
    {
        //protected readonly DbContext _context;


    

        public T GetAll()
        {
            return  new T() ;
        }


    }

    public interface IProductRepository<Product> where Product : class
    {

    }


    public class ProductRepository : Repository<Product>, IProductRepository<Product>
    {

    }



    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
    }

    
}
