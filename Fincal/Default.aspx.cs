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
            
            if(Session["User"] != null) {
               
                indexTitle.InnerHtml = "<div class=\"col s12 m10 l8 \"><h5>Welcome " + ((UserData)Session["User"]).getFirstName() + "!  Here is what you missed</h5></div>";
                eventmain.Visible = true;
                taskmain.Visible = true;
                picturemain.Visible = true;
                projectnotificaitonmain.Visible = true;
                issuenotificaitonmain.Visible = true;
                getissuenotifitcaions();
                getprojectnotificaitons();
                meetings();
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
            Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
            findata.Open();
            Object[][] userevents = findata.getalluserevents(user.getID());

           

                if (userevents != null)
                {


                    for (int j = 0; j < userevents.Length; j++)
                    {
                        DateTime credate = DateTime.Parse((string)userevents[j][1]);
                        DateTime exweek = credate.AddDays(14);


                        int result = DateTime.Compare(exweek, DateTime.Now);

                        if (result < 0)
                        {
                            findata.deleteevent((string)userevents[j][4], user.getID());
                        }
                        else
                        {



                        }


                    }


                }





            

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
            request.MaxResults = 6;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            string picturedef = " ";
            Object[] pics;

            // List events.
            Google.Apis.Calendar.v3.Data.Events events = request.Execute();

           



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
                            findata.updateevent(DateTime.Parse(when), eventItem.Summary, eventItem.Location, eventItem.Description, (string)storedevent[4],(string)storedevent[0]);


                        }

                        htmldata += "<a href=\"EventEdit.aspx?eid=" + eventItem.Id + "\">";
                        htmldata += "<div class=\"col s12 m4 7 \">";
                        htmldata += "<div class=\"card horizontal hoverable deep-purple lighten-3\">";

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
                                "<p class=\"bold trunctext\">" + eventItem.Summary + "</p>";
                        htmldata += "</span>";
                        htmldata += "<p class=\"bold\">Date/Time: " + when + "</p>";

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
                        htmldata += "<div class=\"col s12 m4 7 \">";


                        htmldata += "<div class=\"card horizontal hoverable deep-purple lighten-3\">";
                        /* htmldata += "<div class=\"card-image\">";

                         htmldata += "<img style='width:200px;height:200px' class= \"responsive-img\" src = 'data:image/jpeg;base64," + UserData.Nopic + "'/>";


                         htmldata += "</div>";*/
                        htmldata += "<div class=\"card-stacked\">";
                        htmldata += "<div class=\"card-content black-text\">";
                        htmldata += "<span class=\"card-title\">" +
                         "<p class=\"bold trunctext\">" + eventItem.Summary + "</p>";
                        htmldata += "</span>";
                        htmldata += "<p class=\"bold\">Date/Time: " + when + "</p>";
               
                        
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

           


            TasksResource.ListRequest request = service.Tasks.List("@default");
            request.MaxResults = 20;
            Google.Apis.Tasks.v1.Data.Tasks tasks = request.Execute();
          
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
                              
                                findata.updatetask(task.Title, "1", user.getID().ToString(), (string)storedtask[4], task.Id, (string)storedtask[0]);


                            }
                            complete += "<a href=\"Taskedit.aspx?id=" + task.Id + "\">";
                            complete += "<div class=\"col s12 m3 7\">";
                            complete += "<div class=\"card horizontal hoverable " + colorchoice(Convert.ToInt32((string)storedtask[4])) + "\">";
                            //   htmldata += "<div class=\"card horizontal hoverable blue\">";
                            complete += "<div class=\"card-stacked\">";
                            complete += "<div class=\"card-content black-text\">";
                            complete += "<span class=\"card-title\"><p class=\"trunctext bold\">" + task.Title.ToString() + "</p>";
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
                            complete += "<div class=\"col s12 m3 7\">";
                            //     complete += "<div class=\"card horizontal hoverable " + colorchoice(Convert.ToInt32((string)storedtask[4])) + " href=\"Taskedit" + "?id=" + task.Id + "\">";
                            complete += "<div class=\"card horizontal hoverable green\">";
                            complete += "<div class=\"card-stacked\">";
                            complete += "<div class=\"card-content black-text\">";
                            complete += "<span class=\"card-title\"><p class=\"trunctext bold\">" + task.Title.ToString() + "</p>";
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
                               
                                findata.updatetask(task.Title, "1", user.getID().ToString(), (string)storedtask[4], task.Id, (string)storedtask[0]);


                            }
                           

                            incomplete += "<a href=\"Taskedit.aspx?id=" + task.Id + "\">";
                            incomplete += "<div class=\"col s12 m3 7\">";
                            incomplete += "<div class=\"card  hoverable " + colorchoice(Convert.ToInt32((string)storedtask[4])) + "\">";
                            //htmldata += "<div class=\"card horizontal hoverable blue\">";
                            incomplete += "<div class=\"card-stacked\">";
                            incomplete += "<div class=\"card-content black-text\">";
                            incomplete += "<span class=\"card-title\"><p class=\"trunctext bold\">" + task.Title.ToString() + "</p>";
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
                            incomplete += "<div class=\"col s12 m3 7\">";
                            // incomplete += "<div class=\"card horizontal hoverable " + colorchoice(Convert.ToInt32((string)storedtask[4])) + " href=\"Taskedit" + "?id=" + task.Id + "\">";
                            incomplete += "<div class=\"card  hoverable green\">";
                            incomplete += "<div class=\"card-stacked\">";
                            incomplete += "<div class=\"card-content black-text\">";
                            incomplete += "<span class=\"card-title\"><p class=\"trunctext bold\">" + task.Title.ToString() + "</p>";
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


                    htmldata += "<div class=\"col 7 card hoverable\">";

                    htmldata += "<div class=\"card-image waves-effect waves-block waves-light\">";
                    htmldata += "<img style='width:200px;height:200px' class= \"responsive-img\" src = 'data:image/jpeg;base64," + (string)pictures[i][1] + "'/>";
                    htmldata += "<span class=\"card-title \"><p class=\"trunctext bold\">" + (string)pictures[i][2] + "</p></span>";
                    htmldata += "</div>";




                    htmldata += "</div>";
                    htmldata += "</a>";
                }
                // htmldata += "<a class=\"carousel - item\" href=\"#one!\"><img style='width:300px;height:300px' class= \"responsive-img\" src = 'data:image/jpeg;base64," + UserData.Nopic + "'/></a>";
              

            }


            htmldata += "</div>";
            picturecarousel.InnerHtml = htmldata;

            findata.Close();
          
        }


        private void getprojectnotificaitons()
        {
             string htmldata =""; 
            Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
            findata.Open();
            UserData user = (UserData)Session["User"];
            object[][] projectnotificaiotns = findata.getprojnotification(user.getID());

            if (projectnotificaiotns != null)
            {
                for (int j = 0; j < projectnotificaiotns.Length; j++)
                {
                    object[] projdetails = findata.getprojectdetails((string)projectnotificaiotns[j][1]);

                    DateTime credate = DateTime.Parse((string)projectnotificaiotns[j][3]);
                    DateTime exdate = credate.AddDays(14);


                    int result = DateTime.Compare(exdate, DateTime.Now);

                    if (result < 0)
                    {
                        findata.deleteporjnotificaiton((string)projectnotificaiotns[j][0], user.getID());
                    }
                    else
                    {
                       
                        htmldata += "<a href=\"Projectaccept.aspx?id=" + (string)projdetails[0] +"&pn="+ (string)projectnotificaiotns[j][0] + "\">";
                        htmldata += "<div class=\"col s12 m4 7\">";
                        // incomplete += "<div class=\"card horizontal hoverable " + colorchoice(Convert.ToInt32((string)storedtask[4])) + " href=\"Taskedit" + "?id=" + task.Id + "\">";
                        htmldata += "<div class=\"card  hoverable green accent-2\">";
                        htmldata += "<div class=\"card-stacked\">";
                        htmldata += "<div class=\"card-content black-text\">";
                        htmldata += "<span class=\"card-title\"><p class=\"bold\">" + (string)projdetails[1] + "</p>";
                        htmldata += "</span>";

                        htmldata += "</div>";
                        htmldata += "</div>";
                        htmldata += "</div>";
                        htmldata += "</div>";

                        htmldata += "</a>";


                    }


                }


            }
            findata.Close();
            newprojects.InnerHtml = htmldata;

         }


        private void getissuenotifitcaions()
        {

            string htmldata = "";
            Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();

            UserData user = (UserData)Session["User"];
            findata.Open();
            object[][] issuenotifications = findata.getissuenotifications(user.getID());
            if (issuenotifications != null)
            {
                for (int i = 0; i < issuenotifications.Length; i++)
                {
                    DateTime credate = DateTime.Parse((string)issuenotifications[i][3]);
                    DateTime exdate = credate.AddDays(14);
                    object[] issuedetails = findata.getissuedetails((string)issuenotifications[i][1]);
                    object[] projdetails = findata.getprojectdetails((string)issuedetails[3]); 
                    int result = DateTime.Compare(exdate, DateTime.Now);

                    if (result < 0)
                    {
                        findata.deleteporjnotificaiton((string)issuenotifications[i][0], user.getID());
                    }
                    else {
                   
                        htmldata += "<a href=\"Issueaccept.aspx?id=" + (string)issuedetails[0] +"&in="+ (string)issuenotifications[i][0] + "\">";
                        htmldata += "<div class=\"col s12 m4 7\">";
                        // incomplete += "<div class=\"card horizontal hoverable " + colorchoice(Convert.ToInt32((string)storedtask[4])) + " href=\"Taskedit" + "?id=" + task.Id + "\">";
                        htmldata += "<div class=\"card  hoverable orange lighten-3\">";
                        htmldata += "<div class=\"card-stacked\">";
                        htmldata += "<div class=\"card-content black-text\">";
                        htmldata += "<span class=\"card-title\"><p class=\"bold\">" + (string)issuedetails[1] + "</p>";
                        htmldata += "</span>";
                        htmldata += "<p class=\"trunctext\">Project: " + (string)projdetails[1] + "</p>";
                        htmldata += "</div>";
                        htmldata += "</div>";
                        htmldata += "</div>";
                        htmldata += "</div>";
                        htmldata += "</a>";

                    }
                   

                }
            }
            findata.Close();

            newissues.InnerHtml = htmldata;

        }
        private void meetings()
        {
            Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
            findata.Open();
            UserData user = (UserData)Session["User"];
            Object[][] usermeetings = findata.getusermeetings(user.getID());

            if (usermeetings != null)
            {


                for (int j = 0; j < usermeetings.Length; j++)
                {
                    DateTime credate = DateTime.Parse((string)usermeetings[j][3]);
           
                    

                    int result = DateTime.Compare(credate, DateTime.Now);

                    if (result < 0)
                    {
                        int deletemeetmembers = findata.deletemeetingmembers((string)usermeetings[j][0]);
                        if (deletemeetmembers != 0)
                        {

                            findata.deletemeeting((string)usermeetings[j][0]);
                        }

                     
                    }
                   

                    Object[] projectmembers = findata.getprojectmembers((string)usermeetings[j][4]);
                    object[][] meetingmembers = findata.getmeetingmembers((string)usermeetings[j][4]);
                  
                    if (projectmembers != null)
                    {
                        if (meetingmembers!= null)
                        {

                            for (int i = 0; i < projectmembers.Length; i++)
                            {
                                bool inmeeting = false;
                                for (int a = 0; a < meetingmembers.Length; a++)
                                {
                                    if ((string)projectmembers[i] == (string)meetingmembers[a][0])
                                    {
                                        inmeeting = true;

                                    }


                                }

                                if (inmeeting == false)
                                {

                                    findata.insertmeetingmember((string)usermeetings[j][0], (string)projectmembers[i], "0");

                                }



                            }


                        }
                        else
                        {
                            for (int i = 0; i < projectmembers.Length; i++)
                            {
                                findata.insertmeetingmember((string)usermeetings[j][0], (string)projectmembers[i], "0");


                            }

                        }
                       


                    }



                }


            }

         


            findata.Close();




        }
    }

   

    }
