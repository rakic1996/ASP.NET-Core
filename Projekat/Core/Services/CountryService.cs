using Projekat.Core.Services.Abstraction;
using Projekat.Core.Domain.Entities;
using Projekat.Core.Domain.Exception;
using Projekat.Core.Domain;
using Projekat.Core.Contract;
using Microsoft.AspNetCore.Mvc;

namespace Projekat.Core.Services
{
    public class CountryService : ICountryService
    {
        private ICountryRepository _repository;

        public CountryService(ICountryRepository repository)  
        {  
            _repository = repository;  
        } 

        public IEnumerable<Country> GetAllCountries()  
         {  
            return _repository.GetAll();  
        }  

        public Country GetCountry(Guid countryId) 
        {
            Country gotCountry = _repository.GetCountry(countryId);

            if (gotCountry is null)
            {
                throw new CountryNotFoundException(countryId);
            }else
            {
            return gotCountry;
            }
        }

        public Country InsertCountry([FromBody] CountryDtoInsert dto)
        {
            Country country = new Country(Guid.NewGuid(), dto.Name);
            _repository.Create(country);
            _repository.SaveChanges();
            return country;           
        } 
    }
}
