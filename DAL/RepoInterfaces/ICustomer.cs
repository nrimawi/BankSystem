using Common;
namespace DAL
{
     interface ICustomer
    {
        CustomerData getCustomerById(Guid id);
        void saveCustomer(CustomerData customer);
        void deleteCustomer(Guid id);

        void updateCustomer(CustomerData customer); 

   
    }
}
