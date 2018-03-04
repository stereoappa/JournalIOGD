using DomainModel.Entities;
using DomainModel.Repositories.SuperTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Repositories
{
    public interface IRecordRepository : IRepository<Record>
    {
        IEnumerable<Record> GetPageRecords(int startDescNumber, int pageSize);
    }
}
