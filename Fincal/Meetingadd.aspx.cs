using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;


namespace Fincal
{

    public partial class Meetingadd : System.Web.UI.Page
    {
        static string[] Scopes = { CalendarService.Scope.Calendar, CalendarService.Scope.CalendarEvents, CalendarService.Scope.CalendarEventsReadonly, CalendarService.Scope.CalendarReadonly };
        static string ApplicationName = "Google Calendar API .NET Quickstart";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                
                    Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
                    findata.Open();
                    UserData user = (UserData)Session["User"];
                    if (!IsPostBack)
                     { 
                    Object[][] userprojects = findata.getprojects(user.getID());

                    if (userprojects != null)
                    {
                             for (int i = 0; i < userprojects.Length; i++)
                             {


                            Projchoose.Items.Add(new ListItem(" " + (string)userprojects[i][1], userprojects[i][0].ToString()));


                        }




                    }
                    else {
                        addmembers();
                    }
                     }


                findata.Close();

              

            }
            else
            {
                Response.Redirect("Login.aspx");
            }







        }

        protected void btnmeetadd_ServerClick(object sender, EventArgs e)
        {
            if (txtmeettitle.Value.Equals("") || txtmeetd.Value.Equals(""))
            {
                Invlaidproject.InnerHtml = "*Please fill in all the details</br>";

            }

            else if (Projchoose.Items[Projchoose.SelectedIndex].Text.Equals(""))
            {

                Invlaidproject.InnerHtml = "*Please choose a project</br>";


            }
            else
            {


                DateTime d = Convert.ToDateTime(txtdom.Value);
                DateTime t = Convert.ToDateTime(txttime.Value);




                DateTime dt = new DateTime(d.Year, d.Month, d.Day, t.Hour, t.Minute, t.Second);

                Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
                findata.Open();
                UserData user = (UserData)Session["User"];
                int result = findata.insertmeeting(txtmeettitle.Value.ToString(), txtmeetd.Value.ToString(),dt.ToString(), Projchoose.Items[Projchoose.SelectedIndex].Value.ToString(), user.getID());
                if (result == 1)
                {
                    insertevent();
                }


                findata.Close();

            }



        }

        protected void addmembers()
        {

            projectdiv.InnerHtml = "<div class=\"col s12 m6 l4 push-l4 push-m3\">";

            projectdiv.InnerHtml += "<div class=\"card white\">";
            projectdiv.InnerHtml += "<div class=\"card-content Black-text\">";
            projectdiv.InnerHtml += "<span class=\"card-title bold\">Please add projects</span>";
            projectdiv.InnerHtml += "<p>To set up meetings please add projects and invite members </p>";
            projectdiv.InnerHtml += "</div>";
            projectdiv.InnerHtml += "<div class=\"card-action\">";

            projectdiv.InnerHtml += "<a href=\"Default.aspx\" runat=\"server\" class=\"btn waves-effect waves-light\"><i class=\"material-icons left\">home</i>Home</a>";
            projectdiv.InnerHtml += "<a href=\"Projects.aspx\" runat=\"server\" class=\"btn orange waves-effect waves-light\"><i class=\"material-icons left\">assignment</i>Projects</a>";

            projectdiv.InnerHtml += "</div>";
            projectdiv.InnerHtml += "</div>";
            projectdiv.InnerHtml += "</div>";
        }

        private async void insertevent()
        {
            UserData user = (UserData)Session["User"];






            UserCredential credential;

            using (var stream =
                new FileStream(Server.MapPath("client_secret.json"), FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(
                   System.Environment.SpecialFolder.Personal); ;
                credPath = Path.Combine(credPath, ".credentials/calendarinsert-dotnet-quickstart.json");

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

            CalendarService cs = service;



            DateTime d = Convert.ToDateTime(txtdom.Value);
            DateTime t = Convert.ToDateTime(txttime.Value);




           DateTime dt = new DateTime(d.Year, d.Month, d.Day, t.Hour, t.Minute, t.Second);






            Event newEvent = new Event()
            {
                Summary = "Project: " + Projchoose.Items[Projchoose.SelectedIndex].Text.ToString(),
                Location = "On Fincal",
                Description = txtmeetd.Value.ToString(),
                Start = new EventDateTime()
                {

                    DateTime = DateTime.Parse(XmlConvert.ToString(dt, XmlDateTimeSerializationMode.Utc)),//DateTime.pr dt.ToUniversalTime().ToString("YYYY-MM-DD'T'HH:mm:ssZ"),
                    TimeZone = "Europe/Paris",
                },
                End = new EventDateTime()
                {
                    DateTime = DateTime.Parse(XmlConvert.ToString(dt, XmlDateTimeSerializationMode.Utc)),

                    TimeZone = "Europe/Paris",
                },



            };



            String calendarId = "primary";

            EventsResource.InsertRequest request = service.Events.Insert(newEvent, calendarId);
            Event newevent = await request.ExecuteAsync();


        }
    }
}