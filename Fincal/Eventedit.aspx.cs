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
namespace Fincal
{
    public partial class Eventedit : System.Web.UI.Page
    {
        static string[] Scopes = { CalendarService.Scope.Calendar, CalendarService.Scope.CalendarEvents };
        static string ApplicationName = "Google Calendar API .NET Quickstart";
        Dataservice.DatamanagementClient findata;
        string eID;
        string googleid;
        int success;
        CalendarService cs;
        TimeZone tz;
        TimeSpan ts;
        protected void Page_Load(object sender, EventArgs e)
        {

            UserData user = (UserData)(Session["User"]);

            tz = TimeZone.CurrentTimeZone;
            ts = tz.GetUtcOffset(DateTime.Now);

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

            cs = service;


            if (success == 0)
            {
                calins(cs);
            }






            eID = Request.QueryString.Get("eid");
            findata = new Dataservice.DatamanagementClient();


            findata.Open();

            object[] einfo = findata.getevent(eID,user.getID());

            //DateTime da = DateTime.ParseExact( , "YYYY/MM/DD HH:MM:SS", CultureInfo.InvariantCulture);
            //string info = (string)einfo[1];
            DateTime.Parse(einfo[1].ToString());
            txtdoe.Value = (string)einfo[1];
            txteLocation.Value = (string)einfo[3];
            txtesummary.Value = (string)einfo[2];
            txtedesc.Value = (string)einfo[6];
            googleid = (string)einfo[4];

            Object[] finds = findata.geteventpics(eID,user.getID());

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


            findata.Close();
        }

        protected void btnUpdateevent_ServerClick(object sender, EventArgs e)

        {

            Boolean creeve = true;
            //string adultResponse = "NOINFO";
            //string spoofResponse = "NOINFO";


            if (txtdoe.Value.Equals("") || txtedesc.Value.Equals("") || txtesummary.Value.Equals("") || txteLocation.Value.Equals(""))
            {
                InvlaideventAd.InnerHtml = "<p>Please fill in all the fields</p>";
                creeve = false;
                return;
            }


            if (pic1files.PostedFile.ContentLength == 0 && pic2files.PostedFile.ContentLength == 0 && pic3files.PostedFile.ContentLength == 0)
            {
                InvlaideventAd.InnerHtml = "<p>Please add at least one picture</p>";
                creeve = false;
                return;
            }



            if (creeve)
            {




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

                    /*
                    //convert pic 2 to byte[]
                    byte[] pic2Data = null;
                    using (var binaryReader = new BinaryReader(pic2files.PostedFile.InputStream))
                    {
                        pic2Data = binaryReader.ReadBytes(pic2files.PostedFile.ContentLength);
                        byte[] temp = pic2Data;

                        if (IsValidImage(pic2Data) && checkVision(pic2Data))
                        {
                            pic2Data = CompressImage(temp);
                            base64String2 = Convert.ToBase64String(pic2Data);
                        }
                        else
                        {
                            InvlaidPostAd.InnerHtml = "<p>Picture 2 is invalid</p>";
                            return;
                        }
                    }*/
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





            }









        }

        protected void btnDeleteevent_ServerClick(object sender, EventArgs e)
        {
            UserData user = (UserData)(Session["User"]);
            findata.Open();
            findata.deleteevent(eID, user.getID());

        }

        private void calins(CalendarService service)
        {
            /*Event newEvent = new Event()
            {
                //  Summary = DateTime.Parse( txtDoB.Value),
                Location = txteLocation.Value,
                Description = txtedesc.Value,
                Start = new EventDateTime()
                {
                    DateTime = DateTime.Parse(txtDoB.Value),
                    TimeZone = Convert.ToString(tz),
                },
                End = new EventDateTime()
                {
                    DateTime = DateTime.Parse(txtDoB.Value),
                    TimeZone = Convert.ToString(tz),
                },



            };



                  String calendarId = "primary";
                  EventsResource.InsertRequest request = service.Events.Insert(newEvent, calendarId);
                  Event createdEvent = request.Execute();*/

        }

    }
}