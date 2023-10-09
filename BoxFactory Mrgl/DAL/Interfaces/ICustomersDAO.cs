using BoxFactory_Mrgl.Models.Interfaces;

namespace BoxFactory_Mrgl.DAL.Interfaces
{
    public interface ICustomersDAO
    {
        ICustomerModel create(ICustomerModel model);
        bool delete(int id);
        List<ICustomerModel> read();
        ICustomerModel read(int id);
        ICustomerModel update(ICustomerModel model);
    }
}
