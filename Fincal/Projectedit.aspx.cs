using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fincal
{
    public partial class Projectedit : System.Web.UI.Page
    {
        string pid;
        Object[][] members =null;
        object[] project;
        object[] projectmembers;

        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                int numusers = 0;
                Title = "Project Edit";

                pid = Request.QueryString.Get("id");
                UserData user = (UserData)Session["User"];
                Currentmembers.Multiple = true;
                Othermembers.Multiple = true;
                if (!IsPostBack)
                {
                    Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
                    findata.Open();
                  members = findata.getuserinformation();
                  project = findata.getprojectdetails(pid);
                     projectmembers = findata.getprojectmembers(pid);

                    txtprojt.Value = (string)project[1];
                    txtprojd.Value = (string)project[2];

                    for (int i = 0; i < members.Length; i++)
                    {
                        if ((string)members[i][0] == user.getID())
                        {

                        }
                        else
                        {
                            Boolean userisamember = false;
                            Boolean notice = false;
                            if(projectmembers != null)
                            { 
                                for (int j = 0; j < projectmembers.Length; j++)
                                {
                                    if ((string)members[i][0] == (string)projectmembers[j])
                                    {
                                        userisamember = true;
                                    }


                                }
                            }
                            object[][] projnotice = findata.getprojnotification((string)members[i][0]);

                            if (projnotice != null)
                            {
                                for (int a = 0; a < projnotice.Length; a++)
                                {
                                    if (Convert.ToInt32( pid) == Convert.ToInt32((string)projnotice[a][1]))
                                    {
                                        notice = true;

                                    }


                                }


                            }


                            if (notice == false)
                            {
                            if (userisamember == true)
                            {
                                Object[][] userevents = findata.getalluserevents((string)members[i][0]);
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
                                Currentmembers.Items.Add(new ListItem(" " + priority(eventcount).ToString() + " " + (string)members[i][1] + "   " + (string)members[i][2] + "   ", members[i][0].ToString()));
                            }
                            else
                            {
                                Object[][] userevents = findata.getalluserevents((string)members[i][0]);
                                int eventcount = 0;
                                if (userevents != null)
                                {


                                    for (int j = 0; j < userevents.Length; j++)
                                    {
                                        DateTime credate = DateTime.Parse((string)userevents[j][1]);
                                        DateTime exweek = credate.AddDays(14);


                                        int result = DateTime.Compare(credate, DateTime.Now.AddDays(14));

                                        if (result < 0)
                                        {
                                            eventcount += 1;
                                        }


                                    }


                                }
                                if (numusers <= 30)
                                {
                                    if (priority(eventcount).ToString() == "Free" || priority(eventcount).ToString() == "Occupied")
                                    {
                                        Othermembers.Items.Add(new ListItem(" " + priority(eventcount).ToString() + " " + (string)members[i][1] + " " + (string)members[i][2] + " ", members[i][0].ToString()));
                                        numusers += 1;
                                    }


                                }
                             
                            }
                            }
                           



                        }

                    }

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
        protected void btnprojedit_ServerClick(object sender, EventArgs e)
        {
            pid = Request.QueryString.Get("id");
            UserData user = (UserData)Session["User"];

            Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
            findata.Open();
            if (txtprojd.Value.Equals("") || txtprojt.Value.Equals(""))
            {

                projecteditdiv.InnerHtml = "*Please make sure you have filled in all the fields<br/>";
                return;
            }
            else
            {

              int result =  findata.updateproject(txtprojt.Value, txtprojd.Value, pid);


                if (result == 1)
                {
                    foreach (ListItem item in Currentmembers.Items)
                    {
                        if (item.Selected)
                        {
                            int id = Convert.ToInt32(item.Value.ToString());
                            
                            findata.deleteassiguserfromteam(id.ToString(), pid);
                        }

                    }
                    foreach (ListItem item in Othermembers.Items)
                    {
                        if (item.Selected)
                        {
                            int id = Convert.ToInt32(item.Value.ToString());
                            findata.insertprojectnotifications(pid, id.ToString(), DateTime.Now);

                        }

                    }


                }


            }
            
            findata.Close();
            changePage();
        }

        protected void btnDeleteproject_ServerClick(object sender, EventArgs e)
        {
            Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();

            Chatmanagement.ChatClient chat = new Chatmanagement.ChatClient();
            UserData user = (UserData)Session["User"];
            findata.Open();
            chat.Open();
           
                int team = findata.deleteprojteam(pid);
                int delete = findata.deleteallprojnotificaion(pid);
                int deleteprojchat = chat.deleteprojchat(pid);
                int deltepissflags = findata.deleteissflagproj(pid);
                object[] getmeetingid = findata.getprojmeetings(pid);

                if(getmeetingid != null)
                {
                    
                    for (int i = 0; i < getmeetingid.Length; i++)
                    {
                     int meetmemdel =    findata.deletemeetingmembers((string)getmeetingid[i]);

                        
                     findata.deletemeeting((string)getmeetingid[i]);

                        


                    }
                }


             
                object[][] getprojiss = findata.getprojissues(pid);

                if (getprojiss != null) { 
                for(int i = 0; i < getprojiss.Length;i++)
                {
                        object[] issnotice = findata.getissnoticeiss((string)getprojiss[i][0]);
                        if(issnotice != null)
                        {
                            findata.deleteissnoticeiss((string)getprojiss[i][0]);
                        }
                        chat.deleteissuechat((string)getprojiss[i][0]);

                        findata.deleteissue((string)getprojiss[i][0]);


                     

                }
                }

                
                    int proj = findata.deleteproject(pid);
                    if (proj == 1)
                    {
                        changePagedelete();
                    }
                     else {

                    changePageerror();

                        }

      
         
            chat.Close();
            findata.Close();
        }

        protected void btnissueadd_ServerClick(object sender, EventArgs e)
        {

            if (Currentmembers.Items.Count == 0)
            {
                Invlaidproject.InnerHtml += "*Please add members to add issues</br>";

            }
            else
            {
                Response.Redirect("Issueadd.aspx?id=" + pid);
            }



        }

        protected void changePage()
        {

            projecteditdiv.InnerHtml = "<div class=\"col s12 m6 l4 push-l4 push-m3\">";

            projecteditdiv.InnerHtml += "<div class=\"card white\">";
            projecteditdiv.InnerHtml += "<div class=\"card-content Black-text\">";
            projecteditdiv.InnerHtml += "<span class=\"card-title bold\">Project Edited Successful</span>";
            projecteditdiv.InnerHtml += "<p>You have successfully edited the project </p>";
            projecteditdiv.InnerHtml += "</div>";
            projecteditdiv.InnerHtml += "<div class=\"card-action\">";

            projecteditdiv.InnerHtml += "<a href=\"Default.aspx\" runat=\"server\" class=\"btn waves-effect waves-light\"><i class=\"material-icons left\">home</i>Home</a>";
            projecteditdiv.InnerHtml += "<a href=\"Projects.aspx\" runat=\"server\" class=\"btn orange waves-effect waves-light\"><i class=\"material-icons left\">assignment</i>Projects</a>";

            projecteditdiv.InnerHtml += "</div>";
            projecteditdiv.InnerHtml += "</div>";
            projecteditdiv.InnerHtml += "</div>";
        }
        protected void changePagedelete()
        {

            projecteditdiv.InnerHtml = "<div class=\"col s12 m6 l4 push-l4 push-m3\">";

            projecteditdiv.InnerHtml += "<div class=\"card white\">";
            projecteditdiv.InnerHtml += "<div class=\"card-content Black-text\">";
            projecteditdiv.InnerHtml += "<span class=\"card-title bold\">Project Deleted</span>";
            projecteditdiv.InnerHtml += "<p>You have successfully delete the project</p>";
            projecteditdiv.InnerHtml += "</div>";
            projecteditdiv.InnerHtml += "<div class=\"card-action\">";
            projecteditdiv.InnerHtml += "<a href=\"Default.aspx\" runat=\"server\" class=\"btn waves-effect waves-light\"><i class=\"material-icons left\">home</i>Home</a>";
            projecteditdiv.InnerHtml += "<a href=\"Projects.aspx\" runat=\"server\" class=\"btn orange waves-effect waves-light\"><i class=\"material-icons left\">assignment</i>Projects</a>";
            projecteditdiv.InnerHtml += "</div>";
            projecteditdiv.InnerHtml += "</div>";
            projecteditdiv.InnerHtml += "</div>";
        }

        protected void changePageerror()
        {

            projecteditdiv.InnerHtml = "<div class=\"col s12 m6 l4 push-l4 push-m3\">";

            projecteditdiv.InnerHtml += "<div class=\"card white\">";
            projecteditdiv.InnerHtml += "<div class=\"card-content Black-text\">";
            projecteditdiv.InnerHtml += "<span class=\"card-title bold\">Error</span>";
            projecteditdiv.InnerHtml += "<p>Something went wrong please try again </p>";
            projecteditdiv.InnerHtml += "</div>";
            projecteditdiv.InnerHtml += "<div class=\"card-action\">";
            projecteditdiv.InnerHtml += "<a href=\"Default.aspx\" runat=\"server\" class=\"btn waves-effect waves-light\"><i class=\"material-icons left\">home</i>Home</a>";
            projecteditdiv.InnerHtml += "<a href=\"Projects.aspx\" runat=\"server\" class=\"btn orange waves-effect waves-light\"><i class=\"material-icons left\">assignment</i>Projects</a>";
            projecteditdiv.InnerHtml += "</div>";
            projecteditdiv.InnerHtml += "</div>";
            projecteditdiv.InnerHtml += "</div>";
        }
    }
}