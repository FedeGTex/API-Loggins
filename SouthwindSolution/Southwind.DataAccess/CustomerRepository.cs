using Dapper;
using Southwind.Models;
using Southwind.Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Southwind.DataAccess
{
    public class CustomerRepository:Repository<Customer>, ICustomerRepository
    {
        //La clase padre Repository requiere en su constructor la cadena de conexión, se la enviamos.
        //base representa a la clase padre Repository
        public CustomerRepository(string connectionString) : base(connectionString)
        {

        }

        public IEnumerable<Customer> CustomerPageList(int page, int rows)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@page", page);
            parameters.Add("@rows", rows);

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Customer>("dbo.CustomerPagedList",
                                                 parameters,
                                                 commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
