using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainModel.Entities;
using DomainModel.Repositories;
using System.Threading.Tasks;

namespace ApplicationJournal
{
    public interface IRecordService
    {
        IEnumerable<Record> GetPageRecords(int startDescNumber = 0, int pageSize = 1000);
    }

    public class RecordService : IRecordService
    {
        IRecordRepository _recordRepository;
        public RecordService(IRecordRepository recordRepository)
        {
            _recordRepository = recordRepository;
        }

        public IEnumerable<Record> GetPageRecords(int startDescNumber = 0, int pageSize = 1000)
        {
            return _recordRepository.GetPageRecords(startDescNumber, pageSize);
        }
    }
}
