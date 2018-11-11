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
    public partial class Meetingaccept : System.Web.UI.Page
    {
        static string[] Scopes = { CalendarService.Scope.Calendar, CalendarService.Scope.CalendarEvents, CalendarService.Scope.CalendarEventsReadonly, CalendarService.Scope.CalendarReadonly };
        static string ApplicationName = "Google Calendar API .NET Quickstart";
        string meetid;
        string mlid;
        string htmldata;
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Meeting Invite";
            if (Session["User"] != null)
            {

                meetid = Request.QueryString.Get("id");
                mlid = Request.QueryString.Get("ml");
                Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
                findata.Open();
                object[] getmeetinginfo = findata.getmeetinginformation(meetid);
                object[] getmlinfo = findata.getmeetinglink(mlid);
                Object[][] getmeetingattendance = findata.getmeetingattendance(meetid);
                if (Boolean.Parse((string)getmlinfo[3]) == true)
                {
                    btnaccept.Visible = false;

                }

                if (getmeetinginfo != null)
                {
                    object[] gerporjectdetails = findata.getprojectdetails((string)getmeetinginfo[4]);
                    object[] getuserinformaion = findata.getspecificuserinformation((string)getmeetinginfo[5]);
                    txtprojname.Value = (string)gerporjectdetails[1];
                    txtptojectleaderuname.Value = (string)getuserinformaion[0];
                    txtptojectleaderemail.Value = (string)getuserinformaion[1];
                    txtmeett.Value = (string)getmeetinginfo[1];
                    txtmeetd.Value = (string)getmeetinginfo[2];
                    txtmeetdate.Value = (string)getmeetinginfo[3];

                    if (getmeetingattendance != null)
                    {
                        for (int i = 0; i < getmeetingattendance.Length; i++)
                        {
                            

                            htmldata += "<li class=\"collection-item\"><span style=\"font-weight:bold\">Username: " + (string)getmeetingattendance[i][0] + "&nbsp&nbsp&nbsp      Attending: " + (string)getmeetingattendance[i][1] + "</span></li>";

                        }

                    }

                    else
                    {
                        htmldata += "<li class=\"collection-item\"><span style=\"font-weight:bold\">No memebrs yet</span></li>";
                    }


                    membersattending.InnerHtml += htmldata;


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
            Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
            findata.Open();
            int result = findata.updatemeetinglink(mlid, "1");
            if (result == 1)
            {

                insertevent();

                changePage();

            }


            findata.Close();
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

           




            


            Event newEvent = new Event()
            {
                Summary = "Project: " + txtprojname.Value.ToString(),
                Location = "On Fincal",
                Description = txtmeetd.Value.ToString(),
                Start = new EventDateTime()
                {

                    DateTime = DateTime.Parse(XmlConvert.ToString(DateTime.Parse( txtmeetdate.Value.ToString()), XmlDateTimeSerializationMode.Utc)),//DateTime.pr dt.ToUniversalTime().ToString("YYYY-MM-DD'T'HH:mm:ssZ"),
                    TimeZone = "Europe/Paris",
                },
                End = new EventDateTime()
                {
                    DateTime = DateTime.Parse(XmlConvert.ToString(DateTime.Parse(txtmeetdate.Value.ToString()), XmlDateTimeSerializationMode.Utc)),

                    TimeZone = "Europe/Paris",
                },



            };



            String calendarId = "primary";

            EventsResource.InsertRequest request = service.Events.Insert(newEvent, calendarId);
            Event newevent = await request.ExecuteAsync();


        }


        protected void changePage()
        {

            projectdiv.InnerHtml = "<div class=\"col s12 m6 l4 push-l4 push-m3\">";

            projectdiv.InnerHtml += "<div class=\"card white\">";
            projectdiv.InnerHtml += "<div class=\"card-content Black-text\">";
            projectdiv.InnerHtml += "<span class=\"card-title bold\">Meeting added</span>";
            projectdiv.InnerHtml += "<p>You have successfully added the meeting to your calendar</p>";
            projectdiv.InnerHtml += "</div>";
            projectdiv.InnerHtml += "<div class=\"card-action\">";
            projectdiv.InnerHtml += "<a href=\"Default.aspx\" runat=\"server\" class=\"btn waves-effect waves-light\"><i class=\"material-icons\">home</i>Home</a>";
            projectdiv.InnerHtml += "<a href=\"Meeting.aspx\" runat=\"server\" class=\"btn waves-effect waves-light orange\"><i class=\"material-icons\">meeting_room</i>Meeting</a>";
            projectdiv.InnerHtml += "</div>";
            projectdiv.InnerHtml += "</div>";
            projectdiv.InnerHtml += "</div>";
        }
    }
}