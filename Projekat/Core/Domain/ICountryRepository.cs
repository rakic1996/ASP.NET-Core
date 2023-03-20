
using Projekat.Core.Domain.Entities;

namespace Projekat.Core.Domain
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetAll();
        Country GetCountry(Guid id);
        void Create(Country country);
        void SaveChanges();
    }
}