using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webappBelatrix.Entidad;
using webappBelatrix.Interfaces;

namespace webappBelatrix.Datos
{
    public class daLogConsole : ILogMessage
    {
        public void WriteLog(beLog obeLog)
        {
            if (obeLog.messageType == beEnumLog.MessagesTypes.Error && obeLog.additionalType == beEnumLog.MessagesTypes.Error)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (obeLog.messageType == beEnumLog.MessagesTypes.Warning && obeLog.additionalType == beEnumLog.MessagesTypes.Warning)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else if (obeLog.messageType == beEnumLog.MessagesTypes.Messsage && obeLog.additionalType == beEnumLog.MessagesTypes.Messsage)
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                return;
            }
            Console.WriteLine(DateTime.Now.ToShortDateString() + obeLog.Message);
        }
    }
}