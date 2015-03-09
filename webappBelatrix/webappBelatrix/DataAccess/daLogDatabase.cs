using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webappBelatrix.Entidad;
using webappBelatrix.Interfaces;
using System.Data.SqlClient;
using System.Data;

namespace webappBelatrix.Datos
{
    public class daLogDatabase : ILogMessage
    {
        public  void WriteLog(beLog obeLog)
        {
            int t = 0;
            if (obeLog.messageType == beEnumLog.MessagesTypes.Messsage && obeLog.additionalType == beEnumLog.MessagesTypes.Messsage)
            {
                t = 1;
            }
            else if (obeLog.messageType == beEnumLog.MessagesTypes.Error && obeLog.additionalType == beEnumLog.MessagesTypes.Error)
            {
                t = 2;
            }
            else if (obeLog.messageType == beEnumLog.MessagesTypes.Warning && obeLog.additionalType == beEnumLog.MessagesTypes.Warning)
            {
                t = 3;
            }
            else
            {
                return;
            }
            using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"])){
                con.Open();
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {
                    cmd.CommandText = "Insert into Log Values( ?, ?)";
                    cmd.CommandType = CommandType.Text;

                    SqlParameter parSql = new SqlParameter();
                    parSql.ParameterName = "@message";
                    parSql.SqlDbType = SqlDbType.VarChar;
                    parSql.Direction = ParameterDirection.Input;
                    parSql.Value = obeLog.Message;
                    cmd.Parameters.Add(parSql);

                    parSql = new SqlParameter();
                    parSql.ParameterName = "@type";
                    parSql.SqlDbType = SqlDbType.VarChar;
                    parSql.Direction = ParameterDirection.Input;
                    parSql.Value = t.ToString();
                    cmd.Parameters.Add(parSql);

                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                };
                
            };
        }
    }
}