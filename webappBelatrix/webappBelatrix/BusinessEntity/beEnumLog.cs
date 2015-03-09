using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webappBelatrix.Entidad
{
    public class beEnumLog
    {
        public  enum MessagesTypes : byte { none=1, Error, Messsage, Warning};
        public  enum LogTypes : byte { none=1, LogToFile, LogToConsole, LogToDatabase};
    }
}