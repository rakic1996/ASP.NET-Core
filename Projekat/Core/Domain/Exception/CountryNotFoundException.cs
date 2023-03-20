using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekat.Core.Domain.Exception
{
    public sealed class CountryNotFoundException : NotFoundException
    {
        public CountryNotFoundException(Guid countryId)
            : base ($"The employee with the identifier {countryId} was not found")
        {
        }
        
    }
}