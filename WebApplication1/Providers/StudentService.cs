using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Providers
{
    public class StudentService
    {
        public IEnumerable<Student> GetStudents()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["StudentConnection"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SelectStudents", connection))
                {
                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Student> students = new List<Student>();

                        while (reader.Read())
                        {
                            students.Add(new Student()
                            {
                                Id = (int)reader["id"],
                                Name = (string)reader["name"],
                                Email = (string)reader["email"]
                            });
                        }

                        return students;
                    }
                }
            }
        }

        public Student GetStudentById(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["StudentConnection"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SelectStudentById", connection))
                {
                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);
                    
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            return new Student()
                            {
                                Id = (int)reader["id"],
                                Name = (string)reader["name"],
                                Email = (string)reader["email"]
                            };
                        }

                        return null;
                    }
                }
            }
        }

        public int AddStudent(Student student)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["StudentConnection"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("InsertStudent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", student.Name);
                    command.Parameters.AddWithValue("@email", student.Email);

                    try
                    {
                        connection.Open();
                        int totalRecordInserted = command.ExecuteNonQuery();
                        return totalRecordInserted;
                    }
                    catch(SqlException e)
                    {
                        return -1;
                    }
                }
            }
        }

        public int UpdateStudent(int id, Student student)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["StudentConnection"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("UpdateStudentById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@name", student.Name);
                    command.Parameters.AddWithValue("@email", student.Email);

                    try
                    {
                        connection.Open();
                        int totalRecordUpdated = command.ExecuteNonQuery();
                        return totalRecordUpdated;
                    }
                    catch (SqlException e)
                    {
                        return -1;
                    }
                }
            }
        }

        public int DeleteStudent(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["StudentConnection"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("DeleteStudentById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);

                    try
                    {
                        connection.Open();
                        int totalRecordDeleted = command.ExecuteNonQuery();
                        return totalRecordDeleted;
                    }
                    catch (SqlException exception)
                    {
                        return -1;
                    }
                }
            }
        }
    }
}