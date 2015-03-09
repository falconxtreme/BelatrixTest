using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webappBelatrix.Entidad;

namespace webappBelatrix.Interfaces
{
    public interface IJobLoggerRestructured
    {
        string writeInConsole(beLog obeLog);
        string writeInFile(beLog obeLog);
        string writeInDatabase(beLog obeLog);
    }
}
