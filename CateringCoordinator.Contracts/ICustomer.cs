using CateringCoordinator.Models.CustomerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CateringCoordinator.Contracts
{
    public interface ICustomer
    {
        bool CreateCustomer(CustomerCreate model);
        IEnumerable<CustomerList> GetCustomers();
        CustomerDetail GetCustomerById(int customerId);
        bool UpdateCustomer(CustomerEdit model);
        bool DeleteCustomer(int customerId);
    }
}
