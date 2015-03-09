using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webappBelatrix.Entidad
{
    public class beLog
    {
        private string _Message;
        public string Message {
            get { return _Message; }
            set {
                if (value != null)
                    _Message = value.Trim();
                else
                    _Message = "";
            }
        }
        public beEnumLog.MessagesTypes messageType;
        //public string additionalMessage;
        public beEnumLog.MessagesTypes additionalType;

        public beLog(string MessageIn, beEnumLog.MessagesTypes messageTypeIn, beEnumLog.MessagesTypes additionalTypeIn)
        {
            _Message = MessageIn;
            messageType = messageTypeIn;
            additionalType = additionalTypeIn;
        }
    }
}