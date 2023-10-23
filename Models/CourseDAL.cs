using System.Data.SqlClient;

namespace CRUDusingADO.Models
{
    public class CourseDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;
        public CourseDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConection"));
        }


        public List<Course> GetCourse()
        {
            List<Course> courses = new List<Course>();
            string qry = "select * from Course";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Course cor = new Course();
                    cor.Id= Convert.ToInt32(dr["id"]);
                    cor.Name = dr["name"].ToString();
                    cor.Fees = Convert.ToInt32(dr["fees"]);
                    cor.Duration = (dr["duration"].ToString());


                    courses.Add(cor);
                }
            }
            con.Close();
            return courses;
        }
        public Course GetCourseById(int id)
        {
            Course cor = new Course();
            string qry = "select * from Course where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    cor.Id = Convert.ToInt32(dr["id"]);
                    cor.Name = dr["name"].ToString();
                    cor.Fees = Convert.ToInt32(dr["fees"]);
                    cor.Duration = dr["duration"].ToString();

                }
            }
            con.Close();
            return cor;
        }
        public int AddCourse(Course cor)
        {
            int result = 0;
            string qry = "insert into Course values(@name,@fees,@duration)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", cor.Name);
            cmd.Parameters.AddWithValue("@fees", cor.Fees);
            cmd.Parameters.AddWithValue("@duration", cor.Duration);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateCourse(Course cor)
        {
            int result = 0;
            string qry = "update Course set name=@name,fees=@fees,duration=@duration where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", cor.Name);
            cmd.Parameters.AddWithValue("@fees", cor.Fees);
            cmd.Parameters.AddWithValue("@duration", cor.Duration);
            cmd.Parameters.AddWithValue("@id", cor.Id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteCourse(int id)
        {
            int result = 0;
            string qry = "delete from Course where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}


    

