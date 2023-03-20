using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Projekat.Infrastructure;
using Projekat.Core.Services.Abstraction;
using Projekat.Core.Contract;
using Projekat.Core.Domain.Entities;

namespace Projekat.Controllers
{
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService; 
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public IActionResult GetAllCountries()  
        {  
            var result = _countryService.GetAllCountries();   

            return Ok(result);  
        }

       [HttpGet("{id}")]
        public IActionResult GetCountry(Guid countryId)  
        {  
            var result = _countryService.GetCountry(countryId);  
            Console.WriteLine(result);
                return Ok(result);  
        }

        [HttpPost]
        public IActionResult InsertClient([FromBody]CountryDtoInsert country)  
        {  
            Country createdCountry = _countryService.InsertCountry(country);
            return CreatedAtAction(nameof(GetCountry), new { id = country }, country); 

        }
    }
}