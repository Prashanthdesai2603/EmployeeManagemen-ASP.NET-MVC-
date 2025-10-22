using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EmployeeManagement.Models;

namespace EmployeeManagement.DAL
{
    public class EmployeeRepository
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=EmployeeDB;Integrated Security=True;Connect Timeout=30";


        public List<Employee> GetAllEmployees()
        {
            var employees = new List<Employee>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Employees";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    employees.Add(new Employee
                    {
                        EmployeeId = (int)reader["EmployeeId"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Department = reader["Department"].ToString(),
                        DateOfJoining = reader["DateOfJoining"] as DateTime?,
                        Salary = reader["Salary"] as decimal?
                    });
                }
            }
            return employees;
        }

        public Employee GetEmployeeById(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Employees WHERE EmployeeId=@EmployeeId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmployeeId", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Employee
                    {
                        EmployeeId = (int)reader["EmployeeId"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Department = reader["Department"].ToString(),
                        DateOfJoining = reader["DateOfJoining"] as DateTime?,
                        Salary = reader["Salary"] as decimal?
                    };
                }
                return null;
            }
        }

        public int Create(Employee emp)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Employees 
                                (FirstName, LastName, Email, Phone, Department, DateOfJoining, Salary)
                                VALUES (@FirstName, @LastName, @Email, @Phone, @Department, @DateOfJoining, @Salary)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
                cmd.Parameters.AddWithValue("@LastName", emp.LastName);
                cmd.Parameters.AddWithValue("@Email", emp.Email);
                cmd.Parameters.AddWithValue("@Phone", emp.Phone);
                cmd.Parameters.AddWithValue("@Department", emp.Department);
                cmd.Parameters.AddWithValue("@DateOfJoining", emp.DateOfJoining ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Salary", emp.Salary ?? (object)DBNull.Value);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public void Update(Employee emp)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Employees 
                                 SET FirstName=@FirstName, LastName=@LastName, Email=@Email, Phone=@Phone, 
                                     Department=@Department, DateOfJoining=@DateOfJoining, Salary=@Salary
                                 WHERE EmployeeId=@EmployeeId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmployeeId", emp.EmployeeId);
                cmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
                cmd.Parameters.AddWithValue("@LastName", emp.LastName);
                cmd.Parameters.AddWithValue("@Email", emp.Email);
                cmd.Parameters.AddWithValue("@Phone", emp.Phone);
                cmd.Parameters.AddWithValue("@Department", emp.Department);
                cmd.Parameters.AddWithValue("@DateOfJoining", emp.DateOfJoining ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Salary", emp.Salary ?? (object)DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Employees WHERE EmployeeId=@EmployeeId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmployeeId", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
