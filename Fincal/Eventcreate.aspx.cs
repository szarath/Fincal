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
    public partial class Eventcreate : System.Web.UI.Page
    {
        private UserData user;
        static string[] Scopes = { CalendarService.Scope.Calendar, CalendarService.Scope.CalendarEvents, CalendarService.Scope.CalendarEventsReadonly,CalendarService.Scope.CalendarReadonly };
        static string ApplicationName = "Google Calendar API .NET Quickstart";
      Dataservice.DatamanagementClient findata;
        string eID;
        string googleid;
        int success = 1;

        private DateTime dt;
        
        TimeZone tz;
        TimeSpan ts;
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }

        protected void btnCreateevent_ServerClick(object sender, EventArgs e)

        {
        //    findata = new Dataservice.DatamanagementClient();


          






            eID = Request.QueryString.Get("eid");


            user = (UserData)(Session["User"]);
           



            if (txtdoe.Value.Equals("") || txttime.Value.Equals("") || txtedesc.Value.Equals("") || txtesummary.Value.Equals("") || txteLocation.Value.Equals(""))
            {
                InvlaideventAd.InnerHtml = "<p>Please fill in all the fields</p>";
                
                
            }


            /*    if (pic1files.PostedFile.ContentLength == 0 && pic2files.PostedFile.ContentLength == 0 && pic3files.PostedFile.ContentLength == 0)
                {
                    InvlaideventAd.InnerHtml = "<p>Please add at least one picture</p>";
                    creeve = false;
                    return;
                }
                */

            
           


           else
            {




               
         /*** string base64String1 = "";
                 string base64String2 = "";
                 string base64String3 = "";



                 if (pic1files.PostedFile.ContentLength != 0)
                 {
                     base64String1 = ImageFunctions.validateImage(new BinaryReader(pic1files.PostedFile.InputStream).ReadBytes(pic1files.PostedFile.ContentLength));
                     if (base64String1.Equals(" "))
                     {
                         InvlaideventAd.InnerHtml = "<p>Picture 1 is an invalid image.</p>";
                         return;
                     }
                 }
                 else
                     base64String1 = " ";


                 if (pic2files.PostedFile.ContentLength != 0)
                 {
                     base64String2 = ImageFunctions.validateImage(new BinaryReader(pic2files.PostedFile.InputStream).ReadBytes(pic2files.PostedFile.ContentLength));
                     if (base64String2.Equals(" "))
                     {
                         InvlaideventAd.InnerHtml = "<p>Picture 2 is an invalid image. </p>";
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
                         InvlaideventAd.InnerHtml = "<p>Picture 3 is an invalid image</p>";
                         return;
                     }

                     /*
                     //convert pic 3 to byte[]
                     byte[] pic3Data = null;
                     using (var binaryReader = new BinaryReader(pic3files.PostedFile.InputStream))
                     {
                         pic3Data = binaryReader.ReadBytes(pic3files.PostedFile.ContentLength);
                         byte[] temp = pic3Data;

                         if (IsValidImage(pic3Data) && checkVision(pic3Data))
                         {
                             pic3Data = CompressImage(temp);
                             base64String3 = Convert.ToBase64String(pic3Data);
                         }
                         else
                         {
                             InvlaidPostAd.InnerHtml = "<p>Picture 3 is invalid</p>";
                             return;
                         }
                     }*/
                /*  }
                  else
                      base64String3 = " ";
              */


                //byte[][] sendPics = new byte[3][];
                // sendPics[0] = pic1Data;
                // sendPics[1] = pic2Data;
                //sendPics[2] = pic3Data;

                //--------------------------------------------------------------------------
                
                insertevent();
                changePage();
               





            }


         






        }

        private async void insertevent()
        {
            UserData user = (UserData)Session["User"];




            tz = TimeZone.CurrentTimeZone;
            ts = tz.GetUtcOffset(DateTime.Now);

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

            DateTime d = Convert.ToDateTime(txtdoe.Value);
            DateTime t = Convert.ToDateTime(txttime.Value);




            dt = new DateTime(d.Year, d.Month, d.Day, t.Hour, t.Minute, t.Second);


            Event newEvent = new Event()
            {
                Summary = txtesummary.Value,
                Location = txteLocation.Value,
                Description = txtedesc.Value,
                Start = new EventDateTime()
                {
                    
                    DateTime = DateTime.Parse( XmlConvert.ToString(dt, XmlDateTimeSerializationMode.Utc)),//DateTime.pr dt.ToUniversalTime().ToString("YYYY-MM-DD'T'HH:mm:ssZ"),
                    TimeZone = "Europe/Paris",
                },
                End = new EventDateTime()
                {
                    DateTime = DateTime.Parse(XmlConvert.ToString(dt, XmlDateTimeSerializationMode.Utc)),
                  
                    TimeZone ="Europe/Paris",
                },



            };



            String calendarId = "primary";
           
            EventsResource.InsertRequest request = service.Events.Insert(newEvent, calendarId);
          Event newevent =  await request.ExecuteAsync();
           
           
        }

        protected void changePage()
        {

            editAdDiv.InnerHtml = "<div class=\"col s12 m6 l4 push-l4 push-m3\">";

            editAdDiv.InnerHtml += "<div class=\"card white\">";
            editAdDiv.InnerHtml += "<div class=\"card-content Black-text\">";
            editAdDiv.InnerHtml += "<span class=\"card-title bold\">Event Successful Added</span>";
            editAdDiv.InnerHtml += "<p>You have successfully added a Event</p>";
            editAdDiv.InnerHtml += "</div>";
            editAdDiv.InnerHtml += "<div class=\"card-action\">";
 
            editAdDiv.InnerHtml += "<a href=\"Default.aspx\" runat=\"server\" class=\"btn waves-effect waves-light\">Home</a>";
            editAdDiv.InnerHtml += "<a href=\"Eventslist.aspx\" runat=\"server\" class=\"btn orange waves-effect waves-light\">Events</a>";

            editAdDiv.InnerHtml += "</div>";
            editAdDiv.InnerHtml += "</div>";
            editAdDiv.InnerHtml += "</div>";
        }
    }
}