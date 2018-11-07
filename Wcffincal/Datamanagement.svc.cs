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
            string sqlStatement = "INSERT INTO tblEvent (eDate, eSummary, eLocation, eGoogleID, uID, eDesc) VALUES (@0,@1,@2,@3,@4,@5);";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", eDate);
            command.Parameters.AddWithValue("@1", summary);
            command.Parameters.AddWithValue("@2", location);
            command.Parameters.AddWithValue("@3", googleid);
            command.Parameters.AddWithValue("@4", uid);
            command.Parameters.AddWithValue("@5", desc);


            return clsSQL.ExecuteNonQuery(command);
        }

        int IDatamanagement.deleteevent(string GoogleID,string uid)
        {
            string sqlStatement = "DELETE FROM tblEvent WHERE eGoogleID=@0 AND uID=@1;";

            SqlCommand command = new SqlCommand(sqlStatement);


            command.Parameters.AddWithValue("@0", GoogleID);
            command.Parameters.AddWithValue("@1", uid);
            return clsSQL.ExecuteNonQuery(command);

        }











        string IDatamanagement.checkevents(string ID,string uid)
        {
            string sqlStatement = "SELECT eGoogleID FROM tblEvent WHERE eGoogleID=@0 AND uID=@1;";



            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", ID);
            command.Parameters.AddWithValue("@1", uid);
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

        object[] IDatamanagement.geteventpics(string id, string uid)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM tblEvent WHERE eID=@0 AND uID=@1;");

            command.Parameters.AddWithValue("@0", id);
            command.Parameters.AddWithValue("@1", uid);
            DataSet ds = clsSQL.ExecuteQuery(command);

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

        string IDatamanagement.geteventfirstpics(string id, string uid)
        {
            string sqlStatement = "SELECT TOP 1 ePic FROM tblEventpic WHERE eGoogleID=@0 and uID=@1;";



            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", id);

            command.Parameters.AddWithValue("@1", uid);
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

        object[] IDatamanagement.getevent(string googleid, string uid)
        {
            string sqlStatement = "SELECT * FROM tblEvent WHERE eGoogleID=@0 AND uID=@1;";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", googleid);
         
            command.Parameters.AddWithValue("@1", uid);
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
            string sqlStatement = "INSERT INTO tblEventpic (ePIC, eGoogleID, eID,uID) VALUES (@0,@1,@2,@3);";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", eid);
            command.Parameters.AddWithValue("@1", epic);
            command.Parameters.AddWithValue("@2", egoogleid);
            command.Parameters.AddWithValue("@3", uid);


            return clsSQL.ExecuteNonQuery(command);
        }

        int IDatamanagement.deleteeventpics(string GoogleID,string uid)
        {
            string sqlStatement = "DELETE FROM tblEventpic WHERE eGoogleID=@0 AND uID=@1;";

            SqlCommand command = new SqlCommand(sqlStatement);


            command.Parameters.AddWithValue("@0", GoogleID);
            command.Parameters.AddWithValue("@1", uid);
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

            DataSet ds = clsSQL.ExecuteQuery(new SqlCommand("SELECT tcName FROM tblTaskCategory;"));

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

        object[] IDatamanagement.gettask(string GoogleID, string uid)
        {

            string sqlStatement = "SELECT * FROM tblTask WHERE tGoogleID=@0 AND uID=@1;";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", GoogleID);
            command.Parameters.AddWithValue("@1", uid);
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

        int IDatamanagement.updatetask(string name, string complete, string uid, string tcid, string tid)
        {
            string sqlStatement = "UPDATE tblTask SET tName=@0, tComplete=@1, uID=@2, tcID=@3 WHERE tGoogleID=@4;";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", name);
            command.Parameters.AddWithValue("@1", complete);
            command.Parameters.AddWithValue("@2", uid);
            command.Parameters.AddWithValue("@3", tcid);
            command.Parameters.AddWithValue("@4", tid);
            return clsSQL.ExecuteNonQuery(command);
        }



        string IDatamanagement.checktasks(string ID,string uid)
        {
            string sqlStatement = "SELECT tGoogleID FROM tblTask WHERE tGoogleID=@0 AND uID=@1;";



            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", ID);

            command.Parameters.AddWithValue("@1", uid);
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



        int IDatamanagement.inserttask(string name, string complete, string category, string googleid, string uid)
        {
            string sqlStatement = "INSERT INTO tblTask (tName, tComplete, uID, tcID, tGoogleID) VALUES (@0,@1,@2,@3,@4);";
         
            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", name);
            command.Parameters.AddWithValue("@1", complete);
            command.Parameters.AddWithValue("@2", uid);
            command.Parameters.AddWithValue("@3", category);
            command.Parameters.AddWithValue("@4", googleid);
          



            return clsSQL.ExecuteNonQuery(command);
        }


        int IDatamanagement.deletetask(string GoogleID, string uid)
        {
            string sqlStatement = "DELETE FROM tblTask WHERE tGoogleID=@0 AND uID=@1;";

            SqlCommand command = new SqlCommand(sqlStatement);


            command.Parameters.AddWithValue("@0", GoogleID);

            command.Parameters.AddWithValue("@1", uid);
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
            string sqlStatement = "SELECT tGoogleID FROM tblTask WHERE uID=@0;";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", uid);

            DataSet ds = clsSQL.ExecuteQuery(command);


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




        object[] IDatamanagement.geteventids(string uid)
        {
            string sqlStatement = "SELECT eGoogleID FROM tblEvent WHERE uID=@0;";

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
        int IDatamanagement.insertpicture(string picture, string title, string description, string uid)
        {
            string sqlStatement = "INSERT INTO tblPic (Pic, Pictitle , pDesc, uID) VALUES(@0,@1,@2,@3);";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", picture);

            command.Parameters.AddWithValue("@1", title);
            command.Parameters.AddWithValue("@2", description);
            command.Parameters.AddWithValue("@3", uid);
       




            return clsSQL.ExecuteNonQuery(command);
        }

        int IDatamanagement.deletepicture(string id, string uid)
        {
            string sqlStatement = "DELETE FROM tblPic WHERE pID=@0 AND uID=@1;";

            SqlCommand command = new SqlCommand(sqlStatement);


            command.Parameters.AddWithValue("@0", id);
            command.Parameters.AddWithValue("@1", uid);
            return clsSQL.ExecuteNonQuery(command);
        }

        int IDatamanagement.deleteallpictures(string uid)
        {
            string sqlStatement = "DELETE FROM tblPic WHERE  uID=@0;";

            SqlCommand command = new SqlCommand(sqlStatement);


            command.Parameters.AddWithValue("@0", uid);
            
            return clsSQL.ExecuteNonQuery(command);


           
        }

        object[][] IDatamanagement.getalluserpictures(string uid)
        {
            string sqlStatement = "SELECT * FROM tblPic WHERE uID=@0;";



            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", uid);

            DataSet ds = clsSQL.ExecuteQuery(command);
            //DataSet ds = clsSQL.ExecuteQuery("SELECT uID, uUsername, uEmail, uRegDate, uReportCount, uFlagged FROM tblUser");

            return create2DAdsArray(ds);


        }

        object[][] IDatamanagement.getfewpics(string uid)
        {
            string sqlStatement = "SELECT TOP 10 * FROM tblPic WHERE uID=@0;";



            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", uid);

            DataSet ds = clsSQL.ExecuteQuery(command);
            //DataSet ds = clsSQL.ExecuteQuery("SELECT uID, uUsername, uEmail, uRegDate, uReportCount, uFlagged FROM tblUser");

            return create2DAdsArray(ds);
        }

        object[] IDatamanagement.getpic(string id, string uid)
        {
            string sqlStatement = "SELECT * FROM tblPic WHERE pID=@0 AND uID=@1;";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", id);
            command.Parameters.AddWithValue("@1", uid);
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

        int IDatamanagement.updatepic(string id, string title, string description, string uid)
        {
            string sqlStatement = "UPDATE tblPic SET pDesc=@0, Pictitle=@1 WHERE pID=@2 AND uID=@3;";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", description);
            command.Parameters.AddWithValue("@1", title);
            command.Parameters.AddWithValue("@2", id);
            command.Parameters.AddWithValue("@3", uid);
            return clsSQL.ExecuteNonQuery(command);
        }

        object[] IDatamanagement.getskills()
        {

            DataSet ds = clsSQL.ExecuteQuery(new SqlCommand("SELECT sName FROM tblSkills;"));

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

       

        object[] IDatamanagement.getassignedprojects(string uid)
        {
         //   DataSet ds = clsSQL.ExecuteQuery(new SqlCommand("SELECT * FROM tblProject LEFT JOIN projID ON tblProject.ProjID = tblTeams.ProjID WHERE tblProject.uID = @1;"));

            string sqlStatement = "SELECT projID FROM tblTeams WHERE uID=@0;";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", uid);

            DataSet ds = clsSQL.ExecuteQuery(command);


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

        object[][] IDatamanagement.getprojects(string uid)
        {

            string sqlStatement = "SELECT * FROM tblProject WHERE uID=@0;";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", uid);

            DataSet ds = clsSQL.ExecuteQuery(command);
            //DataSet ds = clsSQL.ExecuteQuery("SELECT uID, uUsername, uEmail, uRegDate, uReportCount, uFlagged FROM tblUser");

            return create2DAdsArray(ds);

        }

        object[] IDatamanagement.getissuemembers(string issid)
        {

            string sqlStatement = "SELECT uID FROM tblIssuesteam WHERE isID=@0;";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", issid);

            DataSet ds = clsSQL.ExecuteQuery(command);


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



        object[] IDatamanagement.getprojectdetails(string projid)
        {
            string sqlStatement = "SELECT * FROM tblProject WHERE projID=@0;";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", projid);


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

        object[] IDatamanagement.getissuedetails(string issueid)
        {
            string sqlStatement = "SELECT * FROM tblIssues WHERE isID=@0;";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", issueid);

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
        object[][] IDatamanagement.getissues(string uid)
        {

            string sqlStatement = "SELECT * FROM tblIssues WHERE uID=@0;";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", uid);

            DataSet ds = clsSQL.ExecuteQuery(command);
            //DataSet ds = clsSQL.ExecuteQuery("SELECT uID, uUsername, uEmail, uRegDate, uReportCount, uFlagged FROM tblUser");

            return create2DAdsArray(ds);

        }
        int IDatamanagement.createproject(string title, string description, string uid , DateTime pcredate)
        {


            string sqlStatement = "INSERT INTO tblProject (projTitle, projDescription, uID, pcredate) VALUES (@0,@1,@2,@3);  SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", title);
            command.Parameters.AddWithValue("@1", description);
            command.Parameters.AddWithValue("@2", uid);
            command.Parameters.AddWithValue("@3", pcredate);



            return clsSQL.ExecuteScalar(command);
        }

        int IDatamanagement.deleteproject(string projid)
        {


            string sqlStatement = "DELETE FROM tblProject WHERE projID=@0 ;";

            SqlCommand command = new SqlCommand(sqlStatement);


            command.Parameters.AddWithValue("@0", projid);

            

            return clsSQL.ExecuteNonQuery(command);
        }

        object[] IDatamanagement.getassignedissues(string uid)
        {




            string sqlStatement = "SELECT isID FROM tblIssuesteam WHERE uID=@0;";

            SqlCommand command = new SqlCommand(sqlStatement);

           

            command.Parameters.AddWithValue("@0", uid);

            DataSet ds = clsSQL.ExecuteQuery(command);


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



        object[][] IDatamanagement.getprojissues(string projid)
        {


            string sqlStatement = "SELECT * FROM tblIssues WHERE projID=@0;";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", projid);

            DataSet ds = clsSQL.ExecuteQuery(command);

            return create2DAdsArray(ds);

        }

        int IDatamanagement.createissue(string title, string description, string projid, string category, string uid, DateTime iscredate)
        {

            string sqlStatement = "INSERT INTO tblIssues (isnTitle, isnDesc , projID, isnCat, uID, iscredate) VALUES (@0,@1,@2,@3,@4,@5);  SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", title);
            command.Parameters.AddWithValue("@1", description);
            command.Parameters.AddWithValue("@2", projid);
            command.Parameters.AddWithValue("@3", category);
            command.Parameters.AddWithValue("@4", uid);
            command.Parameters.AddWithValue("@5", iscredate);
            return clsSQL.ExecuteScalar(command);
           
        }

        int IDatamanagement.updateissue(string isid, string status, string assid)
        {

            string sqlStatement = "UPDATE tblIssues SET pnStatus=@0, Assid=@1 WHERE isID=@2;";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", status);
            command.Parameters.AddWithValue("@1", assid);
            command.Parameters.AddWithValue("@2", isid);
          
            return clsSQL.ExecuteNonQuery(command);

        }

        int IDatamanagement.deleteissue(string issueid)
        {


            string sqlStatement = "DELETE FROM tblIssues WHERE isID=@0;";

            SqlCommand command = new SqlCommand(sqlStatement);


            command.Parameters.AddWithValue("@0", issueid);



            return clsSQL.ExecuteNonQuery(command);
        }


        object[] IDatamanagement.getprojnotification(string projectnotificationuserid)
        {

            string sqlStatement = "SELECT projID FROM tblProjnotice WHERE uID=@0;";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", projectnotificationuserid);

            DataSet ds = clsSQL.ExecuteQuery(command);


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

      

       

        int IDatamanagement.deleteporjnotificaiton(string projid, string uid)
        {
            string sqlStatement = "DELETE FROM tblProjnotice WHERE projID=@0 AND uID=@1;";

            SqlCommand command = new SqlCommand(sqlStatement);


            command.Parameters.AddWithValue("@0", projid);
            command.Parameters.AddWithValue("@1", uid);


            return clsSQL.ExecuteNonQuery(command);
        }


        int IDatamanagement.deleteallprojnotificaion(string projid)
        {
            string sqlStatement = "DELETE FROM tblProjnotice WHERE projID=@0;";

            SqlCommand command = new SqlCommand(sqlStatement);


            command.Parameters.AddWithValue("@0", projid);
          

            return clsSQL.ExecuteNonQuery(command);

        }



        object[] IDatamanagement.getissuenotifications(string issuenotificationuserid)
        {


            string sqlStatement = "SELECT isID FROM tblIssuenotice WHERE uID=@0;";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", issuenotificationuserid);

            DataSet ds = clsSQL.ExecuteQuery(command);


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


     




        int IDatamanagement.deleteissuenotification(string issid,string uid)
        {

            string sqlStatement = "DELETE FROM tblIssuenotice WHERE isID=@0 AND uID=@1;";

            SqlCommand command = new SqlCommand(sqlStatement);


            command.Parameters.AddWithValue("@0", issid);

            command.Parameters.AddWithValue("@1", uid);


            return clsSQL.ExecuteNonQuery(command);
        }



        int IDatamanagement.addprojteam(string uid, string projid)
        {
            string sqlStatement = "INSERT INTO tblTeams (projID, uID) VALUES (@0,@1);";
            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", projid);
            command.Parameters.AddWithValue("@1", uid);
            
            return clsSQL.ExecuteNonQuery(command);
        }




        int IDatamanagement.deleteprojteam(string projid)
        {
            string sqlStatement = "DELETE FROM tblTeams WHERE projID=@0;";

            SqlCommand command = new SqlCommand(sqlStatement);


            command.Parameters.AddWithValue("@0", projid);



            return clsSQL.ExecuteNonQuery(command);
        }

        int IDatamanagement.deleteassiguserfromteam(string uid, string projid)
        {
            string sqlStatement = "DELETE FROM tblTeams WHERE uID=@0 AND projID=@1;";

            SqlCommand command = new SqlCommand(sqlStatement);


            command.Parameters.AddWithValue("@0", uid);
            command.Parameters.AddWithValue("@1", projid);


            return clsSQL.ExecuteNonQuery(command);
        }


        int IDatamanagement.addissteam(string uid, string issueid)
        {


            string sqlStatement = "INSERT INTO tblissuesteam (isID, uID) VALUES (@0,@1);";
            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", issueid);
            command.Parameters.AddWithValue("@1", uid);

            return clsSQL.ExecuteNonQuery(command);
        }




        int IDatamanagement.deleteissteam(string issueid)
        {
            string sqlStatement = "DELETE FROM tblIssues WHERE isID=@0;";

            SqlCommand command = new SqlCommand(sqlStatement);


            command.Parameters.AddWithValue("@0", issueid);



            return clsSQL.ExecuteNonQuery(command);
        }

        int IDatamanagement.deleteprojissues(string projid)
        {
            string sqlStatement = "DELETE FROM tblIssues WHERE projID=@0;";

            SqlCommand command = new SqlCommand(sqlStatement);


            command.Parameters.AddWithValue("@0", projid);



            return clsSQL.ExecuteNonQuery(command);

        }

        int IDatamanagement.deleteassiguserformissue(string uid, string issueid)
        {
            string sqlStatement = "DELETE FROM tblIssuesteam WHERE isID=@0 AND uID=@1;";

            SqlCommand command = new SqlCommand(sqlStatement);


            command.Parameters.AddWithValue("@0", issueid);
            command.Parameters.AddWithValue("@1", uid);


            return clsSQL.ExecuteNonQuery(command);
        }

        Object[][] IDatamanagement.getuserinformation()
        {
            string sqlStatement = "SELECT tblUser.uID, tblUser.uUsername, tblSkills.sName FROM tblUser INNER JOIN tblSkills ON tblUser.sID = tblSkills.sID;";

            SqlCommand command = new SqlCommand(sqlStatement);

          

            DataSet ds = clsSQL.ExecuteQuery(command);

            return create2DAdsArray(ds);

        }

        int IDatamanagement.insertprojectnotifications(string porjid, string uid)
        {
            string sqlStatement = "INSERT INTO tblProjnotice (projID, uID) VALUES (@0,@1);";
            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", porjid);
            command.Parameters.AddWithValue("@1", uid);

            return clsSQL.ExecuteNonQuery(command);
        }

        int IDatamanagement.insertissuenotifications(string issueid, string uid)
        {
            string sqlStatement = "INSERT INTO tblIssuenotice (isID, uID) VALUES (@0,@1);";
            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", issueid);
            command.Parameters.AddWithValue("@1", uid);

            return clsSQL.ExecuteNonQuery(command);
        }

        object[] IDatamanagement.getprojectleaderinformaion(string uid)
        {
            string sqlStatement = "SELECT uUsername , uEmail FROM tblUser WHERE uID = @0;";

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

        object[] IDatamanagement.getprojectmembers(string projid)
        {
            string sqlStatement = "SELECT uID FROM tblTeams WHERE projID=@0;";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", projid);

            DataSet ds = clsSQL.ExecuteQuery(command);


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

        int IDatamanagement.updateproject(string title, string description, string projID)
        {
            string sqlStatement = "UPDATE tblProject SET projTitle=@0, projDescription=@1 WHERE projID=@2;";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", title);
            command.Parameters.AddWithValue("@1", description);
            command.Parameters.AddWithValue("@2", projID);

            return clsSQL.ExecuteNonQuery(command);
        }

        object[] IDatamanagement.getspecificuserinformation(string uid)
        {
            string sqlStatement = "SELECT tblUser.uUsername, tblUser.uEmail, tblSkills.sName FROM tblUser INNER JOIN tblSkills ON tblUser.sID = tblSkills.sID WHERE tblUser.uID=@0;";

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

        object[][] IDatamanagement.getmeetinginfromations(string uid)
        {

            string sqlStatement = "SELECT tblmeeting.meetTitle, tblmeeting.meetDesc, tblmeeting.Datetime, tblmeeting.projID, tblmeeting.uID FROM tblmeeting INNER JOIN tblmeetinglink ON tblmeeting.meetID = tblmeetinglink.meetID WHERE tblmeetinglink.uID = @0;";

            SqlCommand command = new SqlCommand(sqlStatement);
            command.Parameters.AddWithValue("@0", uid);


            DataSet ds = clsSQL.ExecuteQuery(command);

            return create2DAdsArray(ds);


           
        }

        int IDatamanagement.deletemeeting(string meetingid)
        {

            string sqlStatement = "DELETE FROM tblmeeting WHERE meetID=@0;";

            SqlCommand command = new SqlCommand(sqlStatement);


            command.Parameters.AddWithValue("@0", meetingid);
   


            return clsSQL.ExecuteNonQuery(command);
    
        }

        int IDatamanagement.insertmeeting(string meettitle, string meetdesc, string meetdatetime, string projid,string uid)
        {
            string sqlStatement = "INSERT INTO tblmeeting (meetTitle, meetDesc, meetDatetime, projID, uID) VALUES (@0,@1,@2,@3,@4);";
            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", meettitle);
            command.Parameters.AddWithValue("@1", meetdesc);
            command.Parameters.AddWithValue("@2", meetdatetime);
            command.Parameters.AddWithValue("@3", projid);
            command.Parameters.AddWithValue("@4", uid);

            return clsSQL.ExecuteNonQuery(command);
        }

        int IDatamanagement.insertmeetingmember(string meetid,string uid, string mlaccept)
        {

            string sqlStatement = "INSERT INTO tblmeetinglink (meetID, uID, mlaccept) VALUES (@0,@1,@2);";
            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", meetid);
            command.Parameters.AddWithValue("@1", uid);
            command.Parameters.AddWithValue("@2", mlaccept);
            return clsSQL.ExecuteNonQuery(command);

        }

        int IDatamanagement.updatemeeting(string meetingid, string meettitle,string meetdesc,string meetdatetime,string projid,string uid)
        {

          
            string sqlStatement = "UPDATE tblmeeting SET meetTitle=@1, meetDesc=@2, meetDatetime=@3, projID=@4, uID=@ WHERE meetID=@0;";
            SqlCommand command = new SqlCommand(sqlStatement);


            command.Parameters.AddWithValue("@0", meetingid);
            command.Parameters.AddWithValue("@1", meettitle);
            command.Parameters.AddWithValue("@2", meetdesc);
            command.Parameters.AddWithValue("@3", meetdatetime);
            command.Parameters.AddWithValue("@4", projid);
            command.Parameters.AddWithValue("@5", uid);


            return clsSQL.ExecuteNonQuery(command);


          
        }

       

        int IDatamanagement.deletemeetingmembers(string meetid)
        {
            string sqlStatement = "DELETE FROM tblmeetinglink WHERE meetID=@0;";

            SqlCommand command = new SqlCommand(sqlStatement);


            command.Parameters.AddWithValue("@0", meetid);
            


            return clsSQL.ExecuteNonQuery(command);
        }


        object[] IDatamanagement.getprojmeetings(string projid)
        {
            string sqlStatement = "SELECT meetID FROM tblmeeting WHERE projID = @0;";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", projid);

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


       

        int IDatamanagement.deletespecificmember(string meetid, string uid)
        {
            string sqlStatement = "DELETE FROM tblmeetinglink WHERE meetID=@0 AND uID=@1;";

            SqlCommand command = new SqlCommand(sqlStatement);


            command.Parameters.AddWithValue("@0", meetid);
            command.Parameters.AddWithValue("@1",uid);


            return clsSQL.ExecuteNonQuery(command);
        }

        int IDatamanagement.updatemetinglink(string meetID, string uID, string mlaccept)
        {
            string sqlStatement = "UPDATE tblmeetinglink SET mlaccept=@2 WHERE mlID=@0 AND uID=@1;";

            SqlCommand command = new SqlCommand(sqlStatement);


            command.Parameters.AddWithValue("@0", meetID);
            command.Parameters.AddWithValue("@1", uID);
            command.Parameters.AddWithValue("@2", mlaccept);
          


            return clsSQL.ExecuteNonQuery(command);
        }

        int IDatamanagement.insertissflag(string isstitle, string issdesc, string projid, string uid)
        {
            string sqlStatement = "INSERT INTO tblissueflag (isstitle, issdesc, projid, uid) VALUES (@0,@1,@2,@3);";
            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", isstitle);
            command.Parameters.AddWithValue("@1", issdesc);
            command.Parameters.AddWithValue("@2", projid);
            command.Parameters.AddWithValue("@3", uid);

            return clsSQL.ExecuteNonQuery(command);
        }

        object[][] IDatamanagement.getissueflags(string projID)
        {
            string sqlStatement = "SELECT tblissueflag.isfID, tblUser.uUsername, tblUser.uEmail, tblissueflag.isfTitle, tblissueflag.isfDesc, tblissueflag.projID FROM tblissueflag INNER JOIN tblUser ON tblissueflag.uID = tblUser.uID WHERE tblissueflag.projID = @0;";

            SqlCommand command = new SqlCommand(sqlStatement);
            command.Parameters.AddWithValue("@0", projID);


            DataSet ds = clsSQL.ExecuteQuery(command);

            return create2DAdsArray(ds);
           
        }

        int IDatamanagement.deleteissflag(string isfid)
        {
            string sqlStatement = "DELETE FROM tblissueflag WHERE isfID = @0;";

            SqlCommand command = new SqlCommand(sqlStatement);


            command.Parameters.AddWithValue("@0", isfid);
           


            return clsSQL.ExecuteNonQuery(command);
        }

        object[] IDatamanagement.getspecificissflag(string isfid)
        {

            string sqlStatement = "SELECT tblissueflag.isfID, tblUser.uUsername, tblUser.uEmail, tblissueflag.isfTitle, tblissueflag.isfDesc, tblissueflag.projID FROM tblissueflag INNER JOIN tblUser ON tblissueflag.uID = tblUser.uID WHERE tblissueflag.isfID = @0;";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", isfid);

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

        object[][] IDatamanagement.issueteam(string isID)
        {
            string sqlStatement = "SELECT tblIssuesteam.uID, tblUser.uUsername, tblUser.uEmail FROM tblIssuesteam INNER JOIN tblUser ON tblIssuesteam.uID = tblUser.uID WHERE tblIssuesteam.isID = @0;";

            SqlCommand command = new SqlCommand(sqlStatement);
            command.Parameters.AddWithValue("@0", isID);


            DataSet ds = clsSQL.ExecuteQuery(command);

            return create2DAdsArray(ds);
        }

        object[][] IDatamanagement.getalluserevents(string uid)
        {


            string sqlStatement = "SELECT * FROM tblEvent WHERE uID = @0;";

            SqlCommand command = new SqlCommand(sqlStatement);
            command.Parameters.AddWithValue("@0", uid);


            DataSet ds = clsSQL.ExecuteQuery(command);

            return create2DAdsArray(ds);
        }
    }
}
