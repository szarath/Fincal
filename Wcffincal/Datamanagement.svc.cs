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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "_" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select .svc or .svc.cs at the Solution Explorer and start debugging.
    public class Datamanagement : IDatamanagement
    {
        int IDatamanagement.insertevent(DateTime eDate, string summary, string location, string googleid, string uid, string desc)
        {
            string sqlStatement = "INSERT INTO tblEvent (eDate, eSummary, eLocation, eGoogleID, uID, eDesc) VALUES(@0,@1,@2,@3,@4,@5);";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", eDate);
            command.Parameters.AddWithValue("@1", summary);
            command.Parameters.AddWithValue("@2", location);
            command.Parameters.AddWithValue("@3", googleid);
            command.Parameters.AddWithValue("@4", uid);
            command.Parameters.AddWithValue("@5", desc);


            return clsSQL.ExecuteNonQuery(command);
        }

        int IDatamanagement.deleteevent(string GoogleID)
        {
            string sqlStatement = "DELETE FROM tblEvent WHERE eGoogleID=@0";

            SqlCommand command = new SqlCommand(sqlStatement);


            command.Parameters.AddWithValue("@0", GoogleID);

            return clsSQL.ExecuteNonQuery(command);

        }











        string IDatamanagement.checkevents(string ID)
        {
            string sqlStatement = "SELECT eGoogleID FROM tblEvent WHERE eGoogleID=@0";



            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", ID);

            DataSet sqlDataSet = clsSQL.ExecuteQuery(command);


            if (!(sqlDataSet.Tables.Count == 0))
            {
                if (!(sqlDataSet.Tables[0].Rows.Count == 0))
                {
                    return sqlDataSet.Tables[0].Rows[0][0].ToString();
                }
            }
            return null;
        }



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

        object[] IDatamanagement.geteventpics(string id)
        {
            DataSet ds = clsSQL.ExecuteQuery(new SqlCommand("SELECT * FROM tblEvent WHERE eID=@0"));

            string[] result = null;

            if (!(ds.Tables.Count == 0) && !(ds.Tables[0].Rows.Count == 0))
            {
                string[] temp = new string[ds.Tables[0].Rows.Count];
                for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                {
                    temp[k] = ds.Tables[0].Rows[k][0].ToString();
                }
                result = temp;
            }


            return result;
        }

        string IDatamanagement.geteventfirstpics(string id)
        {
            string sqlStatement = "SELECT TOP 1 ePic FROM tblEventpic WHERE eGoogleID=@0";



            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", id);

            DataSet sqlDataSet = clsSQL.ExecuteQuery(command);
            //DataSet sqlDataSet = clsSQL.ExecuteQuery("SELECT uUsername FROM tblUser WHERE uID=" + userID);

            if (!(sqlDataSet.Tables.Count == 0))
            {
                if (!(sqlDataSet.Tables[0].Rows.Count == 0))
                {
                    return sqlDataSet.Tables[0].Rows[0][0].ToString();
                }
            }
            return null;
        }

        object[] IDatamanagement.getevent(string googleid)
        {
            string sqlStatement = "SELECT * FROM tblEvent WHERE eGoogleID=@0";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", googleid);

            DataSet sqlDataSet = clsSQL.ExecuteQuery(command);


            string[] temp = null;
            if (!(sqlDataSet.Tables.Count == 0))
            {
                if (!(sqlDataSet.Tables[0].Rows.Count == 0))
                {
                    temp = new string[sqlDataSet.Tables[0].Columns.Count];
                    for (int k = 0; k < sqlDataSet.Tables[0].Columns.Count; k++)
                    {
                        temp[k] = sqlDataSet.Tables[0].Rows[0][k].ToString();
                    }
                }
            }

            return temp;
        }

        int IDatamanagement.inserteventpic(string eid, string epic, string egoogleid, string uid)
        {
            string sqlStatement = "INSERT INTO tblEventpic (ePIC, eGoogleID, eID,uID) VALUES(@0,@1,@2,@3);";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", eid);
            command.Parameters.AddWithValue("@1", epic);
            command.Parameters.AddWithValue("@2", egoogleid);
            command.Parameters.AddWithValue("@3", uid);


            return clsSQL.ExecuteNonQuery(command);
        }

        int IDatamanagement.deleteeventpics(string GoogleID)
        {
            string sqlStatement = "DELETE FROM tblEventpic WHERE eGoogleID=@01";

            SqlCommand command = new SqlCommand(sqlStatement);


            command.Parameters.AddWithValue("@0", GoogleID);

            return clsSQL.ExecuteNonQuery(command);
        }

        int IDatamanagement.updateevent(DateTime edate, string summary, string location, string desc, string eid)
        {
            string sqlStatement = "UPDATE tblEvent SET eDate=@0, eSummary=@1, eLocation=@2, eDesc=@3 WHERE eID=@4;";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", edate);
            command.Parameters.AddWithValue("@1", summary);
            command.Parameters.AddWithValue("@2", location);
            command.Parameters.AddWithValue("@3", desc);
            command.Parameters.AddWithValue("@4", eid);
            return clsSQL.ExecuteNonQuery(command);
        }









        object[] IDatamanagement.gettaskcat()
        {

            DataSet ds = clsSQL.ExecuteQuery(new SqlCommand("SELECT tcName FROM tblTaskCategory"));

            string[] result = null;

            if (!(ds.Tables.Count == 0) && !(ds.Tables[0].Rows.Count == 0))
            {
                string[] temp = new string[ds.Tables[0].Rows.Count];
                for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                {
                    temp[k] = ds.Tables[0].Rows[k][0].ToString();
                }
                result = temp;
            }


            return result;
        }

        object[] IDatamanagement.gettask(string GoogleID)
        {

            string sqlStatement = "SELECT * FROM tblTask WHERE eGoogleID=@0";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", GoogleID);

            DataSet sqlDataSet = clsSQL.ExecuteQuery(command);


            string[] temp = null;
            if (!(sqlDataSet.Tables.Count == 0))
            {
                if (!(sqlDataSet.Tables[0].Rows.Count == 0))
                {
                    temp = new string[sqlDataSet.Tables[0].Columns.Count];
                    for (int k = 0; k < sqlDataSet.Tables[0].Columns.Count; k++)
                    {
                        temp[k] = sqlDataSet.Tables[0].Rows[0][k].ToString();
                    }
                }
            }

            return temp;


        }

        int IDatamanagement.updatetask(string name, int complete, string uid, string tcid, string tid)
        {
            string sqlStatement = "UPDATE tblTask SET tName=@0, tComplete=@1, uID=@2, tcID=@3 WHERE tID=@4;";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", name);
            command.Parameters.AddWithValue("@1", complete);
            command.Parameters.AddWithValue("@2", uid);
            command.Parameters.AddWithValue("@3", tcid);
            command.Parameters.AddWithValue("@4", tid);
            return clsSQL.ExecuteNonQuery(command);
        }



        string IDatamanagement.checktasks(string ID)
        {
            string sqlStatement = "SELECT tGoogleID FROM tblTask WHERE tGoogleID=@0";



            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", ID);

            DataSet sqlDataSet = clsSQL.ExecuteQuery(command);


            if (!(sqlDataSet.Tables.Count == 0))
            {
                if (!(sqlDataSet.Tables[0].Rows.Count == 0))
                {
                    return sqlDataSet.Tables[0].Rows[0][0].ToString();
                }
            }
            return null;
        }



        int IDatamanagement.inserttask(string name, int complete, string category, string googleid, string uid)
        {
            string sqlStatement = "INSERT INTO tbltask (tName, tComplete, uID, tcID, tGoogleID) VALUES(@0,@1,@2,@3,@4);";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", name);
            command.Parameters.AddWithValue("@1", complete);
            command.Parameters.AddWithValue("@2", category);
            command.Parameters.AddWithValue("@3", googleid);
            command.Parameters.AddWithValue("@4", uid);



            return clsSQL.ExecuteNonQuery(command);
        }
        int IDatamanagement.deletetask(string GoogleID)
        {
            string sqlStatement = "DELETE FROM tblTask WHERE tGoogleID=@0";

            SqlCommand command = new SqlCommand(sqlStatement);


            command.Parameters.AddWithValue("@0", GoogleID);

            return clsSQL.ExecuteNonQuery(command);

        }










        int IDatamanagement.insertsechedule(DateTime starttime, DateTime endtime, string category)
        {
            throw new NotImplementedException();
        }

        int IDatamanagement.deleteschedule(string id)
        {
            throw new NotImplementedException();
        }

        int IDatamanagement.updateschedule(DateTime starttime, DateTime endtime, string category, string id)
        {
            throw new NotImplementedException();
        }







        object[] IDatamanagement.gettaskids(string uid)
        {
            string sqlStatement = "SELECT tGoogleID FROM tblTask WHERE uID=@0";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", uid);

            DataSet sqlDataSet = clsSQL.ExecuteQuery(command);


            string[] temp = null;
            if (!(sqlDataSet.Tables.Count == 0))
            {
                if (!(sqlDataSet.Tables[0].Rows.Count == 0))
                {
                    temp = new string[sqlDataSet.Tables[0].Columns.Count];
                    for (int k = 0; k < sqlDataSet.Tables[0].Columns.Count; k++)
                    {
                        temp[k] = sqlDataSet.Tables[0].Rows[0][k].ToString();
                    }
                }
            }

            return temp;


        }




        object[] IDatamanagement.geteventids(string uid)
        {
            string sqlStatement = "SELECT eGoogleID FROM tblEvent WHERE uID=@0";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", uid);

            DataSet sqlDataSet = clsSQL.ExecuteQuery(command);


            string[] temp = null;
            if (!(sqlDataSet.Tables.Count == 0))
            {
                if (!(sqlDataSet.Tables[0].Rows.Count == 0))
                {
                    temp = new string[sqlDataSet.Tables[0].Columns.Count];
                    for (int k = 0; k < sqlDataSet.Tables[0].Columns.Count; k++)
                    {
                        temp[k] = sqlDataSet.Tables[0].Rows[0][k].ToString();
                    }
                }
            }

            return temp;


        }






        //picture operations 
        int IDatamanagement.insertpicture(string picture, string description, string uid)
        {
            string sqlStatement = "INSERT INTO tblPic (Pic, pDesc, uID) VALUES(@0,@1,@2);";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", picture);
            command.Parameters.AddWithValue("@1", description);
            command.Parameters.AddWithValue("@2", uid);




            return clsSQL.ExecuteNonQuery(command);
        }

        int IDatamanagement.deletepicture(string id)
        {
            string sqlStatement = "DELETE FROM tblPic WHERE pID=@0";

            SqlCommand command = new SqlCommand(sqlStatement);


            command.Parameters.AddWithValue("@0", id);

            return clsSQL.ExecuteNonQuery(command);
        }

        int IDatamanagement.deleteallpictures(string uid)
        {
            throw new NotImplementedException();
        }

        object[][] IDatamanagement.getalluserpictures(string uid)
        {
            string sqlStatement = "SELECT * FROM tblPic WHERE uID=@0";



            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", uid);

            DataSet ds = clsSQL.ExecuteQuery(command);
            //DataSet ds = clsSQL.ExecuteQuery("SELECT uID, uUsername, uEmail, uRegDate, uReportCount, uFlagged FROM tblUser");

            return create2DAdsArray(ds);


        }

        object[] IDatamanagement.getpic(string id)
        {
            string sqlStatement = "SELECT * FROM tblPic WHERE pID=@0";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", id);

            DataSet sqlDataSet = clsSQL.ExecuteQuery(command);


            string[] temp = null;
            if (!(sqlDataSet.Tables.Count == 0))
            {
                if (!(sqlDataSet.Tables[0].Rows.Count == 0))
                {
                    temp = new string[sqlDataSet.Tables[0].Columns.Count];
                    for (int k = 0; k < sqlDataSet.Tables[0].Columns.Count; k++)
                    {
                        temp[k] = sqlDataSet.Tables[0].Rows[0][k].ToString();
                    }
                }
            }

            return temp;
        }

        int IDatamanagement.updatepic(string id, string description)
        {
            string sqlStatement = "UPDATE tblPic SET pDesc=@0 WHERE pID=@1;";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", description);
            command.Parameters.AddWithValue("@1", id);

            return clsSQL.ExecuteNonQuery(command);
        }
    }
}
