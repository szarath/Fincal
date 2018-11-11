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
        


        static string[] Scopes = { CalendarService.Scope.CalendarReadonly };
        static string ApplicationName = "Google Calendar API .NET Quickstart";

        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Events";

            if (Session["User"] != null) //Logged in
              {

                Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
                findata.Open();
                UserData user = (UserData)Session["User"];
                Object[][] userevents = findata.getalluserevents(user.getID());

              

                    if (userevents != null)
                    {


                        for (int j = 0; j < userevents.Length; j++)
                        {
                            DateTime credate = DateTime.Parse((string)userevents[j][1]);
                         


                            int result = DateTime.Compare(credate, DateTime.Now);

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
            request.MaxResults = 1000;
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
                        loc = "";
                    }
                    Boolean exsisting = false;
                    object[] googleids = findata.geteventids(user.getID());

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
                        findata.deleteevent(eventItem.Id, user.getID());
                        findata.deleteeventpics(eventItem.Id, user.getID());
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
                            findata.updateevent(DateTime.Parse(when), eventItem.Summary, eventItem.Location, eventItem.Description,(string)storedevent[4], (string)storedevent[0]);


                        }

                        htmldata += "<a href=\"EventEdit.aspx?eid=" + eventItem.Id + "\">";
                        htmldata += "<div class=\"col s12 m4 l0\">";
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
                        htmldata += "<p class=\"bold \">Date/Time: " + when + "</p>";
        
                        htmldata += "</span>";
                        htmldata += "<p class=\"bold\">Location: " + eventItem.Location + "</p>";


                        htmldata += "</div>";
                        htmldata += "</div>";
                        htmldata += "</div>";
                        htmldata += "</div>";
                        htmldata += "</a>";

                    }
                    else
                    {

                        findata.insertevent(Convert.ToDateTime(when), summary, loc, id, user.getID(), desc);

                        htmldata += "<a href=\"EventEdit.aspx?eid=" + id + "\">";
                        htmldata += "<div class=\"col s12 m4 l0\">";


                        htmldata += "<div class=\"card horizontal hoverable deep-purple lighten-3\">";
                       /* htmldata += "<div class=\"card-image\">";

                        htmldata += "<img style='width:200px;height:200px' class= \"responsive-img\" src = 'data:image/jpeg;base64," + UserData.Nopic + "'/>";


                        htmldata += "</div>";*/
                        htmldata += "<div class=\"card-stacked\">";
                        htmldata += "<div class=\"card-content black-text\">";
                        htmldata += "<span class=\"card-title\">" +
                            "<p class=\" bold trunctext\">" + eventItem.Summary + "</p>";
                        htmldata += "</span>";
                        htmldata += "<p class=\"bold\">Date/Time: " + when + "</p>";
    
                        htmldata += "</span>";
                        htmldata += "<p class=\"bold trunctext\">Location: " + eventItem.Location + "</p>";



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
            }
             else
             {
                 Response.Redirect("Login.aspx");
             }




        }



    }
}