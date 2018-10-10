using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common.DomainObjects.Interfaces
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<bool> AnyAsync(int id);
    }
}
