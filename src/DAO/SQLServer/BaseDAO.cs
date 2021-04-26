using System.Data.SqlClient;

namespace DAO.SQLServer
{
    public class BaseDAO
    {
        protected string ConnectionString => @"Server=.\sqlexpress;Integrated Security=true;Initial Catalog=master;";
        protected SqlConnection Connection => new SqlConnection(ConnectionString);
    }
}