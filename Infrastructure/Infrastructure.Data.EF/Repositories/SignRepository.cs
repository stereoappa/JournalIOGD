using Dapper;
using DomainModel.Entities;
using DomainModel.Repositories;
using DomainModel.Repositories.SuperTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.EF.Repositories
{
    public class SignRepository : ISignRepository
    {
        string _connectionString;
        public SignRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        readonly string RET_V = "@ReturnVal";
        public Sign GetActiveSign()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                con.Open();
                return con.Query<Sign, Employee, Sign>("dbo.GetActiveSign",
                    (sign, employee) =>
                    {
                        sign.Owner = employee;
                        return sign;
                    }, 
                    splitOn: "IdEmployee", 
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public Sign Add(Sign entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sign> GetAll()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                con.Open();
                return con.Query<Sign, Employee, Sign> ("dbo.GetAllSigns",
                    (sign, employee) =>
                    {
                        sign.Owner = employee;
                        return sign;
                    },
                    splitOn: "IdEmployee", 
                    commandType: CommandType.StoredProcedure);
            }
        }

        public Sign GetByEmployeeId(int idEmployee)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("IdEmployee", idEmployee, DbType.Int32, ParameterDirection.Input);

            using (var con = new SqlConnection(_connectionString))
            {
                con.Open();
                return con.Query<Sign, Employee, Sign>("dbo.GetSignByIdEmployee",
                    (sign, employee) =>
                    {
                        sign.Owner = employee;
                        return sign;
                    },
                    splitOn: "IdEmployee",
                    param: p, 
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public void Save(Sign sign)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("Id", sign.Id, DbType.Int32, ParameterDirection.Input);
            p.Add("IsActive", sign.IsActive, DbType.Boolean, ParameterDirection.Input);
            p.Add("SignImage", sign.SignImage, DbType.Binary, ParameterDirection.Input);

            p.Add(RET_V, DbType.Int32, direction: ParameterDirection.ReturnValue);
            using (var con = new SqlConnection(_connectionString))
            {
                con.Execute("dbo.SaveSign", p, commandType: CommandType.StoredProcedure);
                if (p.Get<int>(RET_V) != 0)
                    throw new Exception("Не удалось сохранить подпись");
            }
        }

        public void SetEmployeeSign(int idEmployee, byte[] sign)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("IdEmployee", idEmployee, DbType.Int32, ParameterDirection.Input);
            p.Add("SignImage", sign, DbType.Binary, ParameterDirection.Input);
            p.Add(RET_V, DbType.Int32, direction: ParameterDirection.ReturnValue);

            using (var con = new SqlConnection(_connectionString))
            {
                con.Execute("dbo.SetEmployeeSign", p, commandType: CommandType.StoredProcedure);
                if (p.Get<int>(RET_V) == 0)
                    return;
                throw new Exception("Не удалось задать подпись сотруднику");
            }
        }
    }
}
