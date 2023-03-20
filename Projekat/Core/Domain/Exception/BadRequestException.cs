using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekat.Core.Domain.Exception
{
    public  abstract class BadRequestException : IOException
    {
        protected BadRequestException(string message)
            : base(message)
        {
            
        }
        
    }
}