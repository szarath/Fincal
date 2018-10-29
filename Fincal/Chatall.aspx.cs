using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fincal
{
    public partial class Chatall : System.Web.UI.Page
    {

        string htmldata1;
        string htmldata2;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Title = "Fincal: All Chats";

                UserData user = (UserData)Session["User"];
                Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
            
                findata.Open();
               
                Object[][] projects = findata.getprojects(user.getID());
                Object[][] issue = findata.getissues(user.getID());
                if (projects != null)
                {
                    for (int i = 0; i < projects.Length; i++)
                    {
                        htmldata1 += "<a href=\"Chatspecificproj.aspx?id=" + (string)projects[i][0] + "\">";
                        htmldata1 += "<div class=\"col s12 m3 l0\">";


                        htmldata1 += "<div class=\"card horizontal hoverable blue-grey darken-1\">";
                        /* htmldata += "<div class=\"card-image\">";

                         htmldata += "<img style='width:200px;height:200px' class= \"responsive-img\" src = 'data:image/jpeg;base64," + UserData.Nopic + "'/>";


                         htmldata += "</div>";*/
                        htmldata1 += "<div class=\"card-stacked\">";
                        htmldata1 += "<div class=\"card-content white-text\">";
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
                if (issue != null)
                {
                    for (int i = 0; i < issue.Length; i++)
                    {

                        Object[] projectdetails = findata.getprojectdetails((string)issue[i][3]);


                        htmldata2 += "<a href=\"Chatspecificissue.aspx?id=" + (string)issue[i][0] + "\">";
                        htmldata2 += "<div class=\"col s12 m3 l0\">";


                        htmldata2 += "<div class=\"card horizontal hoverable orange-grey darken-1\">";
                        /* htmldata += "<div class=\"card-image\">";

                         htmldata += "<img style='width:200px;height:200px' class= \"responsive-img\" src = 'data:image/jpeg;base64," + UserData.Nopic + "'/>";


                         htmldata += "</div>";*/
                        htmldata2 += "<div class=\"card-stacked\">";
                        htmldata2 += "<div class=\"card-content white-text\">";
                        htmldata2 += "<span class=\"card-title\">" +
                        "<p class=\" bold\">" + (string)issue[i][1] + "</p>";
                        htmldata2 += "</span>";
                        htmldata2 += "<p class=\"trunctext\">Project: " + (string)projectdetails[1] + "</p>";



                        htmldata2 += "</div>";
                        htmldata2 += "</div>";
                        htmldata2 += "</div>";
                        htmldata2 += "</div>";
                        htmldata2 += "</a>";



                    }

                }
                else { htmldata2 += ""; }

                Projects.InnerHtml += htmldata1;
                Issues.InnerHtml += htmldata2;
                findata.Close();
               
            }

            }
    }
}