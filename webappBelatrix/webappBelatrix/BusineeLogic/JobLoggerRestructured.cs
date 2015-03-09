using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webappBelatrix.Datos;
using webappBelatrix.Entidad;
using webappBelatrix.Interfaces;

namespace webappBelatrix.Negocio
{
    public class JobLoggerRestructured:ILogMessage
    {
        private static beEnumLog.LogTypes _typeLog = beEnumLog.LogTypes.none;
        private static beEnumLog.MessagesTypes _messageType = beEnumLog.MessagesTypes.none;

        public JobLoggerRestructured(beEnumLog.LogTypes typeLog, beEnumLog.MessagesTypes messageType)
        {
            _typeLog = typeLog;
            _messageType = messageType;
        }

        public  void WriteLog(beLog obeLog)
        {
            if (obeLog.Message.Length == 0)
            {
                return;
            }
            if (_typeLog==beEnumLog.LogTypes.none)
            {
                throw new Exception("Invalid Configuration");
            }
            else if ((_messageType==beEnumLog.MessagesTypes.none) || (obeLog.messageType==beEnumLog.MessagesTypes.none))
            {
                throw new Exception("Error or Warning or Message must be specified");
            }
            obeLog.additionalType = _messageType;
            switch (_typeLog)
            {
                case beEnumLog.LogTypes.LogToFile:
                    daLogFile odaLogFile = new daLogFile();
                    odaLogFile.WriteLog(obeLog);
                    break;
                case beEnumLog.LogTypes.LogToConsole:
                    daLogConsole odaLogConsole = new daLogConsole();
                    odaLogConsole.WriteLog(obeLog);
                    break;
                case beEnumLog.LogTypes.LogToDatabase:
                    daLogDatabase odaLogDatabase = new daLogDatabase();
                    odaLogDatabase.WriteLog(obeLog);
                    break;
            }
        }
    }
}