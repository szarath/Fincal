using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fincal
{
    public partial class Issues : System.Web.UI.Page
    {
        string htmldata1;
        string htmldata2;
        string htmldata3;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Title = "Fincal: Issues";

                UserData user = (UserData)Session["User"];
                Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
                findata.Open();

                Object[][] issue = findata.getissues(user.getID());


                if (issue != null)
                {
                    for (int i = 0; i < issue.Length; i++)
                    {
                        Object[] projectdetails = findata.getprojectdetails((string)issue[i][3]);
                        object[] issteam = findata.getissuemembers((string)issue[i][0]);
                        int issmem = 0;
                        if (issteam != null)
                        {
                            issmem = issteam.Length;
                        }

                        htmldata1 += "<a href=\"Issueedit.aspx?id=" + (string)issue[i][0] + "\">";
                        htmldata1 += "<div class=\"col s12 m3 l0\">";


                        htmldata1 += "<div class=\"card horizontal hoverable " + colorchoice(Convert.ToInt32((string)issue[i][4])) +"\">";
                        /* htmldata += "<div class=\"card-image\">";

                         htmldata += "<img style='width:200px;height:200px' class= \"responsive-img\" src = 'data:image/jpeg;base64," + UserData.Nopic + "'/>";


                         htmldata += "</div>";*/
                        htmldata1 += "<div class=\"card-stacked\">";
                        htmldata1 += "<div class=\"card-content black-text\">";
                        htmldata1 += "<span class=\"card-title\">" +
                        "<p class=\" bold\">" + (string)issue[i][1] + "</p>";
                        htmldata1 += "</span>";
                        htmldata1 += "<p class=\"trunctext\">Project: " + (string)projectdetails[1] + "</p>";
                        htmldata1 += "<p class=\"trunctext\">Issue members: " + issmem + "</p>";


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


                object[] assignedissueids = findata.getassignedissues(user.getID());


                if (assignedissueids != null)
                {
                    for (int i = 0; i < assignedissueids.Length; i++)
                    {
                      
                        object[] assigiss = findata.getissuedetails((string)assignedissueids[0]);
                        Object[] projectdetails = findata.getprojectdetails((string)assigiss[3]);
                        object[] issteam = findata.getissuemembers((string)assignedissueids[0]);
                        int issmem = 0;
                        if (issteam != null)
                        {
                            issmem = issteam.Length;
                        }
                        
                        htmldata2 += "<a href=\"Issueview.aspx?id=" + assigiss[0].ToString() + "\">";
                        htmldata2 += "<div class=\"col s12 m3 l0\">";


                        htmldata2 += "<div class=\"card horizontal hoverable " + colorchoice(Convert.ToInt32( (string)assigiss[4])) + "\">";
                        /* htmldata += "<div class=\"card-image\">";

                         htmldata += "<img style='width:200px;height:200px' class= \"responsive-img\" src = 'data:image/jpeg;base64," + UserData.Nopic + "'/>";


                         htmldata += "</div>";*/
                        htmldata2 += "<div class=\"card-stacked\">";
                        htmldata2 += "<div class=\"card-content black-text\">";
                        htmldata2 += "<span class=\"card-title\">" +
                        "<p class=\" bold\">" + assigiss[1].ToString() + "</p>";
                        htmldata2 += "</span>";
                        htmldata2 += "<p class=\"trunctext\">Project: " + (string)projectdetails[1] + "</p>";
                        htmldata2 += "<p class=\"trunctext\">Issue members: " + issmem + "</p>";



                        htmldata2 += "</div>";
                        htmldata2 += "</div>";
                        htmldata2 += "</div>";
                        htmldata2 += "</div>";
                        htmldata2 += "</a>";




                    }




                }
                else
                {
                    htmldata2 += "";
                }


                Object[][] userproj = findata.getprojects(user.getID());

                if (userproj != null)
                {
                    for (int i = 0; i < userproj.Length; i++)
                    {
                        object[][] issuedetails = findata.getissueflags((string)userproj[i][0]);

                        if (issuedetails != null)
                        {
                            object[] projdetails = findata.getprojectdetails((string)userproj[i][0]);


                            for (int j = 0; j < issuedetails.Length; j++)
                            {

                                htmldata3 += "<a href=\"Issueflagviewer.aspx?id=" + (string)issuedetails[j][0] + "\">";
                                htmldata3 += "<div class=\"col s12 m3 l0\">";


                                htmldata3 += "<div class=\"card horizontal hoverable\">";
                                /* htmldata += "<div class=\"card-image\">";

                                 htmldata += "<img style='width:200px;height:200px' class= \"responsive-img\" src = 'data:image/jpeg;base64," + UserData.Nopic + "'/>";


                                 htmldata += "</div>";*/
                                htmldata3 += "<div class=\"card-stacked\">";
                                htmldata3 += "<div class=\"card-content black-text\">";
                                htmldata3 += "<span class=\"card-title\">" +
                                "<p class=\" bold\">" + (string)issuedetails[j][3] + "</p>";
                                htmldata3 += "</span>";
                                htmldata3 += "<p class=\"trunctext\">Project: " + (string)projdetails[1] + "</p>";



                                htmldata3 += "</div>";
                                htmldata3 += "</div>";
                                htmldata3 += "</div>";
                                htmldata3 += "</div>";
                                htmldata3 += "</a>";


                            }


                          



                        }
                        else
                        {


                        }

                    }



                }

               

                

              


                yourprojects.InnerHtml = htmldata1;
                otherprojects.InnerHtml = htmldata2;
                flagged.InnerHtml = htmldata3;
                 findata.Close();

         
            }
        }

        private string colorchoice(int choice)
        {
            if (choice == 1)
            {
                return "green";
            }
            else if (choice == 2)
            {
                return "blue";
            }
            else if (choice == 3)
            {
                return "red";
            }


            return "Nochoice";

        }

    }
}