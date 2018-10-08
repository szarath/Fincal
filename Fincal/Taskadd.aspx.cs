using Google.Apis.Auth.OAuth2;
using Google.Apis.Tasks.v1;
using Google.Apis.Tasks.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Web.UI.WebControls;
namespace Fincal
{
    public partial class Taskadd : System.Web.UI.Page
    {
        static string[] Scopes = { TasksService.Scope.Tasks };
        static string ApplicationName = "Google Tasks API .NET Quickstart";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PlatformDrop.Items.Add(new ListItem("1", "1"));
                PlatformDrop.Items.Add(new ListItem("2", "2"));
                PlatformDrop.Items.Add(new ListItem("3", "3"));
            }
        }
        protected void btntaskadd_ServerClick(object sender, EventArgs e)
        {
            UserData currentUser = (UserData)(Session["User"]);
            UserCredential credential;

            /*using (var stream =
                new FileStream(Server.MapPath("client_secret.json"), FileMode.Open, FileAccess.Read))
            {
                string credPath = Server.MapPath("/token.json");
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }*/

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

            if (txttaskanme.Value == "" || PlatformDrop.Items[PlatformDrop.SelectedIndex].Text.Equals("Level"))
            {

                Invlaidtask.InnerHtml += "<p>Please fill in all the feilds</p>";

            }
            else
            {
                Google.Apis.Tasks.v1.Data.Task task = new Google.Apis.Tasks.v1.Data.Task { Title = txttaskanme.Value };

                Google.Apis.Tasks.v1.Data.Task result = service.Tasks.Insert(task, "@default").Execute();


               Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();

                findata.Open();

                findata.inserttask(txttaskanme.Value, 0, PlatformDrop.Items[PlatformDrop.SelectedIndex].Text, result.Id, currentUser.getID().ToString());

                findata.Close();

            }








        }
    }
}