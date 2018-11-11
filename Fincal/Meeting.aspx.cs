using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fincal
{
    public partial class Meeting : System.Web.UI.Page
    {
        Object[][] usermeetings;
        Object[][] userothermeetings;
        object[] projdetails;
        private string htmldata1;
        private string htmldata2;
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Meetings";

            if (Session["User"] != null)
            {
              
                    UserData user = (UserData)Session["User"];
                    Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();

                    findata.Open();
                    usermeetings = findata.getusermeetings(user.getID());

                   
                    if (usermeetings != null)
                    {
                        for (int i = 0; i < usermeetings.Length; i++)
                        {

                            DateTime meetdate = DateTime.Parse((string)usermeetings[i][3]);
                            int result = DateTime.Compare(meetdate, DateTime.Now);
                           projdetails = findata.getprojectdetails((string)usermeetings[i][4]);
                            if (result < 0)
                            {



                            }
                            else
                            {
                         
                            object[][] getattenginguser = findata.getallattendingmeeting((string)usermeetings[i][0]);
                            int mematt = 0;
                            if (getattenginguser != null)
                            {

                                mematt = getattenginguser.Length;
                            }

                            object[] getprojmembers = findata.getprojectmembers((string)usermeetings[i][4]);

                            int projmem = 0;
                            if (getprojmembers != null)
                            {
                                projmem = getprojmembers.Length;
                            }

                            htmldata1 += "<a href=\"Meetingview.aspx?id=" + (string)usermeetings[i][0] + "\">";
                                htmldata1 += "<div class=\"col s12 m3 l0\">";


                                htmldata1 += "<div class=\"card horizontal hoverable grey lighten-1\">";

                                htmldata1 += "<div class=\"card-stacked\">";
                                htmldata1 += "<div class=\"card-content black-text\">";
                                htmldata1 += "<span class=\"card-title\">" +
                                "<p class=\" bold\">" + (string)usermeetings[i][2] + "</p>";
                                htmldata1 += "</span>";
                                htmldata1 += "<p class=\"trunctext\">Project: " + (string)projdetails[1] + "</p>";
                                 htmldata1 += "<p class=\"trunctext\">Project Members: " + projmem + "</p>";
                                 htmldata1 += "<p class=\"trunctext\">Members Attending: " + mematt + "</p>";
                                 htmldata1 += "</div>";
                                htmldata1 += "</div>";
                                htmldata1 += "</div>";
                                htmldata1 += "</div>";
                                htmldata1 += "</a>";

                            }


                        }



                    }



                    userothermeetings = findata.getmeetinginfromations(user.getID());
                    if (userothermeetings != null)
                    {

                        for (int i = 0; i < userothermeetings.Length; i++)
                        {
                            DateTime meetdate = DateTime.Parse((string)userothermeetings[i][3]);
                            int result = DateTime.Compare(meetdate, DateTime.Now);
                            projdetails = findata.getprojectdetails((string)userothermeetings[i][4]);
                            if (result < 0)
                            {

                            }
                            else
                            {
                            object[][] getattenginguser = findata.getallattendingmeeting((string)userothermeetings[i][0]);
                            int mematt = 0;
                            if (getattenginguser != null)
                            {

                                mematt = getattenginguser.Length;
                            }

                            object[] getprojmembers = findata.getprojectmembers((string)userothermeetings[i][4]);

                            int projmem = 0;
                            if (getprojmembers != null)
                            {
                                projmem = getprojmembers.Length;
                            }
                            if (Boolean.Parse((string)userothermeetings[i][7]) == true)
                            {
                                htmldata2 += "<a href=\"Meetingaccept.aspx?id=" + (string)userothermeetings[i][0] + "&ml=" + (string)userothermeetings[i][6] + "\">";
                                htmldata2 += "<div class=\"col s12 m3 l0\">";


                                htmldata2 += "<div class=\"card horizontal hoverable light-blue lighten-3\">";

                                htmldata2 += "<div class=\"card-stacked\">";
                                htmldata2 += "<div class=\"card-content black-text\">";
                                htmldata2 += "<span class=\"card-title\">" +
                                "<p class=\" bold\">" + (string)userothermeetings[i][2] + "</p>";
                                htmldata2 += "</span>";
                                htmldata2 += "<p class=\"trunctext\">Project: " + (string)projdetails[1] + "</p>";
                                htmldata2 += "<p class=\"trunctext\">Project Members: " + projmem + "</p>";
                                htmldata2 += "<p class=\"trunctext\">Members Attending: " + mematt + "</p>";


                                htmldata2 += "</div>";
                                htmldata2 += "</div>";
                                htmldata2 += "</div>";
                                htmldata2 += "</div>";
                                htmldata2 += "</a>";

                            }
                            else
                            {
                                htmldata2 += "<a href=\"Meetingaccept.aspx?id=" + (string)userothermeetings[i][0] + "&ml=" + (string)userothermeetings[i][6] + "\">";
                                htmldata2 += "<div class=\"col s12 m3 l0\">";


                                htmldata2 += "<div class=\"card horizontal hoverable lime lighten-3\">";

                                htmldata2 += "<div class=\"card-stacked\">";
                                htmldata2 += "<div class=\"card-content black-text\">";
                                htmldata2 += "<span class=\"card-title\">" +
                                "<p class=\" bold\">" + (string)userothermeetings[i][2] + "</p>";
                                htmldata2 += "</span>";
                                htmldata2 += "<p class=\"trunctext\">Project: " + (string)projdetails[1] + "</p>";
                                htmldata2 += "<p class=\"trunctext\">Project Members: " + projmem + "</p>";
                                htmldata2 += "<p class=\"trunctext\">Members Attending: " + mematt + "</p>";


                                htmldata2 += "</div>";
                                htmldata2 += "</div>";
                                htmldata2 += "</div>";
                                htmldata2 += "</div>";
                                htmldata2 += "</a>";



                            }

                               

                            }

                        }


                    }




                    findata.Close();
                
                yourmeet.InnerHtml = htmldata1;
                othermeet.InnerHtml = htmldata2;
            }
            else
            {

                Response.Redirect("Login.aspx");
            }

        }

      
    }
}