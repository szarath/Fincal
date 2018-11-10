using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Wcffincal.Classes;

namespace Wcffincal
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Chat" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Chat.svc or Chat.svc.cs at the Solution Explorer and start debugging.
    public class Chat : IChat
    {

        protected Object[][] create2DAdsArray(DataSet sqlDataSet)
        {
            string[][] result = null;

            if (!(sqlDataSet.Tables.Count == 0) && !(sqlDataSet.Tables[0].Rows.Count == 0))
            {
                string[][] temp = new string[sqlDataSet.Tables[0].Rows.Count][];
                for (int k = 0; k < sqlDataSet.Tables[0].Rows.Count; k++)
                {
                    temp[k] = new string[sqlDataSet.Tables[0].Columns.Count];
                    for (int j = 0; j < sqlDataSet.Tables[0].Columns.Count; j++)
                    {
                        temp[k][j] = sqlDataSet.Tables[0].Rows[k][j].ToString();
                    }
                    result = temp;
                }
            }

            return result;
        }

        int IChat.deleteisschatuser(string uid)
        {
            string sqlStatement = "DELETE FROM tblisschat WHERE uID=@0;";

            SqlCommand command = new SqlCommand(sqlStatement);


            command.Parameters.AddWithValue("@0", uid);



            return clsSQL.ExecuteNonQuery(command);
        }

        int IChat.deleteissuechat(string issueid)
        {
            string sqlStatement = "DELETE FROM tblisschat WHERE isID=@0;";

            SqlCommand command = new SqlCommand(sqlStatement);


            command.Parameters.AddWithValue("@0", issueid);



            return clsSQL.ExecuteNonQuery(command);
        }

        int IChat.deleteprojchat(string projid)
        {
            string sqlStatement = "DELETE FROM tblprojchat WHERE pID=@0;";

            SqlCommand command = new SqlCommand(sqlStatement);


            command.Parameters.AddWithValue("@0", projid);



            return clsSQL.ExecuteNonQuery(command);
        }

        int IChat.deleteprojchatuser(string uid)
        {
           
            string sqlStatement = "DELETE FROM tblprojchat WHERE uID=@0;";
            SqlCommand command = new SqlCommand(sqlStatement);


            command.Parameters.AddWithValue("@0", uid);



            return clsSQL.ExecuteNonQuery(command);
        }

        int IChat.deletespecificissuemessage(string icID)
        {
            string sqlStatement = "DELETE FROM tblisschat WHERE icID=@0;";

            SqlCommand command = new SqlCommand(sqlStatement);


            command.Parameters.AddWithValue("@0", icID);



            return clsSQL.ExecuteNonQuery(command);
        }

        int IChat.deletespecificprojmessage(string pcID)
        {
            string sqlStatement = "DELETE FROM tblprojchat WHERE pcID=@0;";

            SqlCommand command = new SqlCommand(sqlStatement);


            command.Parameters.AddWithValue("@0", pcID);

            return clsSQL.ExecuteNonQuery(command);
        }

        Object[][] IChat.getissuechat(string issueid)
        {
          

            string sqlStatement = "SELECT tblisschat.uID, tblUser.uUsername, tblisschat.icMessage, tblisschat.isID FROM tblisschat INNER JOIN tblUser ON tblisschat.uID = tblUser.uID WHERE tblisschat.isID=@0;";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", issueid);

            DataSet ds = clsSQL.ExecuteQuery(command);

            return create2DAdsArray(ds);
        }

        Object[][] IChat.getprojchat(string projid)
        {
            string sqlStatement = "SELECT tblprojchat.uID, tblUser.uUsername, tblprojchat.pcMessage, tblprojchat.pcID FROM tblprojchat INNER JOIN tblUser ON tblprojchat.uID = tblUser.uID WHERE tblprojchat.pID=@0;";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", projid);

            DataSet ds = clsSQL.ExecuteQuery(command);

            return create2DAdsArray(ds);

        }

        int IChat.insertissuechat(string message, string issueid, string uid)
        {
            string sqlStatement = "INSERT INTO tblisschat (icMessage, isID, uID) VALUES (@0,@1,@2);";
            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", message);
            command.Parameters.AddWithValue("@1", issueid);
            command.Parameters.AddWithValue("@2", uid);
            return clsSQL.ExecuteNonQuery(command);
        }

        int IChat.insertprojchat(string message, string projid, string uid)
        {
            string sqlStatement = "INSERT INTO tblprojchat (pcMessage, pID, uID) VALUES (@0,@1,@2);";
            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", message);
            command.Parameters.AddWithValue("@1", projid);
            command.Parameters.AddWithValue("@2", uid);

            return clsSQL.ExecuteNonQuery(command);
        }



    }
}
