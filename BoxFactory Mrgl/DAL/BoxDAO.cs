using System.Data.SqlClient;
using BoxFactory_Mrgl.Models;
using Dapper;

namespace BoxFactory_Mrgl.DAL
{
    public class BoxDAO
    {
        string connectionstring = DBConfig.GetInstance().ConnectionString;

        public BoxModel Create(decimal length, decimal width, decimal height, decimal price)
        {
            int newID;
            using (var connection = new SqlConnection(connectionstring))
            {
                var sql = $@"
                INSERT INTO Box (Length, Width, Height, Price) 
                OUTPUT INSERTED.BoxID
                VALUES (@length, @width, @height, @price)
                ";

                newID = connection.QuerySingle<int>(sql, new { length, width, height, price });
            }

            return Read(newID);
        }

        public BoxModel Read(int BoxId)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                var sql = $@"
                SELECT 
                BoxId as {nameof(BoxModel.BoxId)},
                Length as {nameof(BoxModel.Length)},
                Height as {nameof(BoxModel.Height)},
                Width as {nameof(BoxModel.Width)},
                Price as {nameof(BoxModel.Price)}
                FROM Box
                Where BoxId = @Boxid";
                try
                {
                    return connection.QueryFirst<BoxModel>(sql, new { BoxId });
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
        public List<BoxModel> ReadAll()
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                var sql = $@"
                SELECT 
                BoxId as {nameof(BoxModel.BoxId)},
                Length as {nameof(BoxModel.Length)},
                Height as {nameof(BoxModel.Height)},
                Width as {nameof(BoxModel.Width)},
                Price as {nameof(BoxModel.Price)}
                FROM Box";
                return connection.Query<BoxModel>(sql).ToList();
            }
        }

        public BoxModel Update(int id, decimal length, decimal width, decimal height, decimal price)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                var sql = $@"
                UPDATE BOX
                SET
                Length = @length,
                Width = @width,
                Height = @height,
                Price = @price
                WHERE BoxId = @id
                ";
                var rowsEffected = connection.Execute(sql, new { length, width, height, price, id });

                if (rowsEffected == 0)
                {
                    return null;
                }
                return Read(id);
            }
        }

        public bool Delete(int id)
        {
            bool deleted = false;
            using (var connection = new SqlConnection(connectionstring))
            {
                var sql = $@"
                DELETE Box
                WHERE BoxId = @id
                ";

                deleted = connection.Execute(sql, new { id }) == 1;
            }
            return deleted;            
        }
    }
}
