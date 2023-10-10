using BoxFactory_Mrgl.Models.Interfaces;

namespace BoxFactory_Mrgl.DAL.Interfaces
{
    public interface ILinesDAO
    {
        ILineModel create(ILineModel model);
        bool delete(int id);
        List<ILineModel> read();
        ILineModel read(int id);
        List<ILineModel> read(IOrderModel model);
        ILineModel update(ILineModel model);
    }
}
