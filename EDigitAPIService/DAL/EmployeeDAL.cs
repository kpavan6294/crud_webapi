using EDigitAPIService.Models;
using System.Data;
using System.Data.SqlClient;

namespace EDigitAPIService.DAL
{
    public class EmployeeDAL : IEmployeeDAL
    {
        string connectionString = "Data Source=PAVAN\\SQLEXPRESS;Initial Catalog=EDigitDB; Integrated Security=true";

        public List<Employee> GetAllEmployees()
        {
            List<Employee> ltEmployees = new List<Employee>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("select * from dbo.employees", sqlConnection);

                sqlCommand.CommandType = CommandType.Text;

                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Employee emp = new Employee();

                    emp.Id = Convert.ToInt32(reader["Id"]);
                    emp.Name = reader["name"].ToString();
                    emp.EmailId = reader["emailid"].ToString();
                    emp.MobileNo = reader["mobileno"].ToString();
                    emp.Salary = Convert.ToInt32(reader["salary"]);

                    ltEmployees.Add(emp);
                }
            }

            return ltEmployees;
        }

        public string AddEmployee(Employee employee)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("dbo.addemployee", sqlConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = employee.Id;
                sqlCommand.Parameters.Add("@name", SqlDbType.VarChar).Value = employee.Name;
                sqlCommand.Parameters.Add("@emailid", SqlDbType.VarChar).Value = employee.EmailId;
                sqlCommand.Parameters.Add("@mobileno", SqlDbType.VarChar).Value = employee.MobileNo;
                sqlCommand.Parameters.Add("@salary", SqlDbType.Int).Value = employee.Salary;

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }

            return "Employee Added Successfully";
        }

        public Employee GetEmployeeById(int id)
        {
            Employee emp = new Employee();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("dbo.getemployeebyid", sqlConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("@id", SqlDbType.VarChar).Value = id;

                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {

                    emp.Id = Convert.ToInt32(reader["Id"]);
                    emp.Name = reader["name"].ToString();
                    emp.EmailId = reader["emailid"].ToString();
                    emp.MobileNo = reader["mobileno"].ToString();
                    emp.Salary = Convert.ToInt32(reader["salary"]);

                }
            }

            return emp;
        }

        public string UpdateEmployee(int id, Employee employee)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("dbo.updateemployee", sqlConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = employee.Id;
                sqlCommand.Parameters.Add("@name", SqlDbType.VarChar).Value = employee.Name;
                sqlCommand.Parameters.Add("@emailid", SqlDbType.VarChar).Value = employee.EmailId;
                sqlCommand.Parameters.Add("@mobileno", SqlDbType.VarChar).Value = employee.MobileNo;
                sqlCommand.Parameters.Add("@salary", SqlDbType.Int).Value = employee.Salary;

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }

            return "Updated Employee Successfully";
        }

        public string DeleteEmployee(int id)
        {

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("delete from dbo.employees where id=@id", sqlConnection);

                sqlCommand.CommandType = CommandType.Text;

                sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;

                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();
            }

            return "Employee Deleted Successfully";
        }
    }
}