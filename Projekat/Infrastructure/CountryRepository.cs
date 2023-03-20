using Projekat.Core.Domain.Entities;
using Projekat.Core.Domain;
using Projekat.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Projekat.Infrastructure
{
    public class CountryRepository : ICountryRepository
    {
        private readonly RepositoryDbContext _dbContext;  
        private DbSet<Country> entities;  

        public CountryRepository(RepositoryDbContext applicationDbContext)  
        {  
            _dbContext = applicationDbContext;  
            entities = _dbContext.Set<Country>();  
        }  

         public IEnumerable<Country> GetAll()  
        {  
            return entities.AsEnumerable();  
        }  

        public Country Get(Guid countryId)
        {
            return entities.FirstOrDefault(country => country.Id == countryId);
        }

        public Country GetCountry(Guid id)//////// ovo proveri
        {
            return entities.FirstOrDefault(c => c.Id == id);
        }

        public void Create(Country country)
        {
            if(country == null)
            {
                throw new ArgumentNullException("country");
            }
            entities.Add((Country)country);
            _dbContext.SaveChanges();

        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}