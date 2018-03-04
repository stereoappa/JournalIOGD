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
    public class UserRepository : IUserRepository
    {
        string _connectionString;
        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Employee SignIn(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
                return null;

            DynamicParameters p = new DynamicParameters();
            p.Add("Login", login, DbType.String, ParameterDirection.Input);
            p.Add("Password", password, DbType.String, ParameterDirection.Input);

            using (var con = new SqlConnection(_connectionString))
            {
                con.Open();
                return con.Query<Employee>("dbo.EmployeeGetByAuth", param: p, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }      
    }
}
