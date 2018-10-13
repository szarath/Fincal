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
    public partial class Taskedit : System.Web.UI.Page
    {
        object[] storetask;
        private string taskid;
        static string[] Scopes = { TasksService.Scope.Tasks, TasksService.Scope.TasksReadonly };
        static string ApplicationName = "Google Tasks API .NET Quickstart";

        int completed = 0;
        private UserCredential credential;


        protected void Page_Load(object sender, EventArgs e)
        {
            taskid = Request.QueryString.Get("id");
            UserData user = (UserData)Session["User"];
            Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
            findata.Open();
            storetask = findata.gettask(taskid,user.getID());


            txttaskanme.Value = (string)storetask[1];



            if (Convert.ToBoolean(storetask[2]))
            {
                Completedcheck.Checked = true;

              


            }
            else
            {

                Completedcheck.Checked = false;
                
            }
            

        }

        protected void btntaskupdateServerClick(object sender, EventArgs e)
        {
            UserData currentUser = (UserData)(Session["User"]);
        

          
            using (var stream =
           new FileStream(Server.MapPath("client_secret.json"), FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal); ;
                credPath = Path.Combine(credPath, ".credentials/tasksupdate-dotnet-quickstart.json");

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


            Google.Apis.Tasks.v1.Data.Task task = service.Tasks.Get("@default", taskid).Execute();


            if (Completedcheck.Checked == true)
            {
              
                task.Status = "completed";
                completed = 1;  



            }
            task.Title = txttaskanme.Value;
            Google.Apis.Tasks.v1.Data.Task result = service.Tasks.Update(task, "@default", taskid).Execute();

          /*  Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
            findata.Open();



            UserData user = (UserData)Session["User"];
            findata.updatetask(txttaskanme.Value, completed, user.getID(), PlatformDrop.Items[PlatformDrop.SelectedIndex].Text,taskid);

            findata.Close();
            */
        }

        protected void btnDeleteAd_ServerClick(object sender, EventArgs e)
        {

            using (var stream =
           new FileStream(Server.MapPath("client_secret.json"), FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal); ;
                credPath = Path.Combine(credPath, ".credentials/taskdelete-dotnet-quickstart.json");

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


            service.Tasks.Delete("@default", taskid).ExecuteAsync();


        }


        private string colorchoice(int choice)
        {
            if (choice == 1)
            { return "white"; }
            else if (choice == 2)
            { return "blue"; }
            else if (choice == 3)
            { return "red"; }


            return "Nochoice";

        }
    }
}