using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fincal
{
    public partial class Projectaccept : System.Web.UI.Page
    {
        string pid;
        string pn;
        object[] projdetails;
        object[] pldetails;
        object[] pndetails;
        object[] projectmembers;
        object[] projectmemdetails;
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
                pn = Request.QueryString.Get("pn");
                findata.Open();
               
                    projdetails = findata.getprojectdetails(pid);
                    pndetails = findata.getprojnoticedetails(pn);
                    projectmembers = findata.getprojectmembers(pid);

                    txtprojt.Value = (string)projdetails[1];
                    txtprojd.Value = (string)projdetails[2];

                    txtexp.Value = DateTime.Parse((string)pndetails[3]).AddDays(14).ToString();
                    pldetails = findata.getprojectleaderinformaion((string)projdetails[3]);

                    txtptojectleaderuname.Value = (string)pldetails[0];

                    txtptojectleaderemail.Value = (string)pldetails[1];

                    txtcredate.Value = (string)projdetails[4];

                 
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
                            htmldata += "<li class=\"collection-item\"><span style=\"font-weight:bold\">Username:    " + (string)projectmemdetails[0] + "&nbsp&nbsp&nbsp              Email:     " + (string)projectmemdetails[1] + "&nbsp&nbsp&nbsp              Skill:      " + (string)projectmemdetails[2] + "</span></li>";


                        }

                    }
                    else
                    {

                        htmldata += "<li class=\"collection-item\"><span style=\"font-weight:bold\">No memebrs yet</span></li>";

                    }


                    findata.Close();
              
            }

            membersonproject.InnerHtml += htmldata;
        }

        protected void btnacceptproject_ServerClick(object sender, EventArgs e)
        {
            UserData user = (UserData)Session["User"];
            Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
            findata.Open();
           

           int result = findata.addprojteam(user.getID(), pid);

            if (result == 1)
            {
                int delete = findata.deleteporjnotificaiton(pid, user.getID());

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
          int result = findata.deleteporjnotificaiton(pid,user.getID());


            if (result == 1)
            {
                changecancelPage();
            }
            else {

                changeerrorPage();
            }

            findata.Close();
        }

        protected void changeaccPage()
        {

            projacc.InnerHtml = "<div class=\"col s12 m6 l4 push-l4 push-m3\">";

            projacc.InnerHtml += "<div class=\"card white\">";
            projacc.InnerHtml += "<div class=\"card-content Black-text\">";
            projacc.InnerHtml += "<span class=\"card-title bold\">Project Accepted</span>";
            projacc.InnerHtml += "<p>Project has been Accepted and added to your other projects</p>";
            projacc.InnerHtml += "</div>";
            projacc.InnerHtml += "<div class=\"card-action\">";
            projacc.InnerHtml += "<a href=\"Default.aspx\" runat=\"server\" class=\"btn waves-effect waves-light\"><i class=\"material-icons left\">home</i>Home</a>";
            projacc.InnerHtml += "<a href=\"Projects.aspx\" runat=\"server\" class=\"btn orange waves-effect waves-light\"><i class=\"material-icons left\">assignment</i>Projects</a>";
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
            projacc.InnerHtml += "</div>";
            projacc.InnerHtml += "</div>";
            projacc.InnerHtml += "</div>";
        }

        protected void changecancelPage()
        {

            projacc.InnerHtml = "<div class=\"col s12 m6 l4 push-l4 push-m3\">";
            projacc.InnerHtml += "<div class=\"card white\">";
            projacc.InnerHtml += "<div class=\"card-content Black-text\">";
            projacc.InnerHtml += "<span class=\"card-title bold\">Project Rejected</span>";
            projacc.InnerHtml += "<p>Project was rejected by you</p>";
            projacc.InnerHtml += "</div>";
            projacc.InnerHtml += "<div class=\"card-action\">";
            projacc.InnerHtml += "<a href=\"Default.aspx\" runat=\"server\" class=\"btn waves-effect waves-light\"><i class=\"material-icons left\">home</i>Home</a>";
            projacc.InnerHtml += "<a href=\"Projects.aspx\" runat=\"server\" class=\"btn orange waves-effect waves-light\"><i class=\"material-icons left\">assignment</i>Projects</a>";
            projacc.InnerHtml += "</div>";
            projacc.InnerHtml += "</div>";
            projacc.InnerHtml += "</div>";
        }
    }
}