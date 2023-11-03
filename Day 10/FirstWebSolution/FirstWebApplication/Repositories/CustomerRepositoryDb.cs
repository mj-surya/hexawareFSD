using FirstWebApplication.Contexts;
using FirstWebApplication.Interfaces;
using FirstWebApplication.Models;

namespace FirstWebApplication.Repositories
{
    public class CustomerRepositoryDb : IRepository<string, Customer>
    {
        private readonly ShoppingContext _context;

        public CustomerRepositoryDb(ShoppingContext context)
        {
            _context = context;
        }
        public Customer Add(Customer item)
        {
            _context.Customers.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Customer Delete(string key)
        {
            var customer = Get(key);
            _context.Customers.Remove(customer);//removes from local collection
            _context.SaveChanges();//Makes the delete in database
            return customer;
        }

        public Customer Get(string key)
        {
            var customer = _context.Customers.SingleOrDefault(p => p.Email == key);
            return customer;
        }

        public IList<Customer> GetAll()
        {
            var customers = _context.Customers.ToList();
            return customers;
        }

        public Customer Update(Customer item)
        {
            var customer = Get(item.Email);
            if (customer != null)
            {
                _context.Entry<Customer>(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return customer;
            }
            return null;
        }
    }
}
