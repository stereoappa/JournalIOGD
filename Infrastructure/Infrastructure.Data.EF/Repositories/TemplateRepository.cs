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
    public class TemplateRepository : ITemplateRepository
    {
        string _connectionString;
        public TemplateRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public TemplateFile Add(TemplateFile template)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("FileData", template.FileData, DbType.Binary, ParameterDirection.Input);
            p.Add("HashMd5", template.HashMd5, DbType.String, ParameterDirection.Input);
            p.Add("TemplateTypeId", (int)template.TemplateType.TypeId, DbType.Int32, ParameterDirection.Input);
            p.Add("EmployeeFID", template.WhoUpload.IdEmployee, DbType.Int32, ParameterDirection.Input);

            using (var con = new SqlConnection(_connectionString))
            {
                var res = con.Query<TemplateFile, TemplateType, Employee, TemplateFile>("dbo.AddTemplate",
                    (file, type, emp) =>
                    {
                        file.TemplateType = type;
                        file.WhoUpload = emp;

                        return file;
                    },
                    param: p,
                    commandType: CommandType.StoredProcedure,
                    splitOn: "TypeId, IdEmployee").FirstOrDefault();

                if (res == null)
                    throw new Exception("Не удалось загрузить шаблон документа");

                return res;
            }
        }

        /// <summary>
        /// Получить последние версии всех шаблонов
        /// </summary>
        /// <returns></returns>
        public TemplateFile GetActualTemplate(TemplateTypeId templateTypeId, bool withData)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("TemplateTypeId", (int)templateTypeId, DbType.Int32, ParameterDirection.Input);
            p.Add("WithData", withData, DbType.Boolean, ParameterDirection.Input);

            using (var con = new SqlConnection(_connectionString))
            {
                con.Open();
                return con.Query<TemplateFile, TemplateType, Employee, TemplateFile>("dbo.GetActualTemplate",
                    (file, type, emp) =>
                    {
                        file.TemplateType = type;
                        file.WhoUpload = emp;

                        return file;
                    },
                    splitOn: "TypeId, IdEmployee",
                    param: p,
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public List<TemplateType> GetTemplateTypes()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                con.Open();
                return con.Query<TemplateType>("dbo.GetTemplateTypes")?.ToList();
            }
        }

        #region not-implemented
        public void Save(TemplateFile entity)
        {
            //DB LOADING
            throw new NotImplementedException();
        }
        public IEnumerable<TemplateFile> GetAll()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
