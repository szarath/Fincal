using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;
using Google.Apis.Tasks.v1;
using Google.Apis.Tasks.v1.Data;
using System.Text;

using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
namespace Fincal
{
    public partial class Default : System.Web.UI.Page
    {
       


        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null) //Logged in
            {
                indexTitle.InnerHtml = "Please Sign in or Register";

            }
            else {

                indexTitle.InnerHtml = "Welcome " + ((UserData)Session["User"]).getFirstName() + "!  Here is what you missed";
                eventmain.Visible = true;
                taskmain.Visible = true;
                picturemain.Visible = true;
                Eventsget();
                Taskget();
                Pictureget();

                }

        }

        private void Eventsget()
        {
            string[] Scopes = { CalendarService.Scope.CalendarReadonly };
            string ApplicationName = "Google Calendar API .NET Quickstart";
            //     if (Session["User"] != null) //Logged in
            //   {
            UserData user = (UserData)Session["User"];
         

            string htmldata = "";
            string temp = "";
            UserCredential credential;

            using (var stream =
                new FileStream(Server.MapPath("client_secret.json"), FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal); ;
                credPath = Path.Combine(credPath, ".credentials/calendar-dotnet-quickstart.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets, Scopes, "user", CancellationToken.None, new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);




            }

            // Create Google Calendar API service.
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Define parameters of request.
            EventsResource.ListRequest request = service.Events.List("primary");
            request.TimeMin = DateTime.Now;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = 5;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            string picturedef = " ";
            Object[] pics;

            // List events.
            Google.Apis.Calendar.v3.Data.Events events = request.Execute();

            Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
            findata.Open();



            if (events.Items != null && events.Items.Count > 0)
            {
                foreach (var eventItem in events.Items)
                {

                    string when = eventItem.Start.DateTime.ToString();
                    if (String.IsNullOrEmpty(when))
                    {
                        when = eventItem.Start.Date;

                    }

                    string desc = eventItem.Description;
                    string summary = eventItem.Summary;
                    string loc = eventItem.Location;
                    string id = eventItem.Id;


                    if (desc == null)
                    {
                        desc = "";
                    }
                    if (summary == null)
                    {
                        summary = "";
                    }
                    if (loc == null)
                    {
                        loc = "Johannesburg";
                    }
                    Boolean exsisting = false;
                    object[] googleids = findata.geteventids(user.getID().ToString());

                    if (googleids != null)
                    {

                        for (int i = 0; i < googleids.Length; i++)
                        {
                            if (eventItem.Id == (string)googleids[i])
                            {
                                exsisting = true;
                            }
                        }

                        if (exsisting == true)
                        {
                        }
                        else if (exsisting == false)
                        {
                            findata.deleteevent(eventItem.Id, user.getID().ToString());
                            findata.deleteeventpics(eventItem.Id, user.getID().ToString());
                        }

                    }
                    if (findata.checkevents(Convert.ToString(id), user.getID().ToString()) == Convert.ToString(id))
                    {
                        object[] storedevent = findata.getevent(id, user.getID().ToString());
                        if ((string)storedevent[1] == when || (string)storedevent[2] == summary || (string)storedevent[3] == loc || (string)storedevent[6] == desc)
                        {


                        }
                        else
                        {
                            findata.updateevent(DateTime.Parse(when), eventItem.Summary, eventItem.Location, eventItem.Description, (string)storedevent[0]);


                        }

                        htmldata += "<a href=\"EventEdit.aspx?eid=" + eventItem.Id + "\">";
                        htmldata += "<div class=\"col s12 m2 l0 \">";
                        htmldata += "<div class=\"card horizontal hoverable\">";

                        /*  htmldata += "<div class=\"card-image\">";

                          if (findata.geteventfirstpics(id) != null)
                          {
                              htmldata += "<img style='width:200px;height:200px' class= \"responsive-img\" src = 'data:image/jpeg;base64," + findata.geteventfirstpics(id) + "'/>";
                          }
                          else
                          {
                              htmldata += "<img style='width:200px;height:200px' class= \"responsive-img\" src = 'data:image/jpeg;base64," + UserData.Nopic + "'/>";

                          }



                          htmldata += "</div>";*/
                        htmldata += "<div class=\"card-stacked\">";
                        htmldata += "<div class=\"card-content black-text\">";
                        htmldata += "<span class=\"card-title\">" +
                                "<p class=\" bold\">" + eventItem.Summary + "</p>";
                        htmldata += "</span>";
                        htmldata += "<p class=\"trunctext\">Date: " + when + "</p>";
   
                        htmldata += "</span>";
                        htmldata += "<p class=\"trunctext\">Location: " + eventItem.Location + "</p>";


                        htmldata += "</div>";
                        htmldata += "</div>";
                        htmldata += "</div>";
                        htmldata += "</div>";
                        htmldata += "</a>";

                    }
                    else
                    {

                        findata.insertevent(Convert.ToDateTime(when), summary, loc, id, user.getID().ToString(), desc);

                        htmldata += "<a href=\"EventEdit.aspx?eid=" + id + "\">";
                        htmldata += "<div class=\"col  s12 m2 l0 \">";


                        htmldata += "<div class=\"card horizontal hoverable\">";
                        /* htmldata += "<div class=\"card-image\">";

                         htmldata += "<img style='width:200px;height:200px' class= \"responsive-img\" src = 'data:image/jpeg;base64," + UserData.Nopic + "'/>";


                         htmldata += "</div>";*/
                        htmldata += "<div class=\"card-stacked\">";
                        htmldata += "<div class=\"card-content black-text\">";
                        htmldata += "<span class=\"card-title\">" +
                         "<p class=\" bold\">" + eventItem.Summary + "</p>";
                        htmldata += "</span>";
                        htmldata += "<p class=\"trunctext\">Date: " + when + "</p>";
               
                        htmldata += "</span>";
                        htmldata += "<p class=\"trunctext\">Location: " + eventItem.Location + "</p>";



                        htmldata += "</div>";
                        htmldata += "</div>";
                        htmldata += "</div>";
                        htmldata += "</div>";
                        htmldata += "</a>";
                    }





                }


            }
            else
            {
                Console.WriteLine("No upcoming events found.");

            }
            
            //Console.Read();
            htmldata += "</div>";

            //  htmldata += temp;
            upev.InnerHtml = htmldata;
            findata.Close();
            /* }
             else
             {
                 Response.Redirect("Login.aspx");
             }*/

        }

        private void Taskget()
        {
             string[] Scopes = { TasksService.Scope.TasksReadonly };
             string ApplicationName = "Google Tasks API .NET Quickstart";
            object[] storedtask = null;
            // string htmldata = "<div class='row'>";
            string taskcolor = "white";
            string complete = " <div class='row'>";
            string incomplete = "<div class='row'>";

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
                        if (findata.checktasks(id, user.getID()) == id)
                        {
                            storedtask = findata.gettask(id, user.getID());
                            if ((string)storedtask[1] == title)
                            {


                            }
                            else
                            {
                                findata.updatetask(task.Title, "1", user.getID(), (string)storedtask[4], task.Id);


                            }
                            complete += "<a href=\"Taskedit.aspx?id=" + task.Id + "\">";
                            complete += "<div class=\"col s12 m2 10\">";
                            complete += "<div class=\"card horizontal hoverable " + colorchoice(Convert.ToInt32((string)storedtask[4])) + "\">";
                            //   htmldata += "<div class=\"card horizontal hoverable blue\">";
                            complete += "<div class=\"card-stacked\">";
                            complete += "<div class=\"card-content black-text\">";
                            complete += "<span class=\"card-title\"><p class=\"trunctext\">" + task.Title.ToString() + "</p>";
                            complete += "</span>";
                            complete += "</div>";
                            complete += "</div>";
                            complete += "</div>";
                            complete += "</div>";
                            complete += "</a>";

                        }
                        else
                        {
                            findata.inserttask(task.Title, "1", "1", task.Id, user.getID());
                            complete += "<a href=\"Taskedit.aspx?id=" + task.Id + "\">";
                            complete += "<div class=\"col  s12 m2 10\">";
                            //     complete += "<div class=\"card horizontal hoverable " + colorchoice(Convert.ToInt32((string)storedtask[4])) + " href=\"Taskedit" + "?id=" + task.Id + "\">";
                            complete += "<div class=\"card horizontal hoverable\">";
                            complete += "<div class=\"card-stacked\">";
                            complete += "<div class=\"card-content black-text\">";
                            complete += "<span class=\"card-title\"><p class=\"trunctext\">" + task.Title.ToString() + "</p>";
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

                        if (findata.checktasks(id, user.getID()) == id)
                        {
                            storedtask = findata.gettask(id, user.getID());
                            if ((string)storedtask[1] == title)
                            {


                            }
                            else
                            {
                                findata.updatetask(task.Title, "0", user.getID(), (string)storedtask[4], task.Id);


                            }
                           

                            incomplete += "<a href=\"Taskedit.aspx?id=" + task.Id + "\">";
                            incomplete += "<div class=\"col s12 m2 10\">";
                            incomplete += "<div class=\"card  hoverable " + colorchoice(Convert.ToInt32((string)storedtask[4])) + " href=\"Taskedit" + "?id=" + task.Id + "\">";
                            //   htmldata += "<div class=\"card horizontal hoverable blue\">";
                            incomplete += "<div class=\"card-stacked\">";
                            incomplete += "<div class=\"card-content black-text\">";
                            incomplete += "<span class=\"card-title\"><p class=\"trunctext\">" + task.Title.ToString() + "</p>";
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
                            incomplete += "<div class=\"col s12 m2 10\">";
                            // incomplete += "<div class=\"card horizontal hoverable " + colorchoice(Convert.ToInt32((string)storedtask[4])) + " href=\"Taskedit" + "?id=" + task.Id + "\">";
                            incomplete += "<div class=\"card  hoverable\">";
                            incomplete += "<div class=\"card-stacked\">";
                            incomplete += "<div class=\"card-content black-text\">";
                            incomplete += "<span class=\"card-title\"><p class=\"trunctext\">" + task.Title.ToString() + "</p>";
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
                Console.WriteLine("No task lists found.");
            }


            // List task lists.

            //Console.Read();
            incomplete += "</div>";
            complete += "</div>";
            taskinprogress.InnerHtml = incomplete;
            completedtask.InnerHtml = complete;
            findata.Close();
        }

        private string colorchoice(int choice)
        {
            if (choice == 1)
            {
                return "white";
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


        private void Pictureget()
        {
            UserData user = (UserData)Session["User"];
            string htmldata = "<div>";
              Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
            findata.Open();
            // UserData currentUser = (UserData)(Session["User"]);
            Object[][] pictures = findata.getfewpics(user.getID());
            if (pictures != null)
            {

                for (int i = 0; i < pictures.Length; i++)
                {
                    // htmldata += "<a class=\"carousel - item\" href=\"Pictureedit?id=" + (string)pictures[i][0] + "\"><img style='width:250px;height:250px' class= \"responsive-img\" src = 'data:image/jpeg;base64," + (string)pictures[i][1] + "'/></a>";


                    htmldata += "<a href=\"Pictureedit.aspx?id=" + (string)pictures[i][0] + "\">";


                    htmldata += "<div class=\"col 10 card hoverable\">";

                    htmldata += "<div class=\"card-image waves-effect waves-block waves-light\">";
                    htmldata += "<img style='width:200px;height:200px' class= \"responsive-img\" src = 'data:image/jpeg;base64," + (string)pictures[i][1] + "'/>";
                    htmldata += "<span class=\"card-title \">" + (string)pictures[i][2] + "</span>";
                    htmldata += "</div>";




                    htmldata += "</div>";

                }
                // htmldata += "<a class=\"carousel - item\" href=\"#one!\"><img style='width:300px;height:300px' class= \"responsive-img\" src = 'data:image/jpeg;base64," + UserData.Nopic + "'/></a>";
              

            }


            htmldata += "</div>";
            picturecarousel.InnerHtml = htmldata;

            findata.Close();
          
        }


    }

    }
