using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModel.Repositories.SuperTypes
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);

        /// <summary>
        /// Return all entites
        /// </summary>
        /// <returns>Entities</returns>
        IEnumerable<T> GetAll();

        void Save(T entity);
    }
}
