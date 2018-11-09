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

                    txtcredate.Value = (string)project[4];
                    if (projectmembers != null)
                    {
                        for (int i = 0; i < projectmembers.Length; i++)
                        {

                            projectmemdetails = findata.getspecificuserinformation((string)projectmembers[i]);
                            Object[][] userevents = findata.getalluserevents((string)projectmembers[i]);
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
                            htmldata += "<li class=\"collection-item\"><span style=\"font-weight:bold\">Schedule:    " + priority(eventcount) + "&nbsp&nbsp&nbsp              Username:    " + (string)projectmemdetails[0] + "&nbsp&nbsp&nbsp              Email:     " + (string)projectmemdetails[1] + "&nbsp&nbsp&nbsp              Skill:      " + (string)projectmemdetails[2] + "</span></li>";


                        }

                    }
                    else
                    {

                        htmldata += "<li class=\"collection-item\"><span style=\"font-weight:bold\">No memebrs yet</span></li>";

                    }

                    membersonproject.InnerHtml += htmldata;

              findata.Close();

                }
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