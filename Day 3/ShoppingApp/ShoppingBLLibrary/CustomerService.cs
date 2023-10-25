using ShoppingDALLibrary;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public class CustomerService : ICustomerService
    {
        IRepository<string,Customer> repository;
        public CustomerService()
        {
            repository = new CustomerRepository();
        }

        public Customer Login(string email, string password)
        {
            var result = GetCustomer(email);
            if(result!=null)
            {
                if (result.ComparePassword(password)){
                    return result;
                }
            }
            throw new InvalidPasswordException();
        }
        public Customer GetCustomer(string email)
        {
            var result = repository.GetById(email); 
            return result == null ? throw new NoSuchEmailException() : result;
        }

        public Customer Register(Customer customer)
        {
            var result = repository.Add(customer);
            if (result != null)
                return result;
            throw new UnableToRegisterCustomerException();
        }
    }
}
