using Projekat.Core.Domain.Entities;

namespace Projekat.Core.Domain
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(Guid id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);  
        void SaveChanges();
    }  
}