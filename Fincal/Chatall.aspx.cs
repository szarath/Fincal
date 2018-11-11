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
        Title = "Chats";
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
              

                UserData user = (UserData)Session["User"];
                Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
            
                findata.Open();
               
                Object[][] projects = findata.getprojects(user.getID());
                Object[][] otherprojects = findata.getassignedprojdetials(user.getID());
                Object[][] issue = findata.getissues(user.getID());
                Object[][] otherissues = findata.getassignedissdetials(user.getID());
                if (projects != null)
                {
                    for (int i = 0; i < projects.Length; i++)
                    {
                       
                        object[] projmembers = findata.getprojectmembers((string)projects[i][0]);
                        int nummem = 0;
                        if (projmembers != null)
                        {
                             nummem = projmembers.Length;
 

                        }

                        htmldata1 += "<a href=\"Chatspecificproj.aspx?id=" + (string)projects[i][0] + "\">";
                        htmldata1 += "<div class=\"col s12 m3 l0\">";


                        htmldata1 += "<div class=\"card horizontal hoverable blue-grey\">";
                        /* htmldata += "<div class=\"card-image\">";

                         htmldata += "<img style='width:200px;height:200px' class= \"responsive-img\" src = 'data:image/jpeg;base64," + UserData.Nopic + "'/>";


                         htmldata += "</div>";*/
                        htmldata1 += "<div class=\"card-stacked\">";
                        htmldata1 += "<div class=\"card-content black-text\">";
                        htmldata1 += "<span class=\"card-title\">" +
                        "<p class=\"bold\">" + (string)projects[i][1] + "</p>";
                        htmldata1 += "</span>";
                        htmldata1 += "<p class=\"bold\">Members: " + nummem + "</p>";

                        htmldata1 += "</span>";


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

                if (otherprojects != null)
                {

                    for (int i = 0; i < otherprojects.Length; i++)
                    {
                        object[] projmembers = findata.getprojectmembers((string)otherprojects[i][0]);
                        int nummem = 0;
                        if (projmembers != null)
                        {
                            nummem = projmembers.Length;


                        }
                        htmldata1 += "<a href=\"Chatspecificproj.aspx?id=" + (string)otherprojects[i][0] + "\">";
                        htmldata1 += "<div class=\"col s12 m3 l0\">";


                        htmldata1 += "<div class=\"card horizontal hoverable blue-grey lighten-5\">";
                      
                        htmldata1 += "<div class=\"card-stacked\">";
                        htmldata1 += "<div class=\"card-content black-text\">";
                        htmldata1 += "<span class=\"card-title\">" +
                        "<p class=\"bold\">" + (string)otherprojects[i][1] + "</p>";
                        htmldata1 += "</span>";
                        htmldata1 += "<p class=\"bold\">Members: " + nummem + "</p>";

                        htmldata1 += "</span>";


                        htmldata1 += "</div>";
                        htmldata1 += "</div>";
                        htmldata1 += "</div>";
                        htmldata1 += "</div>";
                        htmldata1 += "</a>";




                    }


                }
                else { htmldata1 += ""; }
                if (issue != null)
                {
                    for (int i = 0; i < issue.Length; i++)
                    {

                        Object[] projectdetails = findata.getprojectdetails((string)issue[i][3]);

                        object[] issmembers = findata.getissuemembers((string)issue[i][0]);
                        int nummem = 0;
                        if (issmembers != null)
                        {
                            nummem = issmembers.Length;


                        }
                        htmldata2 += "<a href=\"Chatspecificissue.aspx?id=" + (string)issue[i][0] + "\">";
                        htmldata2 += "<div class=\"col s12 m3 l0\">";


                        htmldata2 += "<div class=\"card horizontal hoverable green\">";
                        /* htmldata += "<div class=\"card-image\">";

                         htmldata += "<img style='width:200px;height:200px' class= \"responsive-img\" src = 'data:image/jpeg;base64," + UserData.Nopic + "'/>";


                         htmldata += "</div>";*/
                        htmldata2 += "<div class=\"card-stacked\">";
                        htmldata2 += "<div class=\"card-content black-text\">";
                        htmldata2 += "<span class=\"card-title\">" +
                        "<p class=\" bold\">" + (string)issue[i][1] + "</p>";
                        htmldata2 += "</span>";
                        htmldata2 += "<p class=\"trunctext\">Project: " + (string)projectdetails[1] + "</p>";
                        htmldata2 += "</span>";
                        htmldata2 += "<p class=\"bold\">Members: " + nummem + "</p>";
                      

                        htmldata2 += "</div>";
                        htmldata2 += "</div>";
                        htmldata2 += "</div>";
                        htmldata2 += "</div>";
                        htmldata2 += "</a>";



                    }

                }
                else { htmldata2 += ""; }

                if (otherissues != null)
                {
                    for (int i = 0; i < otherissues.Length; i++)
                    {

                        Object[] projectdetails = findata.getprojectdetails((string)otherissues[i][0]);
                        object[] issmembers = findata.getissuemembers((string)otherissues[i][0]);
                        int nummem = 0;
                        if (issmembers != null)
                        {
                            nummem = issmembers.Length;


                        }

                        htmldata2 += "<a href=\"Chatspecificissue.aspx?id=" + (string)otherissues[i][0] + "\">";
                        htmldata2 += "<div class=\"col s12 m3 l0\">";


                        htmldata2 += "<div class=\"card horizontal hoverable cyan lighten-3\">";
                        /* htmldata += "<div class=\"card-image\">";

                         htmldata += "<img style='width:200px;height:200px' class= \"responsive-img\" src = 'data:image/jpeg;base64," + UserData.Nopic + "'/>";


                         htmldata += "</div>";*/
                        htmldata2 += "<div class=\"card-stacked\">";
                        htmldata2 += "<div class=\"card-content black-text\">";
                        htmldata2 += "<span class=\"card-title\">" +
                        "<p class=\" bold\">" + (string)otherissues[i][1] + "</p>";
                        htmldata2 += "</span>";
                        htmldata2 += "<p class=\"trunctext\">Project: " + (string)projectdetails[1] + "</p>";
                        htmldata2 += "</span>";
                        htmldata2 += "<p class=\"bold\">Members: " + nummem + "</p>";

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