using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fincal
{
    public partial class Profileviewer : System.Web.UI.Page
    {
        object[][] proj;
        object[][] iss;
        object[] userdata;
        string userid;
        int projnum;
        int isnum;
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Member Profile";

            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");

            }
            else
            {
                Title = "Fincal: Member Profile";


                UserData user = (UserData)(Session["User"]);
                Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
                userid = Request.QueryString.Get("uid");
                findata.Open();
                proj = findata.getprojects(userid);
                iss = findata.getissues(userid);

              userdata =   findata.getspecificuserinformation(userid);

                if (userdata != null)
                {
                    Object[][] userevents = findata.getalluserevents(userid);
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


                    if (proj != null)
                    {
                        for (int i = 0; i < proj.Length; i++)
                        {
                            projnum += 1;

                        }

                    }
                    else
                    {
                        projnum = 0;

                    }

                    if (iss != null)
                    {
                        for (int i = 0; i < iss.Length; i++)
                        {
                            isnum += 1;

                        }


                    }
                    else
                    {
                        isnum = 0;


                    }
                    txtusername.Value = (string)userdata[0];
                   
                    txtemail.Value = (string)userdata[1];
                    txtskill.Value = (string)userdata[2];
                    txtgit.Value = (string)userdata[3];
                    txtproj.Value = projnum.ToString();
                    txtiss.Value = isnum.ToString();
                    txtschedule.Value = priority(eventcount).ToString();


                    object[][] userprojects = findata.getprojects(user.getID());
                    object[] memberassignedprog = findata.getassignedprojects(userid);
                    object[][] membernotice = findata.getprojnotification(userid);
                    if (userprojects != null)
                    {
                 
                    for (int i = 0; i < userprojects.Length; i++)
                     {
                        bool ismem = false;
                        if(memberassignedprog != null) { 
                                 for (int j = 0; j < memberassignedprog.Length; j++)
                                 {
                                   if (Convert.ToInt32( (string)userprojects[i][0]) == Convert.ToInt32( (string)memberassignedprog[j]))
                                     {
                                         ismem = true;
                                     }


                                 }
                         }

                            if (membernotice != null)
                            {
                                for (int j = 0; j < membernotice.Length; j++)
                                {
                                    if (Convert.ToInt32((string)userprojects[i][0]) == Convert.ToInt32((string)membernotice[j][1]))
                                    {
                                        ismem = true;

                                    }



                                }


                            }

                            if (ismem == false)
                        {

                            Projectchoose.Items.Add(new ListItem(" " + (string)userprojects[i][1], userprojects[i][0].ToString()));

                        }
                        

                     }

                    }



                }


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

        protected void btninviteadd_ServerClick(object sender, EventArgs e)
        {
            Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
            findata.Open();
            if (Projectchoose.Items[Projectchoose.SelectedIndex].Text.Equals("Choose Project"))
            {
                Invlaidproject.InnerHtml += "*Please choose a project to invite for</br>";

            }
            else
            {
  int result = findata.insertprojectnotifications(Projectchoose.Items[Projectchoose.SelectedIndex].Value.ToString(),userid, DateTime.Now);
            if (result == 1)
            {

                changePage();


            }


            }

          
            findata.Close();
        }

        protected void changePage()
        {

            projectdiv.InnerHtml = "<div class=\"col s12  m6 l6   push-l4 push-m3\">";

            projectdiv.InnerHtml += "<div class=\"card white\">";
            projectdiv.InnerHtml += "<div class=\"card-content Black-text\">";
            projectdiv.InnerHtml += "<span class=\"card-title bold\">Invite Sent</span>";
            projectdiv.InnerHtml += "<p>You have successfully invited the user to the project</p>";
            projectdiv.InnerHtml += "</div>";
            projectdiv.InnerHtml += "<div class=\"card-action\">";
            projectdiv.InnerHtml += "<a href=\"Default.aspx\" runat=\"server\" class=\"btn waves-effect waves-light\"><i class=\"material-icons\">home</i>Home</a>";
            projectdiv.InnerHtml += "<a href=\"Projects.aspx\" runat=\"server\" class=\"btn waves-effect waves-light orange\"><i class=\"material-icons\">assignment</i>Issues</a>";
            projectdiv.InnerHtml += "<a href=\"Profileviewer.aspx?id=" + userid + "\" runat=\"server\" class=\"btn waves-effect waves-light blue\"><i class=\"material-icons\">add_alert</i>Invite to another project</a>";
            projectdiv.InnerHtml += "</div>";
            projectdiv.InnerHtml += "</div>";
            projectdiv.InnerHtml += "</div>";
        }

    }
}