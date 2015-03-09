using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webappBelatrix.Entidad;

namespace webappBelatrix.Interfaces
{
    interface ILogMessage
    {
        void WriteLog(beLog obeLog);
    }
}
