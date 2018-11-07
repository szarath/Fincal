using Wcffincal.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Wcffincal
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Userservice : IUserservice
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }


        object[] IUserservice.Authenticate(string UserEmailOrUsername, string Password)
        {
            string sqlStatement = "SELECT uID, uFirstName, uSurname, uDoB, sID, uGitrepo FROM tblUser WHERE (UPPER(uUsername)=@0 OR UPPER(uEmail)=@0) AND uPass=@1;";

            SqlCommand command = new SqlCommand(sqlStatement);



            command.Parameters.AddWithValue("@0", UserEmailOrUsername.ToUpper());
            command.Parameters.AddWithValue("@1", Password);

            DataSet ds = clsSQL.ExecuteQuery(command);




            string[] temp = null;
            if (!(ds.Tables.Count == 0))
            {
                if (!(ds.Tables[0].Rows.Count == 0))
                {
                    temp = new string[ds.Tables[0].Columns.Count];
                    for (int k = 0; k < ds.Tables[0].Columns.Count; k++)
                    {
                        temp[k] = ds.Tables[0].Rows[0][k].ToString();
                    }
                }
            }


            return temp;
        }

        int IUserservice.insertUser(string Username, string Password, string firstName, string surname, string Email, DateTime DoB,string skill, string gitrepo)
        {
            string sqlStatement = "INSERT INTO tblUser (uUsername, uPass, uFirstName, uSurname, uEmail, uDoB, sID, uGitrepo) VALUES(@0,@1,@2,@3,@4,@5,@6,@7);";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", Username);
            command.Parameters.AddWithValue("@1", Password);
            command.Parameters.AddWithValue("@2", firstName);
            command.Parameters.AddWithValue("@3", surname);
            command.Parameters.AddWithValue("@4", Email);
            command.Parameters.AddWithValue("@5", DoB);
            command.Parameters.AddWithValue("@6", skill);
            command.Parameters.AddWithValue("@7", gitrepo);
            return clsSQL.ExecuteNonQuery(command);
        }

        string IUserservice.GetData(int value)
        {
            throw new NotImplementedException();
        }

        CompositeType IUserservice.GetDataUsingDataContract(CompositeType composite)
        {
            throw new NotImplementedException();
        }

        object[] IUserservice.getUserDetailsManagement(int userID)
        {
            string sqlStatement = "SELECT * FROM tblUser WHERE uID=@0";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", userID);

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



        int IUserservice.deleteUser(string ID)
        {
            string sqlStatement = "DELETE FROM tblEventpic WHERE uID=@0;DELETE FROM tblUser WHERE uID=@0;";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", ID);

            return clsSQL.ExecuteNonQuery(command);
        }

        int IUserservice.updateUserInfo(string ID, string firstName, string surname, DateTime DoB, string skill, string gitrepo)
        {
            string sqlStatement = "UPDATE tblUser SET uFirstName=@0, uSurname=@1, uDoB=@2, sID=@3, uGitrepo=@5 WHERE uID=@4;";

            SqlCommand command = new SqlCommand(sqlStatement);

            command.Parameters.AddWithValue("@0", firstName);
            command.Parameters.AddWithValue("@1", surname);
            command.Parameters.AddWithValue("@2", DoB);
            command.Parameters.AddWithValue("@3", skill);
            command.Parameters.AddWithValue("@4", ID);
            command.Parameters.AddWithValue("@5", gitrepo);
            return clsSQL.ExecuteNonQuery(command);
        }

    }
}
