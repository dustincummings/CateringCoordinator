using CateringCoodinator.Data;
using CateringCoordinator.Contracts;
using CateringCoordinator.Data;
using CateringCoordinator.Models;
using CateringCoordinator.Models.CustomerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CateringCoordinator.Services
{
    public class CustomerService:ICustomer
    {
        private readonly Guid _userId;

        public CustomerService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCustomer(CustomerCreate model)
        {
            var entity =
                new Customer()
                {
                    OwnerId = _userId, 
                    
                    LastName = model.LastName,
                    FirstName = model.FirstName,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Customers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CustomerList> GetCustomers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Customers
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new CustomerList
                        {
                            CustomerId = e.CustomerId,
                            //Event = e.Event.Location,
                            LastName = e.LastName,
                            FirstName = e.FirstName,
                            FullName =e.FullName,
                        }
                      );
                return query.ToArray();
            }
        }

        public CustomerDetail GetCustomerById(int customerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerId == customerId && e.OwnerId == _userId);
                return
                    new CustomerDetail
                    {
                        CustomerId = entity.CustomerId,
                        LastName = entity.LastName,
                        FirstName = entity.FirstName,
                    };
            }
        }

        public bool UpdateCustomer(CustomerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Customers
                    .Single(e => e.CustomerId == model.CustomerId && e.OwnerId == _userId);

                
                entity.LastName = model.LastName;
                entity.FirstName = model.FirstName;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCustomer(int customerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Customers
                    .Single(e => e.CustomerId == customerId && e.OwnerId == _userId);
                ctx.Customers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
