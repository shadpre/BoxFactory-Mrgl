using BoxFactory_Mrgl.DAL.Interfaces;
using BoxFactory_Mrgl.Models.Interfaces;
namespace BoxFactory_Mrgl.DAL
{   

    public class DBFacade : IDBFacade
    {
        private ICustomersDAO customersDAO = new CustomersDAO();

        public ICustomerModel CreateCustomer(ICustomerModel model)
        {
            return customersDAO.create(model);
        }

        public bool DeleteCustomer(int customerId)
        {
            return customersDAO.delete(customerId);
        }

        public List<ICustomerModel> ReadCustomers()
        {
            return customersDAO.read();
        }

        public ICustomerModel ReadCustomer(int customerId)
        {
            return customersDAO.read(customerId);
        }

        public ICustomerModel UpdateCustomer(ICustomerModel model)
        {
            return customersDAO.update(model);
        }
    }
}
