using System.Data.SqlClient;

namespace DAL
{
    public class SqlConnectionData
    {
        // Tạo chuỗi kết nối cơ sở dữ liệu

        public static SqlConnection Connect()
        {
            string strcon = @"Data Source=GDIT019PC\SQLEXPRESS;Initial Catalog=QuanLySinhVien;Integrated Security=True";
            SqlConnection conn = new SqlConnection(strcon);
            return conn;
        }
    }
    

    public class DatabaseAccess
    {
        public static SqlConnection Connect()
        {
            string strcon = @"Data Source=GDIT019PC\SQLEXPRESS;Initial Catalog=QuanLySinhVien;Integrated Security=True";
            SqlConnection conn = new SqlConnection(strcon);
            return conn;
        }
    }
}
