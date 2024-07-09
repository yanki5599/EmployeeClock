using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace EmployeeClock.DAL
{
    internal class DBContext
    {
        private readonly string _connectionString;

        public DBContext(string connectionString) 
        { 
            _connectionString = connectionString;
        }

        public DataTable? MakeQuery(string queryStr)
        {
            DataTable output = new DataTable();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(queryStr,conn)) 
                {
                    try
                    {
                        conn.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd)) 
                        {
                            adapter.Fill(output);
                        }
                    }
                    catch (SqlException ex) 
                    {
                        Console.WriteLine("An error occured: " + ex.Message);
                        return null;
                    }
                }
            }

            return output;
        }
    }
}
