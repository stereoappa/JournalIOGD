using Dapper;
using DomainModel.Entities;
using DomainModel.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.EF.Repositories
{
    public class RecordRepository : IRecordRepository
    {
        string _connectionString;
        public RecordRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public Record Add(Record record)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Record> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Record> GetPageRecords(int startDescNumber, int pageSize)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                con.Open();

                DynamicParameters p = new DynamicParameters();
                p.Add("startDescId", startDescNumber, DbType.Int32, ParameterDirection.Input);
                p.Add("pageSize", pageSize, DbType.Int32, ParameterDirection.Input);

                //return con.Query<Record>("dbo.GetPageRecords", param: p, commandType: CommandType.StoredProcedure);
                return con.Query<Record, RecordType, Employee, Client, Organization, IdentityDocument, InfoType, Record>("dbo.GetPageRecords",
                    (record, rectype, empl, client, org, idnDoc, infoType) =>
                    {
                        record.RecordType = rectype;
                        record.Owner = empl;

                        client.ClientOrganization = org;
                        client.IdentityDocument = idnDoc;
                        record.Client = client;

                        record.InfoType = infoType;
                        return record;
                    },
                    splitOn: "IdDocumentType, IdEmployee, IdClient, IdOrganization, TypeIdentity, IdInfoType",
                    param: p,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void Save(Record entity)
        {
            throw new NotImplementedException();
        }
    }
}
