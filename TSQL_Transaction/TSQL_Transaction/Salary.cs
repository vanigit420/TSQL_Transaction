using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAY34_TSQL_Transaction
{
    public class Salary
    {
        private static SqlConnection ConnectionSetup()
        {
            return new SqlConnection("")
        }
        public int UpdateEmployeeSalary(SalaryUpdateModel salaryupdatemodel)
        {
            SqlConnection salaryconnection = ConnectionSetup();
            int salary = 0;
            try
            {
                using (salaryconnection)
                {
                    SalaryDetailModel displayModel = new SalaryDetailModel();
                    SqlCommand command = new SqlCommand("spUpdateemployeeSalary", salaryconnection);
                    command.Parameters.AddWithValue("@id", salaryupdatemodel.SalaryId);
                    command.Parameters.AddWithValue("@month", salaryupdatemodel.Month);
                    command.Parameters.AddWithValue("@salary", salaryupdatemodel.EmployeeSalary);
                    command.Parameters.AddWithValue("@EmpId", salaryupdatemodel.EmployeeId);
                    salaryconnection.Open();

                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows())
                    {
                        while (dr.Read())
                        {
                            displayModel.EmployeeId = Convert.ToInt32(0);
                            displayModel.EmployeeName = Convert.ToString(1);
                            displayModel.JobDescription = Convert.ToString(2);
                            displayModel.EmployeeSalary = Convert.ToInt32(3);
                            displayModel.Month = Convert.ToString(4);
                            displayModel.SalaryId = Convert.ToInt32(5);

                            Console.WriteLine("{0}, {1}, {2} ", displayModel.EmployeeName, displayModel.EmployeeSalary, displayModel.EmployeeId);
                            salary = displayModel.EmployeeSalary;
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");

                    }
                    dr.Close();
                    salaryconnection.Close();

                }

            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
            finally
            { salaryconnection.Close(); }
            return salary;
        }
    }
}