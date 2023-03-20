using Projekat.Core.Domain.Entities;
using Projekat.Repositories;
using Projekat.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Projekat.Infrastructure
{
    public class EmployeeRepository<T> : IRepository<T> where T : Employee
    {
        private readonly RepositoryDbContext _dbContext;
        private DbSet<T> entities;

        public EmployeeRepository(RepositoryDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
            entities = _dbContext.Set<T>();
        }

        public T Get(Guid Id)
        {
            return entities.SingleOrDefault(c => c.Id == Id);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("employee");
            }
            entities.Add((T)entity);
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}