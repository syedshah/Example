using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesOrder.Entity;
using SalesOrder.Repository.Interfaces;

namespace SalesOrder.Service
{
    public class CustomerService
    {
        private readonly IRepository<Customer> _customerRepository;

        public CustomerService(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Customer Find(int id)
        {
           return _customerRepository.Find(id);
        }

        public void Add(Customer customer)
        {
            _customerRepository.InsertOrUpdate(customer);
        }

        public void Update(Customer customer)
        {
            _customerRepository.InsertOrUpdate(customer);
        }
    }
}
