using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DILifeTimeTest.Services
{
    public interface IScopedService
    {
        Guid GetID();
    }
}
