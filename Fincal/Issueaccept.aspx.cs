using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fincal
{
    public partial class Issueaccept : System.Web.UI.Page
    {
        string pid;
        object[] issdetails;
        object[] pldetails;
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
                findata.Open();
                pid = Request.QueryString.Get("id");

                if (!IsPostBack)
                {
                    issdetails = findata.getissuedetails(pid);

                    if (issdetails != null)
                    {
                        object[] projdetails = findata.getprojectdetails((string)issdetails[3]);
                        txtprojectname.Value = (string)issdetails[1];
                        txtprojt.Value = (string)issdetails[1];
                    txtprojd.Value = (string)issdetails[2];
                       
                    pldetails = findata.getprojectleaderinformaion((string)issdetails[5]);

                    txtptojectleaderuname.Value = (string)pldetails[0];

                    txtptojectleaderemail.Value = (string)pldetails[1];

                    }


                }
                findata.Close();
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
                }
                else
                {
                    changeerrorPage();
                }
            }
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