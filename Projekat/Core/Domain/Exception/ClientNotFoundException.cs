using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekat.Core.Domain.Exception
{
    public sealed class ClientNotFoundException : NotFoundException
    {
        
        public ClientNotFoundException(Guid clientId)
            : base ($"The employee with the identifier {clientId} was not found")
        {
        }
    }
}