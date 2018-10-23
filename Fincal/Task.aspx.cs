using Google.Apis.Tasks.v1.Data;
using System;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Tasks.v1;

using Google.Apis.Services;
using Google.Apis.Util.Store;

using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Fincal
{
    public partial class Task : System.Web.UI.Page
    {
        static string[] Scopes = { TasksService.Scope.TasksReadonly };
        static string ApplicationName = "Google Tasks API .NET Quickstart";
        object[] storedtask;
        // string htmldata = "<div class='row'>";

        private string taskcolor = "white";
        string complete = " <div class='row'>";
        string incomplete = "<div class='row'>";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else { 
            Title = "Fincal: Tasks";
            UserCredential credential;





            using (var stream =
              new FileStream(Server.MapPath("client_secret.json"), FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal); ;
                credPath = Path.Combine(credPath, ".credentials/tasks-dotnet-quickstart.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets, Scopes, "user", CancellationToken.None, new FileDataStore(credPath, true)).Result;
                // Console.WriteLine("Credential file saved to: " + credPath);





            }

            // Create Google Tasks API service.
            var service = new TasksService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });



            // Define parameters of request.


            Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
            findata.Open();
            UserData user = (UserData)Session["User"];



            Tasks tasks = service.Tasks.List("@default").Execute();
            if (tasks.Items != null)
            {
                foreach (Google.Apis.Tasks.v1.Data.Task task in tasks.Items)
                {

                    string title = task.Title;
                    string id = task.Id;

                    if (task.Status.ToString() == "completed")
                    {
                        if (findata.checktasks(Convert.ToString(id), user.getID().ToString()) == Convert.ToString(id))
                        {
                            storedtask = findata.gettask(id, user.getID());
                            if ((string)storedtask[1] == title)
                            {


                            }
                            else
                            {
                                findata.updatetask(task.Title, "1", user.getID().ToString(), (string)storedtask[4], task.Id);


                            }
                            complete += "<a href=\"Taskedit.aspx?id=" + task.Id + "\">";
                            complete += "<div class=\"col s12 m2 10 \">";
                            complete += "<div class=\"card  hoverable " + colorchoice(Convert.ToInt32((string)storedtask[4])) + "\">";
                            //   htmldata += "<div class=\"card horizontal hoverable blue\">";
                            complete += "<div class=\"card-stacked\">";
                            complete += "<div class=\"card-content black-text\">";
                            complete += "<span class=\"card-title\"><p class=\" bold\">" + task.Title.ToString() + "</p>";
                            complete += "</span>";
                            complete += "</div>";
                            complete += "</div>";
                            complete += "</div>";
                            complete += "</div>";
                            complete += "</a>";

                        }
                        else
                        {
                            storedtask = findata.gettask(id, user.getID());
                            findata.inserttask(task.Title, "1", "1", task.Id, user.getID());
                            complete += "<a href=\"Taskedit.aspx?id=" + task.Id + "\">";
                            complete += "<div class=\"col s12 m2 10 \">";
                            //     complete += "<div class=\"card horizontal hoverable " + colorchoice(Convert.ToInt32((string)storedtask[4])) + " href=\"Taskedit" + "?id=" + task.Id + "\">";
                            complete += "<div class=\"card  hoverable\">";
                            complete += "<div class=\"card-stacked\">";
                            complete += "<div class=\"card-content black-text\">";
                            complete += "<span class=\"card-title\"><p class=\" bold\">" + task.Title.ToString() + "</p>";
                            complete += "</span>";

                            complete += "</div>";
                            complete += "</div>";
                            complete += "</div>";
                            complete += "</div>";
                            complete += "</a>";




                        }
                    }
                    else
                    {

                        if (findata.checktasks(Convert.ToString(id), user.getID()) == Convert.ToString(id))
                        {
                            storedtask = findata.gettask(id, user.getID());
                            if ((string)storedtask[1] == title)
                            {


                            }
                            else
                            {
                                findata.updatetask(task.Title, " 0", user.getID().ToString(), (string)storedtask[4], task.Id);


                            }
                            storedtask = findata.gettask(id, user.getID().ToString());

                            incomplete += "<a href=\"Taskedit.aspx?id=" + task.Id + "\">";
                            incomplete += "<div class=\"col s12 m2 10 \">";
                            incomplete += "<div class=\"card  hoverable " + colorchoice(Convert.ToInt32((string)storedtask[4])) + " href=\"Taskedit" + "?id=" + task.Id + "\">";
                            //   htmldata += "<div class=\"card horizontal hoverable blue\">";
                            incomplete += "<div class=\"card-stacked\">";
                            incomplete += "<div class=\"card-content black-text\">";
                            incomplete += "<span class=\"card-title\"><p class=\" bold\">" + task.Title.ToString() + "</p>";
                            incomplete += "</span>";

                            incomplete += "</div>";
                            incomplete += "</div>";
                            incomplete += "</div>";
                            incomplete += "</div>";
                            incomplete += "</a>";

                        }
                        else
                        {
                            findata.inserttask(task.Title, "0", "1", task.Id, user.getID());
                            incomplete += "<a href=\"Taskedit.aspx?id=" + task.Id + "\">";
                            incomplete += "<div class=\"col s12 m2 10 \">";
                            // incomplete += "<div class=\"card horizontal hoverable " + colorchoice(Convert.ToInt32((string)storedtask[4])) + " href=\"Taskedit" + "?id=" + task.Id + "\">";
                            incomplete += "<div class=\"card  hoverable\">";
                            incomplete += "<div class=\"card-stacked\">";
                            incomplete += "<div class=\"card-content black-text\">";
                            incomplete += "<span class=\"card-title\"><p class=\" bold \">" + task.Title.ToString() + "</p>";
                            incomplete += "</span>";

                            incomplete += "</div>";
                            incomplete += "</div>";
                            incomplete += "</div>";
                            incomplete += "</div>";

                            incomplete += "</a>";



                        }









                    }










                }
            }
            else
            {

            }


            // List task lists.

            //Console.Read();
            incomplete += "</div>";
            complete += "</div>";
            taskinprogress.InnerHtml = incomplete;
            completedtask.InnerHtml = complete;




            findata.Close();

        }
        }


        private string colorchoice(int choice)
        {
            if (choice == 1)
            {
                return "green";
            }
            else if (choice == 2)
            {
                return "blue";
            }
            else if (choice == 3)
            {
                return "red";
            }


            return "Nochoice";

        }


     
    
    }
}