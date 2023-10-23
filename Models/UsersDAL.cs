using System.Data.SqlClient;

namespace CRUDusingADO.Models
{
    public class UsersDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;
        public UsersDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConection"));
        }
        public int Register(Users user)
        {
            string query = "insert into Users values(@username,@email,@password)";
            cmd=new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", user.UserName);
            cmd.Parameters.AddWithValue("@email", user.Email);
            cmd.Parameters.AddWithValue("@password", user.Password);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;



        }
        public int Login(Users user)
        {
            string qry = "Select *From Users where username=@username and password=@password";
            cmd=new SqlCommand(qry, con);   
            cmd.Parameters.AddWithValue("@username", user.UserName);
            cmd.Parameters.AddWithValue ("@Password", user.Password);
            con.Open();
            cmd.ExecuteReader();
            bool result = dr.HasRows;
            con.Close ();
            if (result)
            {
                return 1;
            }
            else
            { 
                return 0;
            }
               

        }


    }
}
