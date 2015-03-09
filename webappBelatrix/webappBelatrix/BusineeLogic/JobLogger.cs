using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace webappBelatrix.Negocio
{
    public class JobLogger
    {
        private static bool _logToFile;
        private static bool _logToConsole;
        private static bool _logMessage;
        private static bool _logWarning;
        private static bool _logError;
        private static bool LogToDatabase;
        private bool _initialized;

        public JobLogger(bool logToFile , bool logToConsole, bool logToDatabase, 
            bool logMessage, bool logWarning, bool logError){
            _logError=logError;
            _logMessage=logMessage;
            _logWarning=logWarning;
            LogToDatabase=logToDatabase;
            _logToFile=logToFile;
            _logToConsole=logToConsole;
        }

        public static void LogMessage(string Message, bool message, bool warning, bool error){
            Message.Trim();
            if(Message==null || Message.Length==0){
                return;
            }
            if(!_logToConsole &&  !_logToFile && !LogToDatabase){
                throw new Exception("Invalid Configuration");
            }
            if((!_logError && !_logMessage && !_logWarning) || (!message && !warning && !error)){
                throw new Exception("Error or Warning or Message must be specified");
            }

            //-------------LOG TO DATABASE: BEGIN
            System.Data.SqlClient.SqlConnection con= new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
            con.Open();
            int t=0;
            if(message && _logMessage){
                t=1;
            }
            if(error && _logError){
                t=2;
            }
            if(warning && _logWarning){
                t=3;
            }

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("Insert into Log Values('" + Message + "," + t.ToString() + ")");
            cmd.ExecuteNonQuery();
            //-------------LOG TO DATABASE: END

            //-------------LOG TO FILE: BEGIN
            string l="";
            if(!System.IO.File.Exists(System.Configuration.ConfigurationManager.AppSettings["LogFileDirectory"]+
                "LogFile"+DateTime.Now.ToShortDateString()+".txt")){
                l=System.IO.File.ReadAllText(System.Configuration.ConfigurationManager.
                    AppSettings[" LogFileDirectory"]+"LogFile"+DateTime.Now.ToShortDateString()+".txt");
            }

            if(error && _logError)
            {
                l = l + DateTime.Now.ToShortDateString() + Message;
            }
            if(warning && _logWarning)
            {
                l = l + DateTime.Now.ToShortDateString() + Message; 
            }
            if(message && _logMessage)
            {
                l = l + DateTime.Now.ToShortDateString() + Message;
            }

            System.IO.File.WriteAllText(System.Configuration.ConfigurationManager.AppSettings["LogFileDirectory"]+
                "LogFile"+DateTime.Now.ToShortDateString()+".txt",l);
            //-------------LOG TO FILE: END

            //-------------LOG TO CONSOLE: BEGIN
            if(error && _logError)
            {
                Console.ForegroundColor=ConsoleColor.Red;
            }

            if(warning && _logWarning)
            {
                Console.ForegroundColor=ConsoleColor.Yellow;
            }

            if(message && _logMessage)
            {
                Console.ForegroundColor=ConsoleColor.White;
            }

            Console.WriteLine(DateTime.Now.ToShortDateString() + Message);
            //-------------LOG TO CONSOLE: END

        }
    }
}