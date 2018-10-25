using System;
using System.Web.UI;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;
using System.Globalization;
using System.Xml;

namespace Fincal
{
    public partial class Eventedit : System.Web.UI.Page
    {
        static string[] Scopes = { CalendarService.Scope.Calendar, CalendarService.Scope.CalendarEvents, CalendarService.Scope.CalendarEventsReadonly, CalendarService.Scope.CalendarReadonly };
        static string ApplicationName = "Google Calendar API .NET Quickstart";
        Dataservice.DatamanagementClient findata;
        string eID;
        string googleid;
        int success;
        CalendarService cs;
        DateTime dt;
        protected void Page_Load(object sender, EventArgs e)
        {

            UserData user = (UserData)(Session["User"]);

         
            






            eID = Request.QueryString.Get("eid");
            findata = new Dataservice.DatamanagementClient();


            findata.Open();

            object[] einfo = findata.getevent(eID,user.getID());

            //DateTime da = DateTime.ParseExact( , "YYYY/MM/DD HH:MM:SS", CultureInfo.InvariantCulture);
            //string info = (string)einfo[1];
           

            DateTime currentdatetime = DateTime.Parse((string)einfo[1]);

            txtdoe.Value = currentdatetime.ToString("yyyy/MM/dd");
            txttime.Value = currentdatetime.ToString("HH:mm");
            txteLocation.Value = (string)einfo[3];
            txtesummary.Value = (string)einfo[2];
            txtedesc.Value = (string)einfo[6];
            googleid = (string)einfo[4];

          /*  Object[] finds = findata.geteventpics(eID,user.getID());

            if (!(finds == null))
            {
                if (!((string)finds[0]).Equals(null))
                {
                    pic1Thumb.InnerHtml = "<img class='thumb' src='data:image/jpeg;base64," + (string)finds[0] + "'/>";
                }
                else
                {
                    pic1Thumb.InnerHtml = "<img class='thumb' src='data:image/jpeg;base64," + UserData.Nopic + "'/>";
                }
                if (!((string)finds[1]).Equals(null))
                {
                    pic2Thumb.InnerHtml = "<img class='thumb' src='data:image/jpeg;base64," + (string)finds[1] + "'/>";
                }
                else
                {
                    pic2Thumb.InnerHtml = "<img class='thumb' src='data:image/jpeg;base64," + UserData.Nopic + "'/>";
                }
                if (!((string)finds[2]).Equals(null))
                {
                    pic3Thumb.InnerHtml = "<img class='thumb' src='data:image/jpeg;base64," + (string)finds[2] + "'/>";
                }
                else
                {
                    pic3Thumb.InnerHtml = "<img class='thumb' src='data:image/jpeg;base64," + UserData.Nopic + "'/>";
                }

            }
            else
            {
                pic1Thumb.InnerHtml = "<img class='thumb' src='data:image/jpeg;base64," + UserData.Nopic + "'/>";
                pic2Thumb.InnerHtml = "<img class='thumb' src='data:image/jpeg;base64," + UserData.Nopic + "'/>";
                pic3Thumb.InnerHtml = "<img class='thumb' src='data:image/jpeg;base64," + UserData.Nopic + "'/>";

            }
            */

            findata.Close();
        }

        protected void btnUpdateevent_ServerClick(object sender, EventArgs e)
        {

        


            if (txtdoe.Value.Equals("") || txttime.Value.Equals("") || txtedesc.Value.Equals("") || txtesummary.Value.Equals("") || txteLocation.Value.Equals(""))
            {
                InvlaideventAd.InnerHtml = "<p>Please fill in all the fields</p>";
                
                return;
            }


         /*   if (pic1files.PostedFile.ContentLength == 0 && pic2files.PostedFile.ContentLength == 0 && pic3files.PostedFile.ContentLength == 0)
            {
                InvlaideventAd.InnerHtml = "<p>Please add at least one picture</p>";
                creeve = false;
                return;
            }
            */


            else
            {

                /*


                                //--------------------------------------------------------------------IMAGES

                                //create service
                                //var visionCredentails = CreateCredentials("C:\\Users\\James McGuire\\Desktop\\IMF third year project-46cd5c28569b.json");
                                //var visionService = CreateService("twoGames", visionCredentails);


                                //**************Check files exist********************
                             string base64String1 = "";
                                string base64String2 = "";
                                string base64String3 = "";


                                //----------------Check if there is PIC 1
                                if (pic1files.PostedFile.ContentLength != 0)
                                {
                                    base64String1 = ImageFunctions.validateImage(new BinaryReader(pic1files.PostedFile.InputStream).ReadBytes(pic1files.PostedFile.ContentLength));
                                    if (base64String1.Equals(" "))
                                    {
                                        InvlaideventAd.InnerHtml = "<p>Picture 1 is an invalid image. Please attach only the pictures you took of your game.</p>";
                                        return;
                                    }
                                }
                                else
                                    base64String1 = " ";


                                //Check if there is a file 2
                                if (pic2files.PostedFile.ContentLength != 0)
                                {
                                    base64String2 = ImageFunctions.validateImage(new BinaryReader(pic2files.PostedFile.InputStream).ReadBytes(pic2files.PostedFile.ContentLength));
                                    if (base64String2.Equals(" "))
                                    {
                                        InvlaideventAd.InnerHtml = "<p>Picture 2 is an invalid image. Please attach only the pictures you took of your game.</p>";
                                        return;
                                    }


                                }
                                else
                                    base64String2 = " ";


                                //Check if there is a file 3
                                if (pic3files.PostedFile.ContentLength != 0)
                                {
                                    base64String3 = ImageFunctions.validateImage(new BinaryReader(pic3files.PostedFile.InputStream).ReadBytes(pic3files.PostedFile.ContentLength));
                                    if (base64String3.Equals(" "))
                                    {
                                        InvlaideventAd.InnerHtml = "<p>Picture 3 is an invalid image. Please attach only the pictures you took of your game.</p>";
                                        return;
                                    }

                                }
                                else
                                    base64String3 = " ";



                                //byte[][] sendPics = new byte[3][];
                                // sendPics[0] = pic1Data;
                                // sendPics[1] = pic2Data;
                                //sendPics[2] = pic3Data;

                                //--------------------------------------------------------------------------

                                UserData user = (UserData)Session["User"];



                                //Inserting ad

                                success = 0;



                            */
                updateevent();
                changePage();


            }









        }

        protected void btnDeleteevent_ServerClick(object sender, EventArgs e)
        {
            UserCredential credential;
            using (var stream =
         new FileStream(Server.MapPath("client_secret.json"), FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal); ;
                credPath = Path.Combine(credPath, ".credentials/calendardelete-dotnet-quickstart.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets, Scopes, "user", CancellationToken.None, new FileDataStore(credPath, true)).Result;
                // Console.WriteLine("Credential file saved to: " + credPath);





            }

            // Create Google Tasks API service.
            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            service.Events.Delete("primary", eID).ExecuteAsync();
          
            changePagedelete();
            UserData user = (UserData)(Session["User"]);
            findata = new Dataservice.DatamanagementClient();
            findata.Open();
            findata.deleteevent(eID, user.getID());
            findata.Close();
        }

        private async void updateevent()
        {
            UserData user = (UserData)Session["User"];





            UserCredential credential;

            using (var stream =
                new FileStream(Server.MapPath("client_secret.json"), FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(
                   System.Environment.SpecialFolder.Personal); ;
                credPath = Path.Combine(credPath, ".credentials/calendarupdate-dotnet-quickstart.json");

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

            DateTime d = Convert.ToDateTime(txtdoe.Value);
            DateTime t = Convert.ToDateTime(txttime.Value);




            dt = new DateTime(d.Year, d.Month, d.Day, t.Hour, t.Minute, t.Second);
            Event old = service.Events.Get("primary", eID).Execute();

           
            old.Summary = txtesummary.Value;
            old.Location = txteLocation.Value;
            old.Description = txtedesc.Value;
            old.Start.DateTime =  DateTime.Parse(XmlConvert.ToString(dt, XmlDateTimeSerializationMode.Utc));
            old.Start.TimeZone = "Europe/Paris";
            old.End.DateTime = DateTime.Parse(XmlConvert.ToString(dt, XmlDateTimeSerializationMode.Utc));
            old.End.TimeZone = "Europe/Paris";
            
            Event newEvent = new Event()
            {
                Summary = txtesummary.Value,
                Location = txteLocation.Value,
                Description = txtedesc.Value,
                Start = new EventDateTime()
                {

                    DateTime = DateTime.Parse(XmlConvert.ToString(dt, XmlDateTimeSerializationMode.Utc)),//DateTime.pr dt.ToUniversalTime().ToString("YYYY-MM-DD'T'HH:mm:ssZ"),
                    TimeZone = "Europe/Paris",
                },
                End = new EventDateTime()
                {
                    DateTime = DateTime.Parse(XmlConvert.ToString(dt, XmlDateTimeSerializationMode.Utc)),
                    //   DateTime = DateTime.Parse(datetimepicker1.Value),
                    TimeZone = "Europe/Paris",
                },



            };

            String calendarId = "primary";
          
            EventsResource.UpdateRequest request = service.Events.Update(newEvent, calendarId, eID);
            Event newevent = await request.ExecuteAsync();

        }

        protected void changePage()
        {

            editeventDiv.InnerHtml = "<div class=\"col s12 m6 l4 push-l4 push-m3\">";

            editeventDiv.InnerHtml += "<div class=\"card white\">";
            editeventDiv.InnerHtml += "<div class=\"card-content Black-text\">";
            editeventDiv.InnerHtml += "<span class=\"card-title bold\">Event Edited Successful</span>";
            editeventDiv.InnerHtml += "<p>You have successfully Edited a Event</p>";
            editeventDiv.InnerHtml += "</div>";
            editeventDiv.InnerHtml += "<div class=\"card-action\">";

            editeventDiv.InnerHtml += "<a href=\"Default.aspx\" runat=\"server\" class=\"btn waves-effect waves-light\"><i class=\"material-icons left\">home</i>Home</a>";
            editeventDiv.InnerHtml += "<a href=\"Eventslist.aspx\" runat=\"server\" class=\"btn orange waves-effect waves-light\"><i class=\"material-icons left\">event</i>Events</a>";

            editeventDiv.InnerHtml += "</div>";
            editeventDiv.InnerHtml += "</div>";
            editeventDiv.InnerHtml += "</div>";
        }
        protected void changePagedelete()
        {

            editeventDiv.InnerHtml = "<div class=\"col s12 m6 l4 push-l4 push-m3\">";

            editeventDiv.InnerHtml += "<div class=\"card white\">";
            editeventDiv.InnerHtml += "<div class=\"card-content Black-text\">";
            editeventDiv.InnerHtml += "<span class=\"card-title bold\">Event Deleted Successful</span>";
            editeventDiv.InnerHtml += "<p>You have successfully added a Task</p>";
            editeventDiv.InnerHtml += "</div>";
            editeventDiv.InnerHtml += "<div class=\"card-action\">";
            editeventDiv.InnerHtml += "<a href=\"Default.aspx\" runat=\"server\" class=\"btn waves-effect waves-light\"><i class=\"material-icons left\">home</i>Home</a>";
            editeventDiv.InnerHtml += "<a href=\"Eventslist.aspx\" runat=\"server\" class=\"btn orange waves-effect waves-light\"><i class=\"material-icons left\">event</i>Events</a>";
            editeventDiv.InnerHtml += "</div>";
            editeventDiv.InnerHtml += "</div>";
            editeventDiv.InnerHtml += "</div>";
        }
    }
}