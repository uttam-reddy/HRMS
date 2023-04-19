using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Services.Interfaces.Logging
{
    public interface ILog
    {
        void LogError(string message);
    }
}
