using DomainModel.Entities;
using DomainModel.Repositories.SuperTypes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Repositories
{
    public interface ISignRepository : IRepository<Sign>
    {
        Sign GetActiveSign();
        Sign GetByEmployeeId(int idEmployee);
        void SetEmployeeSign(int idEmployee, byte[] sign);
    }
}
