using HRMS.Services.Interfaces.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Models
{
    public sealed class Logger : ILog
    {
        public Logger()
        {

        }

        private static readonly Lazy<Logger> instance = new Lazy<Logger>();

        public static Logger GetInstance()
        {
            return instance.Value;
        }
        public void LogError(string message)
        {
            //logic for logging
        }
    }
}
