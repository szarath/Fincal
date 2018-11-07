using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fincal
{
    public partial class Projectview : System.Web.UI.Page
    {
        string htmldata;
        string id;
        object[] project;
        object[] projectmembers;
        object[] pldetails;
        object[] projectmemdetails;
        string title;



        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Title = "Fincal: View Project ";

                id = Request.QueryString.Get("id");
                UserData user = (UserData)Session["User"];
               
                if (!IsPostBack)
                {
                    Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
                    findata.Open();
             
                    project = findata.getprojectdetails(id);
                    projectmembers = findata.getprojectmembers(id);

                    txtprojt.Value = (string)project[1];
                    txtprojd.Value = (string)project[2];

                    pldetails = findata.getprojectleaderinformaion((string)project[3]);

                    txtptojectleaderuname.Value = (string)pldetails[0];

                    txtptojectleaderemail.Value = (string)pldetails[1];

                    for (int i = 0; i < projectmembers.Length; i++)
                    {

                        projectmemdetails = findata.getspecificuserinformation((string)projectmembers[i]);

                        htmldata += "<li class=\"collection-item\"><span style=\"font-weight:bold\">Username: " + (string)projectmemdetails[0]+"   Email: "+ (string)projectmemdetails[1]+"   Skill: "+ (string)projectmemdetails[2]  + "</span></li>";


                    }
                    membersonproject.InnerHtml += htmldata;

              findata.Close();

                }
            }
        }

        protected void btnDeletefromteam_ServerClick(object sender, EventArgs e)
        {

            id = Request.QueryString.Get("id");
            UserData user = (UserData)Session["User"];
            Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
            findata.Open();

            int result = findata.deleteassiguserfromteam(user.getID(),id);

            if (result == 1)
            {
                changePage();



            }




            findata.Close();




        }

        protected void changePage()
        {

            projview.InnerHtml = "<div class=\"col s12 m6 l4 push-l4 push-m3\">";

            projview.InnerHtml += "<div class=\"card white\">";
            projview.InnerHtml += "<div class=\"card-content Black-text\">";
            projview.InnerHtml += "<span class=\"card-title bold\">Removal Successful</span>";
            projview.InnerHtml += "<p>You have successfully removed the project </p>";
            projview.InnerHtml += "</div>";
            projview.InnerHtml += "<div class=\"card-action\">";
            projview.InnerHtml += "<a href=\"Default.aspx\" runat=\"server\" class=\"btn waves-effect waves-light\"><i class=\"material-icons left\">home</i>Home</a>";
            projview.InnerHtml += "<a href=\"Projects.aspx\" runat=\"server\" class=\"btn orange waves-effect waves-light\"><i class=\"material-icons left\">assignment</i>Projects</a>";
            projview.InnerHtml += "</div>";
            projview.InnerHtml += "</div>";
            projview.InnerHtml += "</div>";
        }
    }
}