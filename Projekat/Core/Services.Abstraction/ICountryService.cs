using Projekat.Core.Contract;
using Projekat.Core.Domain.Entities;

namespace Projekat.Core.Services.Abstraction
{
    public interface ICountryService
    {
        IEnumerable<Country> GetAllCountries();
        Country GetCountry(Guid id);
        Country InsertCountry(CountryDtoInsert country);
    }
}