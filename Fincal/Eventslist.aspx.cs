using System;
using System.Web.UI;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;


namespace Fincal
{
    public partial class Eventslist : System.Web.UI.Page
    {
        private int userID;


        static string[] Scopes = { CalendarService.Scope.CalendarReadonly };
        static string ApplicationName = "Google Calendar API .NET Quickstart";

        protected void Page_Load(object sender, EventArgs e)
        {
            //     if (Session["User"] != null) //Logged in
            //   {
            UserData user = (UserData)Session["User"];
            this.userID = user.getID();

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
            request.MaxResults = 100;
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
                    object[] googleids = findata.geteventids(userID.ToString());

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
                        findata.deleteevent(eventItem.Id);
                        findata.deleteeventpics(eventItem.Id);
                    }


                    if (findata.checkevents(Convert.ToString(id)) == Convert.ToString(id))
                    {
                        object[] storedevent = findata.getevent(id);
                        if ((string)storedevent[1] == when || (string)storedevent[2] == summary || (string)storedevent[3] == loc || (string)storedevent[6] == desc)
                        {


                        }
                        else
                        {
                            findata.updateevent(DateTime.Parse(when), eventItem.Summary, eventItem.Location, eventItem.Description, (string)storedevent[0]);


                        }

                        htmldata += "<a href=\"EventEdit?eid=" + eventItem.Id + "\">";
                        htmldata += "<div class=\"col s12 m l0  push-m1 push-l2\">";
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
                             "<p class=\"trunctext bold\">" + eventItem.Summary + "</p>";
                        htmldata += "</span>";
                        htmldata += "<p class=\"trunctext\">Date: " + when + "</p>";
                        htmldata += "</span>";
                        htmldata += "<p class=\"trunctext\">Description: " + eventItem.Description + "</p>";
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

                        findata.insertevent(Convert.ToDateTime(when), summary, loc, id, userID.ToString(), desc);

                        htmldata += "<a href=\"EventEdit?eid=" + id + "\">";
                        htmldata += "<div class=\"col s12 m2 l0 push-m1 push-l2\">";


                        htmldata += "<div class=\"card horizontal hoverable\">";
                       /* htmldata += "<div class=\"card-image\">";

                        htmldata += "<img style='width:200px;height:200px' class= \"responsive-img\" src = 'data:image/jpeg;base64," + UserData.Nopic + "'/>";


                        htmldata += "</div>";*/
                        htmldata += "<div class=\"card-stacked\">";
                        htmldata += "<div class=\"card-content black-text\">";
                        htmldata += "<span class=\"card-title\">" +
                            "<p class='bold'>" + eventItem.Summary + "</p>";
                        htmldata += "</span>";
                        htmldata += "<p class=\"trunctext\">Date: " + when + "</p>";
                        htmldata += "</span>";
                        htmldata += "<p class=\"trunctext\">Description: " + eventItem.Description + "</p>";
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



    }
}