using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekat.Core.Domain.Exception
{
    public abstract class NotFoundException : IOException
    {
        protected NotFoundException(string message)
            : base(message)
        {

        }
        
    }
}