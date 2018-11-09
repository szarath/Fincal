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

            if (user != null)
            {

                if (!IsPostBack)
                {
                    Leveldrop.Items.Add(new ListItem("1", "1"));
                    Leveldrop.Items.Add(new ListItem("2", "2"));
                    Leveldrop.Items.Add(new ListItem("3", "3"));
             

                Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
                findata.Open();
                storetask = findata.gettask(taskid, user.getID());


                txttaskanme.Value = (string)storetask[1];

                Leveldrop.Items.FindByText((string)storetask[4]).Selected = true;

                if (Convert.ToBoolean(storetask[2]))
                {
                    Completedcheck.Checked = true;




                }
                else
                {

                    Completedcheck.Checked = false;

                }

                    findata.Close();
                }
            }
            else {
                Response.Redirect("Login.aspx");
            }

            
            

        }

        protected  void btntaskupdateServerClick(object sender, EventArgs e)
        {
            if (txttaskanme.Value == "" || Leveldrop.Items[Leveldrop.SelectedIndex].Text.Equals("Choose Level"))
            {

                Invlaidtask.InnerHtml += "<p>Please fill in all the feilds</p>";

            }
            else
            {
               taskedit();
                changePage();
            }
                
         //   Response.Redirect("Task.aspx");
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
            changePagedelete();

        }

        private async void taskedit()
        {
           

           
              
            using (var stream =
           new FileStream(Server.MapPath("client_secret.json"), FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(  System.Environment.SpecialFolder.Personal); ;
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


        
             if (Completedcheck.Checked == false)
            {

                task.Status = "needsAction";
                task.CompletedRaw = null;
                task.Completed = null;
                completed = 0;

            }
            else if (Completedcheck.Checked == true)
            {

                task.Status = "completed";
                completed = 1;

            }
            task.Title = txttaskanme.Value;
            Google.Apis.Tasks.v1.Data.Task result = await service.Tasks.Update(task, "@default", taskid).ExecuteAsync();
            UserData user = (UserData)Session["User"];
            Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
            findata.Open();

            object[] taskdetails = findata.gettask(taskid, user.getID());
           
            int getnum = findata.updatetask(txttaskanme.Value.ToString(), completed.ToString(), user.getID(), Leveldrop.Items[Leveldrop.SelectedIndex].Text.ToString(), result.Id.ToString(),(string)taskdetails[0]);

            findata.Close();
 
        }

        protected void changePage()
        {

            taskDiv.InnerHtml = "<div class=\"col s12 m6 l4 push-l4 push-m3\">";

            taskDiv.InnerHtml += "<div class=\"card white\">";
            taskDiv.InnerHtml += "<div class=\"card-content Black-text\">";
            taskDiv.InnerHtml += "<span class=\"card-title bold\">Task Edited Successful</span>";
            taskDiv.InnerHtml += "<p>You have successfully added a Task</p>";
            taskDiv.InnerHtml += "</div>";
            taskDiv.InnerHtml += "<div class=\"card-action\">";
            taskDiv.InnerHtml += "<a href=\"Default.aspx\" runat=\"server\" class=\"btn waves-effect waves-light\"><i class=\"material-icons left\">home</i>Home</a>";
            taskDiv.InnerHtml += "<a href=\"Task.aspx\" runat=\"server\" class=\"btn orange waves-effect waves-light\"><i class=\"material-icons left\">mode_edit</i>Tasks</a>";
            taskDiv.InnerHtml += "</div>";
            taskDiv.InnerHtml += "</div>";
            taskDiv.InnerHtml += "</div>";
        }

        protected void changePagedelete()
        {

            taskDiv.InnerHtml = "<div class=\"col s12 m6 l4 push-l4 push-m3\">";

            taskDiv.InnerHtml += "<div class=\"card white\">";
            taskDiv.InnerHtml += "<div class=\"card-content Black-text\">";
            taskDiv.InnerHtml += "<span class=\"card-title bold\">Task Deleted Successful</span>";
            taskDiv.InnerHtml += "<p>You have successfully added a Task</p>";
            taskDiv.InnerHtml += "</div>";
            taskDiv.InnerHtml += "<div class=\"card-action\">";
            taskDiv.InnerHtml += "<a href=\"Default.aspx\" runat=\"server\" class=\"btn waves-effect waves-light\"><i class=\"material-icons left\">home</i>Home</a>";
            taskDiv.InnerHtml += "<a href=\"Task.aspx\" runat=\"server\" class=\"btn orange waves-effect waves-light\"><i class=\"material-icons left\">mode_edit</i>Tasks</a>";
            taskDiv.InnerHtml += "</div>";
            taskDiv.InnerHtml += "</div>";
            taskDiv.InnerHtml += "</div>";
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