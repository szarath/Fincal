using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fincal
{
    public partial class Projects : System.Web.UI.Page
    {

        private string htmldata1;
        private string htmldata2;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Title = "Fincal: Projects";

                UserData user = (UserData)Session["User"];
                Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
                findata.Open();

                Object[][] projects = findata.getprojects(user.getID());


                if (projects != null)
                {
                    for (int i = 0; i < projects.Length; i++)
                    {
                        htmldata1 += "<a href=\"Projectedit.aspx?id=" + (string)projects[i][0] + "\">";
                        htmldata1 += "<div class=\"col s12 m3 l0\">";


                        htmldata1 += "<div class=\"card horizontal hoverable\">";
                        /* htmldata += "<div class=\"card-image\">";

                         htmldata += "<img style='width:200px;height:200px' class= \"responsive-img\" src = 'data:image/jpeg;base64," + UserData.Nopic + "'/>";


                         htmldata += "</div>";*/
                        htmldata1 += "<div class=\"card-stacked\">";
                        htmldata1 += "<div class=\"card-content black-text\">";
                        htmldata1 += "<span class=\"card-title\">" +
                        "<p class=\"bold\">" + (string)projects[i][1] + "</p>";




                        htmldata1 += "</div>";
                        htmldata1 += "</div>";
                        htmldata1 += "</div>";
                        htmldata1 += "</div>";
                        htmldata1 += "</a>";




                    }


                }

                else
                {

                    htmldata1 += "";

                }


                object[] assignedprojectsids = findata.getassignedprojects(user.getID());


                if (assignedprojectsids != null)
                {
                    for (int i = 0; i < assignedprojectsids.Length; i++)
                    {
                        object[] assigproj = findata.getprojectdetails((string)assignedprojectsids[i]);
                        htmldata2 += "<a href=\"Projectview.aspx?id=" + assigproj[0].ToString() + "\">";
                        htmldata2 += "<div class=\"col s12 m3 l0\">";


                        htmldata2 += "<div class=\"card horizontal hoverable\">";
                        /* htmldata += "<div class=\"card-image\">";

                         htmldata += "<img style='width:200px;height:200px' class= \"responsive-img\" src = 'data:image/jpeg;base64," + UserData.Nopic + "'/>";


                         htmldata += "</div>";*/
                        htmldata2 += "<div class=\"card-stacked\">";
                        htmldata2 += "<div class=\"card-content black-text\">";
                        htmldata2 += "<span class=\"card-title\">" +
                        "<p class=\" bold\">" + assigproj[1].ToString() + "</p>";




                        htmldata2 += "</div>";
                        htmldata2 += "</div>";
                        htmldata2 += "</div>";
                        htmldata2 += "</div>";
                        htmldata2 += "</a>";




                    }




                }
                else {
                    htmldata2 += "";
                }

                yourprojects.InnerHtml = htmldata1;
                otherprojects.InnerHtml = htmldata2;

                findata.Close();
            }
        }
    }
}