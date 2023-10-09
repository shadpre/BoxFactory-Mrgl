using BoxFactory_Mrgl.Models.Interfaces;
using Microsoft.Identity.Client;
using System.Data.SqlClient;
using Dapper;
using BoxFactory_Mrgl.Models;
using BoxFactory_Mrgl.DAL.Interfaces;

namespace BoxFactory_Mrgl.DAL
{
    

    public class CustomersDAO : ICustomersDAO
    {
        private string connectionstring = DBConfig.GetInstance().ConnectionString;
        public ICustomerModel create(ICustomerModel imodel)
        {
            CustomerModel model = (CustomerModel)imodel;
            int Id = 0;
            using (var connection = new SqlConnection(connectionstring))
            {
                var sql = $@"
                INSERT INTO Customers (Name, Phone) 
                OUTPUT INSERTED.CustomerId
                VALUES (@name, @phone)
                ";
                Id = connection.QuerySingle<int>(sql, new { model.Name, model.Phone });
            }
            try
            {
                Console.WriteLine(Id);
                return read(Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public List<ICustomerModel> read()
        {
            List<ICustomerModel> result = new List<ICustomerModel>();
            using (var connection = new SqlConnection(connectionstring))
            {
                string sql = $@"
                SELECT
                [CustomerId] as {nameof(ICustomerModel.CustomerId)},
                [Name] as {nameof(ICustomerModel.Name)},
                [Phone] as {nameof(ICustomerModel.Phone)}
                FROM
                [dbo].[Customers]
                ";

                try
                {
                    var output = connection.Query<CustomerModel>(sql).ToList();
                    result.AddRange(output);
                }
                catch (SqlException ex)
                {
                    return null;
                }
                return result;
            }
        }
        public ICustomerModel read(int customerId)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                string sql = $@"
                SELECT
                [CustomerId] as {nameof(ICustomerModel.CustomerId)},
                [Name] as {nameof(ICustomerModel.Name)},
                [Phone] as {nameof(ICustomerModel.Phone)}
                FROM
                [dbo].[Customers]
                WHERE [CustomerId] = @customerId
                ";

                try
                {
                    Console.WriteLine(sql);
                    Console.WriteLine(customerId);
                    return connection.QueryFirst<CustomerModel>(sql, new { customerId });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }
        public ICustomerModel update(ICustomerModel model)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                var sql = $@"
                UPDATE [dbo].[Customers]
                SET
                [Name] = @name,
                [Phone] = @phone
                WHERE
                [CustomerId] = @CustomerId
                ";
                if (connection.Execute(sql, new { model.Name, model.Phone, model.CustomerId }) == 1)
                {
                    return read(model.CustomerId);
                }
                else return null;
            }
        }
        public bool delete(int id)
        {
            bool deleted = false;
            using (var connection = new SqlConnection(connectionstring))
            {
                var sql = $@"
                DELETE [dbo].[Customers]
                WHERE [CustomerId] = @id
                ";

                deleted = connection.Execute(sql, new { id }) == 1;
            }
            return deleted;
        }
    }
}
