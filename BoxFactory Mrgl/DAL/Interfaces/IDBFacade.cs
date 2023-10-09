using BoxFactory_Mrgl.Models.Interfaces;

namespace BoxFactory_Mrgl.DAL.Interfaces
{
    public interface IDBFacade
    {
        ICustomerModel CreateCustomer(ICustomerModel model);
        bool DeleteCustomer(int customerId);
        ICustomerModel ReadCustomer(int customerId);
        List<ICustomerModel> ReadCustomers();
        ICustomerModel UpdateCustomer(ICustomerModel model);
    }
}
