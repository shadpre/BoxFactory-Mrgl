using BoxFactory_Mrgl.DAL.Interfaces;
using BoxFactory_Mrgl.Models;
using BoxFactory_Mrgl.Models.Interfaces;
using Dapper;
using System.Data.SqlClient;
namespace BoxFactory_Mrgl.DAL
{
    
    public class LinesDAO : ILinesDAO
    {
        private string connectionstring = DBConfig.GetInstance().ConnectionString;
        public ILineModel create(ILineModel model)
        {
            string connectionstring = DBConfig.GetInstance().ConnectionString;

            int newId;
            using (var connection = new SqlConnection(connectionstring))
            {
                var sql = $@"
                INSERT INTO Lines (Item, QTY, DiscountPCT, OrderId)
                OUTPUT INSERTED.LineId
                Values (@item, @qty, @discountPCT, @orderid)
                ";

                newId = connection.QuerySingle<int>(sql, new { model.Item, model.QTY, model.DiscountPCT, model.OrderId });

                return read(newId);
            }

        }
        public List<ILineModel> read()
        {
            List<ILineModel> result = new List<ILineModel>();
            using (var connection = new SqlConnection(connectionstring))
            {
                var sql = $@"
                SELECT
                [LineId] as {nameof(ILineModel.LineID)},
                [Item] as {nameof(ILineModel.Item)},
                [QTY] as {nameof(ILineModel.QTY)},
                [DiscountPCT] as {nameof(ILineModel.DiscountPCT)},
                [GrossPrice] as {nameof(ILineModel.GrossPrice)},
                [NetPrice] as {nameof(ILineModel.NetPrice)},
                [Total] as {nameof(ILineModel.Total)},
                [OrderId] as {nameof(ILineModel.OrderId)}
                FROM
                Lines
                ";

                try
                {
                    var output = connection.Query<LineModel>(sql).ToList();
                    result.AddRange(output);
                }
                catch (Exception)
                {

                    return null;
                }
                return result;
            }
        }
        public List<ILineModel> read(IOrderModel model)
        {
            List<ILineModel> result = new List<ILineModel>();
            using (var connection = new SqlConnection(connectionstring))
            {
                var sql = $@"
                SELECT
                [LineId] as {nameof(ILineModel.LineID)},
                [Item] as {nameof(ILineModel.Item)},
                [QTY] as {nameof(ILineModel.QTY)},
                [DiscountPCT] as {nameof(ILineModel.DiscountPCT)},
                [GrossPrice] as {nameof(ILineModel.GrossPrice)},
                [NetPrice] as {nameof(ILineModel.NetPrice)},
                [Total] as {nameof(ILineModel.Total)},
                [OrderId] as {nameof(ILineModel.OrderId)}
                FROM
                Lines
                WHERE [OrderId] = @orderid
                ";

                try
                {
                    var output = connection.Query<LineModel>(sql, new { model.OrderID }).ToList();
                    result.AddRange(output);
                }
                catch (Exception)
                {

                    return null;
                }
                return result;
            }
        }
        public ILineModel read(int id)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                var sql = $@"
                SELECT
                [LineId] as {nameof(ILineModel.LineID)},
                [Item] as {nameof(ILineModel.Item)},
                [QTY] as {nameof(ILineModel.QTY)},
                [DiscountPCT] as {nameof(ILineModel.DiscountPCT)},
                [GrossPrice] as {nameof(ILineModel.GrossPrice)},
                [NetPrice] as {nameof(ILineModel.NetPrice)},
                [Total] as {nameof(ILineModel.Total)},
                [OrderId] as {nameof(ILineModel.OrderId)}
                FROM
                Lines
                WHERE LineId = @lineid
                ";
                try
                {
                    return connection.QuerySingle<LineModel>(sql, new { id });
                }
                catch (Exception)
                {
                    return null;
                }

            }
        }
        public ILineModel update(ILineModel model)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                var sql = $@"
                UPDATE Lines
                SET item = @item,
                QTY = @qty,
                DiscountPCT = @discountpct
                Where LineId = @lineId
                ";

                if (connection.Execute(sql, new { model.Item, model.QTY, model.DiscountPCT, model.LineID }) == 1)
                {
                    return read(model.LineID);
                }
                else return null;
            }
        }
        public bool delete(int id)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                var sql = $@"
                DELETE Lines WHERE LineId = @LineId
                ";
                return connection.Execute(sql, new { id }) == 1;
            }
        }

    }
}
