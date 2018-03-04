using Dapper;
using DomainModel.Entities;
using DomainModel.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Infrastructure.Data.EF.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        string _connectionString;
        public EmployeeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Employee Add(Employee entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAll(bool includingDismissed)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("IncludingDismissed", includingDismissed, DbType.Boolean, ParameterDirection.Input);

            using (var con = new SqlConnection(_connectionString))
            {
                con.Open();
                return con.Query<Employee>("dbo.GetAllEmployees", p, commandType: CommandType.StoredProcedure);
            }
        }

        public void Save(Employee employee)
        {
            
            DynamicParameters p = new DynamicParameters();
            p.Add("IdEmployee", employee.IdEmployee, DbType.Int32, ParameterDirection.Input);
            p.Add("FirstName", employee.FirstName, DbType.String, ParameterDirection.Input);
            p.Add("SecondName", employee.SecondName, DbType.String, ParameterDirection.Input);
            p.Add("ThirdName", employee.ThirdName, DbType.String, ParameterDirection.Input);
            p.Add("ShortName", employee.ShortName, DbType.String, ParameterDirection.Input);
            p.Add("Post", employee.Post, DbType.String, ParameterDirection.Input);

            using (var con = new SqlConnection(_connectionString))
            {
                con.Open();
                con.Execute("dbo.EmployeeSave", p, commandType: CommandType.StoredProcedure);
            }
        }

       

        public IEnumerable<Employee> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
