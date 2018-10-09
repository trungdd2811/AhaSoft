using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Common.DomainObjects.Interfaces
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
        T Add(T entity);
        T Update(T entity);
        int Delete(T entity);
    }
}
