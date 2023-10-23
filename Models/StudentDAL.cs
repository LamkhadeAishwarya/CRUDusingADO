using System.Data.SqlClient;

namespace CRUDusingADO.Models
{
    public class StudentDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;
        public StudentDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConection"));
        }


        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            string qry = "select * from Student";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Student stud= new Student();
                    stud.Rno = Convert.ToInt32(dr["rno"]);
                    stud.Name = dr["name"].ToString();
                    stud.City = dr["city"].ToString();
                    stud.Per = Convert.ToInt32(dr["per"]);


                    students.Add(stud);
                }
            }
            con.Close();
            return students;
        }
        public Student GetStudentByRno(int rno)
        {
            Student stud = new Student();
            string qry = "select * from Student where rno=@rno";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@rno", rno);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    stud.Rno= Convert.ToInt32(dr["rno"]);
                    stud.Name = dr["name"].ToString();
                    stud.City = dr["city"].ToString();
                    stud.Per = Convert.ToInt32(dr["per"]);


                }
            }
            con.Close();
            return stud;
        }
        public int AddStudent(Student stud)
        {
            int result = 0;
            string qry = "insert into Student values(@name,@city,@per)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", stud.Name);
            cmd.Parameters.AddWithValue("@city", stud.City);
            cmd.Parameters.AddWithValue("@per", stud.Per);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateStudent(Student stud)
        {
            int result = 0;
            string qry = "update Student set name=@name,city=@city,per=@per where rno=@rno";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", stud.Name);
            cmd.Parameters.AddWithValue("@city", stud.City);
            cmd.Parameters.AddWithValue("@per", stud.Per);
            cmd.Parameters.AddWithValue("@rno", stud.Rno);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteStudent(int rno)
        {
            int result = 0;
            string qry = "delete from Student where rno=@rno";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@rno", rno);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}

