using BoxFactory_Mrgl.DAL.Interfaces;
using BoxFactory_Mrgl.Models.Interfaces;
namespace BoxFactory_Mrgl.DAL
{
   
    public class DBFacade : IDBFacade
    {
        private ICustomersDAO customersDAO = new CustomersDAO();
        private ILinesDAO linesDAO = new LinesDAO();

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

        public ILineModel CreateLine(ILineModel model)
        {
            return linesDAO.create(model);
        }

        public List<ILineModel> ReadAllLines()
        {
            return linesDAO.read();
        }

        public List<ILineModel> ReadAllLinesForOrder(IOrderModel model)
        {
            return linesDAO.read(model);
        }
        public ILineModel ReadLine(int line)
        {
            return linesDAO.read(line);
        }
        public ILineModel UpdateLine(ILineModel model)
        {
            return linesDAO.update(model);
        }
        public bool DeleteLine(int line)
        {
            return linesDAO.delete(line);
        }
    }
}
