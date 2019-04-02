﻿using DomainModel.Entities;
using DomainModel.Repositories.SuperTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.Repositories
{
    public interface ITemplateRepository : IRepository<TemplateFile>
    {
        
    }
}
