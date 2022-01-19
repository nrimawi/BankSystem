

using Common;
using DAL;

namespace Business
{
    class BCustomer : ICustomer
    {
        public void deleteCustomer(Guid id)
        {
            CustomerRepo customerRepo = new CustomerRepo();
            customerRepo.deleteCustomer(id);

        }

        public CustomerData getCustomerById(Guid id)
        {
            CustomerRepo customerRepo = new CustomerRepo();
            return customerRepo.getCustomerById(id);
        }

        public void saveCustomer(CustomerData customer)
        {
            CustomerRepo customerRepo = new CustomerRepo();
            customerRepo.saveCustomer(customer);
               
        }

        public void updateCustomer(CustomerData customer)
        {
            CustomerRepo customerRepo = new CustomerRepo();
            customerRepo.updateCustomer(customer);
        }
    }
}
