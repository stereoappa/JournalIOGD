using DomainModel.Entities;
using DomainModel.Repositories.SuperTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.Repositories
{
    public interface ITemplateRepository : IRepository<TemplateFile>
    {
        List<TemplateType> GetTemplateTypes();
        TemplateFile GetActualTemplate(TemplateTypeId type, bool withData);
    }
}
