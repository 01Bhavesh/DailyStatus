using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anonymous_Lambda
{
    public class Paging
    {
        public static void PaginationRawSql(int pgNumber, int noOfRows)
        {

            List<Student> students = new List<Student>();
            string connString = "Server=DESKTOP-HG3NPSB;Database=StudentPortalDb;Trusted_Connection=True";
            int recordNumber = (pgNumber - 1) * noOfRows;

            string query = $"SELECT * FROM student ORDER BY ID OFFSET {recordNumber} ROWS FETCH NEXT {noOfRows} ROWS ONLY;";

            using (SqlConnection connection = new SqlConnection(connString))
            {

                SqlCommand cmd = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Student student = new Student
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("ID")),
                            Name = reader.GetString(reader.GetOrdinal("namefirst"))
                        };


                        students.Add(student);
                    }

                    foreach (var student in students)
                    {
                        Console.WriteLine($"ID: {student.ID}, Name: {student.Name}");
                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }



        }
    }
}
