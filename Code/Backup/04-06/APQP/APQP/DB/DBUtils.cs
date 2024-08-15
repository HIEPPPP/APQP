using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APQP.DB
{
    public static class DBUtils
    {
        public static string _stringConnection = @"Data Source=172.17.140.55;Initial Catalog=APQP;Persist Security Info=True;User ID=sa;Password=H9401811cv2";
        public static System.Data.DataTable _getData(string _query)
        {
            try
            {
                using (SqlConnection _conn = new SqlConnection(_stringConnection))
                {
                    _conn.Open();
                    DataTable _data = new DataTable();
                    SqlDataAdapter _adapter = new SqlDataAdapter(_query, _conn);
                    _adapter.Fill(_data);
                    _conn.Close();
                    return _data;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }
}
