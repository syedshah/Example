using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using SalesOrder.Entity;
using SalesOrder.Repository.Interfaces;
using EntityState = System.Data.Entity.EntityState;

namespace SalesOrder.Repository.Repositories
{ 
    public class CustomerRepository : IRepository<Customer>
    {
        SalesOrderDb context = new SalesOrderDb();

        public IQueryable<Customer> All
        {
            get { return context.Customers; }
        }

        public IQueryable<Customer> AllIncluding(params Expression<Func<Customer, object>>[] includeProperties)
        {
            IQueryable<Customer> query = context.Customers;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Customer Find(int id)
        {
            return context.Customers.Find(id);
        }

        public void InsertOrUpdate(Customer customer)
        {
            if (customer.Id == default(int)) {
                // New entity
                context.Customers.Add(customer);
            } else {
                // Existing entity
                context.Entry(customer).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var customer = context.Customers.Find(id);
            context.Customers.Remove(customer);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose() 
        {
            context.Dispose();
        }
    }
}