using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webappBelatrix.Entidad;
using webappBelatrix.Interfaces;

namespace webappBelatrix.Negocio
{
    public class JobLoggerService
    {
        private IJobLoggerRestructured oJobLogger;
        private beEnumLog.LogTypes _typeLog = beEnumLog.LogTypes.none;
        private beEnumLog.MessagesTypes _messageType = beEnumLog.MessagesTypes.none;

        public JobLoggerService(IJobLoggerRestructured jobLogger, beEnumLog.LogTypes typeLog, beEnumLog.MessagesTypes messageType)
        {
            oJobLogger = jobLogger;
            _typeLog = typeLog;
            _messageType = messageType;
        }

        public string writeLog(beLog obeLog)
        {
            string success = "failed";
            if (obeLog.Message.Length == 0)
            {
                return "Empty message";
            }
            if (_typeLog == beEnumLog.LogTypes.none)
            {
                return ("Invalid Configuration");
            }
            else if ((_messageType == beEnumLog.MessagesTypes.none) || (obeLog.messageType == beEnumLog.MessagesTypes.none))
            {
                return ("Error or Warning or Message must be specified");
            }
            obeLog.additionalType = _messageType;
            switch (_typeLog)
            {
                case beEnumLog.LogTypes.LogToFile:
                    success=oJobLogger.writeInFile(obeLog);
                    break;
                case beEnumLog.LogTypes.LogToConsole:
                    success = oJobLogger.writeInConsole(obeLog);
                    break;
                case beEnumLog.LogTypes.LogToDatabase:
                    success = oJobLogger.writeInDatabase(obeLog);
                    break;
            }
            return success;
        }
    }
}