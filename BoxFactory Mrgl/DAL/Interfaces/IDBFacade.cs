using BoxFactory_Mrgl.Models.Interfaces;

namespace BoxFactory_Mrgl.DAL.Interfaces
{
    public interface IDBFacade
    {
        ICustomerModel CreateCustomer(ICustomerModel model);
        ILineModel CreateLine(ILineModel model);
        bool DeleteCustomer(int customerId);
        bool DeleteLine(int line);
        List<ILineModel> ReadAllLines();
        List<ILineModel> ReadAllLinesForOrder(IOrderModel model);
        ICustomerModel ReadCustomer(int customerId);
        List<ICustomerModel> ReadCustomers();
        ILineModel ReadLine(int line);
        ICustomerModel UpdateCustomer(ICustomerModel model);
        ILineModel UpdateLine(ILineModel model);
    }
}
