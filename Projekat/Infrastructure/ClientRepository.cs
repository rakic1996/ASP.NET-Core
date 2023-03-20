using Projekat.Core.Domain;
using Projekat.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

using Projekat.Repositories;

namespace Projekat.Infrastructure
{
    public class ClientRepository<T> : IRepository<T> where T : Client
    {
        private readonly RepositoryDbContext _dbContext;
        private DbSet<T> entities;

        public ClientRepository(RepositoryDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
            entities = _dbContext.Set<T>();
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

        public T Get(Guid Id)
        {
            return entities.SingleOrDefault(c => c.Id == Id);
        }

        public IEnumerable<T> GetAll()
        {
            Console.WriteLine(entities.AsEnumerable());
            return entities.AsEnumerable();
        }

        public void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
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

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _dbContext.SaveChanges();
        }
    }
}