using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webappBelatrix.Entidad;
using webappBelatrix.Interfaces;
using System.IO;

namespace webappBelatrix.Datos
{
    public class daLogFile : ILogMessage
    {
        public void WriteLog(beLog obeLog)
        {
            if (obeLog.messageType != beEnumLog.MessagesTypes.none && obeLog.additionalType!=beEnumLog.MessagesTypes.none)
            {
                string logActual = "";
                Object thisLock = new Object();
                string rutaLog = System.Configuration.ConfigurationManager.AppSettings["LogFileDirectory"] +
                        "LogFile" + DateTime.Now.ToShortDateString() + ".txt";
                logActual = DateTime.Now.ToShortDateString() + obeLog.Message;
                lock (thisLock)
                {
                    if (!System.IO.File.Exists(rutaLog))
                    {
                        File.WriteAllText(rutaLog, logActual);
                    }
                    else {
                        File.AppendAllText(rutaLog, logActual);
                    }
                }
            }
        }
    }
}