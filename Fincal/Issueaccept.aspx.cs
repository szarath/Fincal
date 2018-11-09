using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Tasks.v1;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fincal
{
    public partial class Issueaccept : System.Web.UI.Page
    {
        string pid;
        string issnid;
        object[] issdetails;
        object[] pldetails;
        object[] projdetails;
        object[] issndetails;
        static string[] Scopes = { TasksService.Scope.Tasks, TasksService.Scope.TasksReadonly };
        static string ApplicationName = "Google Tasks API .NET Quickstart";
        private Google.Apis.Tasks.v1.Data.Task newtask;
        
        string projname;
        string htmldata;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                UserData user = (UserData)Session["User"];
                Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
               
                pid = Request.QueryString.Get("id");
                issnid = Request.QueryString.Get("in");
               
                    String[] test;

                    findata.Open();
                    issdetails = findata.getissuedetails(pid);
                    issndetails = findata.getissuenoticedetails(issnid);
                    if (issdetails != null)
                    {
                        projdetails = findata.getprojectdetails((string)issdetails[3]);
                        txtprojectname.Value = (string)projdetails[1];
                        txtisst.Value = (string)issdetails[1];
                        txtissd.Value = (string)issdetails[2];
                        txtisspriority.Value = (string)issdetails[4];
                        pldetails = findata.getprojectleaderinformaion((string)issdetails[5]);
                        txtexp.Value = DateTime.Parse((string)issndetails[3]).AddDays(7).ToString();
                  

                    }

                    object[][] issmembers = findata.issueteam(pid);

                    if (issmembers != null)
                    {
                        for (int i = 0; i < issmembers.Length; i++)
                        {
                            Object[][] userevents = findata.getalluserevents((string)issmembers[i][0]);
                            int eventcount = 0;
                            if (userevents != null)
                            {


                                for (int j = 0; j < userevents.Length; j++)
                                {
                                    DateTime credate = DateTime.Parse((string)userevents[j][1]);
                                  


                                    int result = DateTime.Compare(credate, DateTime.Now.AddDays(14));

                                    if (result < 0)
                                    {
                                        eventcount += 1;
                                    }


                                }


                            }

                            htmldata += "<li class=\"collection-item\"><span style=\"font-weight:bold\">\"Schedule: " + priority(eventcount).ToString()    +"       Username: " + (string)issmembers[i][1] + "      Email: " + (string)issmembers[i][2] +  "</span></li>";

                        }
                       
                    }

                    else {
                    htmldata += "<li class=\"collection-item\"><span style=\"font-weight:bold\">No memebrs yet</span></li>";
                }
                membersonissue.InnerHtml += htmldata;
                    findata.Close();

                
               
            }
        
        }
        private string priority(int num)
        {
            if (num <= 15)
            {
                return ("Free");
            }
            else if (num <= 30)
            {

                return ("Occupied");

            }
            else
            {
                return ("Busy");

            }


        }
        protected void btnacceptproject_ServerClick(object sender, EventArgs e)
        {
            UserData user = (UserData)Session["User"];
            Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();

            findata.Open();

            int result = findata.addissteam(user.getID(), pid);

            if (result == 1)
            {
                int delete = findata.deleteissuenotification(pid, user.getID());

                if (delete == 1)
                {
                    changeaccPage();
                    inserttask();
                }
                else
                {
                    changeerrorPage();
                }
            }
            findata.Close();


          





        }
       private async void inserttask()
        {
         

            UserCredential credential;

         
            using (var stream =
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
            }

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

            Google.Apis.Tasks.v1.Data.Task task = new Google.Apis.Tasks.v1.Data.Task { Title ="Issue:   " +  (string)issdetails[1]+ "      Project:   " + (string)projdetails[1]  };

            newtask = await service.Tasks.Insert(task, "@default").ExecuteAsync();
          
            Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
                 UserData user = (UserData)Session["User"];
            findata.Open();
             
                findata.inserttask(newtask.Title, "0",(string)issdetails[4].ToString(), newtask.Id, user.getID());
                findata.Close();
           
         
      


        }

        protected void btncancelprojnotification_Click(object sender, EventArgs e)
        {
            UserData user = (UserData)Session["User"];
            Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
            findata.Open();
            int result = findata.deleteporjnotificaiton(pid, user.getID());


            if (result == 1)
            {
                changecancelPage();

            }
            else
            {

                changeerrorPage();
            }
            findata.Close();

        }

        protected void changeaccPage()
        {

            projacc.InnerHtml = "<div class=\"col s12 m6 l4 push-l4 push-m3\">";

            projacc.InnerHtml += "<div class=\"card white\">";
            projacc.InnerHtml += "<div class=\"card-content Black-text\">";
            projacc.InnerHtml += "<span class=\"card-title bold\">Issue Accepted</span>";
            projacc.InnerHtml += "<p>Issue has been Accepted and added to your other issues</p>";
            projacc.InnerHtml += "</div>";
            projacc.InnerHtml += "<div class=\"card-action\">";
            projacc.InnerHtml += "<a href=\"Default.aspx\" runat=\"server\" class=\"btn waves-effect waves-light\"><i class=\"material-icons left\">home</i>Home</a>";
            projacc.InnerHtml += "<a href=\"Projects.aspx\" runat=\"server\" class=\"btn orange waves-effect waves-light\"><i class=\"material-icons left\">assignment</i>Projects</a>";
            projacc.InnerHtml += "<a href=\"Issues.aspx\" runat=\"server\" class=\"btn blue waves-effect waves-light\"><i class=\"material-icons left\">notification_important</i>Issues</a>"; 
            projacc.InnerHtml += "</div>";
            projacc.InnerHtml += "</div>";
            projacc.InnerHtml += "</div>";
        }


        protected void changeerrorPage()
        {

            projacc.InnerHtml = "<div class=\"col s12 m6 l4 push-l4 push-m3\">";

            projacc.InnerHtml += "<div class=\"card white\">";
            projacc.InnerHtml += "<div class=\"card-content Black-text\">";
            projacc.InnerHtml += "<span class=\"card-title bold\">Error</span>";
            projacc.InnerHtml += "<p>Something went wronge</p>";
            projacc.InnerHtml += "</div>";
            projacc.InnerHtml += "<div class=\"card-action\">";
            projacc.InnerHtml += "<a href=\"Default.aspx\" runat=\"server\" class=\"btn waves-effect waves-light\"><i class=\"material-icons left\">home</i>Home</a>";
            projacc.InnerHtml += "<a href=\"Projects.aspx\" runat=\"server\" class=\"btn orange waves-effect waves-light\"><i class=\"material-icons left\">assignment</i>Projects</a>";
            projacc.InnerHtml += "<a href=\"Issues.aspx\" runat=\"server\" class=\"btn blue waves-effect waves-light\"><i class=\"material-icons left\">notification_important</i>Issues</a>";
            projacc.InnerHtml += "</div>";
            projacc.InnerHtml += "</div>";
            projacc.InnerHtml += "</div>";
        }

        protected void changecancelPage()
        {

            projacc.InnerHtml = "<div class=\"col s12 m6 l4 push-l4 push-m3\">";
            projacc.InnerHtml += "<div class=\"card white\">";
            projacc.InnerHtml += "<div class=\"card-content Black-text\">";
            projacc.InnerHtml += "<span class=\"card-title bold\">Issue Rejected</span>";
            projacc.InnerHtml += "<p>Issue was rejected by you</p>";
            projacc.InnerHtml += "</div>";
            projacc.InnerHtml += "<div class=\"card-action\">";
            projacc.InnerHtml += "<a href=\"Default.aspx\" runat=\"server\" class=\"btn waves-effect waves-light\"><i class=\"material-icons left\">home</i>Home</a>";
            projacc.InnerHtml += "<a href=\"Projects.aspx\" runat=\"server\" class=\"btn orange waves-effect waves-light\"><i class=\"material-icons left\">assignment</i>Projects</a>";
            projacc.InnerHtml += "<a href=\"Issues.aspx\" runat=\"server\" class=\"btn blue waves-effect waves-light\"><i class=\"material-icons left\">notification_important</i>Issues</a>";
            projacc.InnerHtml += "</div>";
            projacc.InnerHtml += "</div>";
            projacc.InnerHtml += "</div>";
        }
    }
}