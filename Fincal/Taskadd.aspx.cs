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
        static string[] Scopes = { TasksService.Scope.Tasks, TasksService.Scope.TasksReadonly };
        static string ApplicationName = "Google Tasks API .NET Quickstart";
        private Google.Apis.Tasks.v1.Data.Task newtask;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { 
            PlatformDrop.Items.Add(new ListItem("1", "1"));
            PlatformDrop.Items.Add(new ListItem("2", "2"));
            PlatformDrop.Items.Add(new ListItem("3", "3"));
            }
        }
        protected void btntaskadd_ServerClick(object sender, EventArgs e)
        {
            UserData currentUser = (UserData)(Session["User"]);
          

            if (txttaskanme.Value == "" || PlatformDrop.Items[PlatformDrop.SelectedIndex].Text.Equals("Choose Level"))
            {

                Invlaidtask.InnerHtml += "<p>Please fill in all the feilds</p>";

            }
            else
            {
              inserttask();
              changePage();


         /*     Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();

                findata.Open();

                findata.inserttask(txttaskanme.Value, "0", PlatformDrop.Items[PlatformDrop.SelectedIndex].Text, newtask.Id, currentUser.getID().ToString());

                findata.Close();
                */
            }


          




            
        }

        private async void inserttask()
        {
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
                credPath = Path.Combine(credPath, ".credentials/tasksadd-dotnet-quickstart.json");

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

            Google.Apis.Tasks.v1.Data.Task task = new Google.Apis.Tasks.v1.Data.Task { Title = txttaskanme.Value };

            newtask = await service.Tasks.Insert(task, "@default").ExecuteAsync();
           


        }
        protected void changePage()
        {

            taskDiv.InnerHtml = "<div class=\"col s12 m6 l4 push-l4 push-m3\">";

            taskDiv.InnerHtml += "<div class=\"card white\">";
            taskDiv.InnerHtml += "<div class=\"card-content Black-text\">";
            taskDiv.InnerHtml += "<span class=\"card-title bold\">Task Added Successful</span>";
            taskDiv.InnerHtml += "<p>You have successfully added a Task</p>";
            taskDiv.InnerHtml += "</div>";
            taskDiv.InnerHtml += "<div class=\"card-action\">";


            taskDiv.InnerHtml += "<a href=\"Default.aspx\" runat=\"server\" class=\"btn waves-effect waves-light\"><i class=\"material-icons left\">home</i>Home</a>";
            taskDiv.InnerHtml += "<a href=\"Task.aspx\" runat=\"server\" class=\"btn orange waves-effect waves-light\"><i class=\"material-icons left\">mode_edit</i>Tasks</a>";
            taskDiv.InnerHtml += "<a href=\"Taskadd.aspx\" runat=\"server\" class=\"btn orange waves-effect waves-light\"><i class=\"material-icons left\">mode_edit</i>Tasks</a>";
            taskDiv.InnerHtml += "</div>";
            taskDiv.InnerHtml += "</div>";
            taskDiv.InnerHtml += "</div>";
        }
    }
}