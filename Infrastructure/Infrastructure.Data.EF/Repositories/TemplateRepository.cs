using DomainModel.Entities;
using DomainModel.Repositories;
using System;
using System.Collections.Generic;
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

        public TemplateFile Add(TemplateFile entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TemplateFile> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save(TemplateFile entity)
        {
            //DB LOADING
            throw new NotImplementedException();
        }
    }
}
