﻿using Google.Apis.Tasks.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fincal
{
    public partial class Issueadd : System.Web.UI.Page
    {
        private string pid;
        static string[] Scopes = { TasksService.Scope.Tasks, TasksService.Scope.TasksReadonly };
        static string ApplicationName = "Google Tasks API .NET Quickstart";
        private Google.Apis.Tasks.v1.Data.Task newtask;
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Issue Add";
            pid = Request.QueryString.Get("id");
            Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
            findata.Open();
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    LevelDrop.Items.Add(new ListItem("1", "1"));
                    LevelDrop.Items.Add(new ListItem("2", "2"));
                    LevelDrop.Items.Add(new ListItem("3", "3"));

                }
               
                if (!IsCallback) {
                
                    UserData user = (UserData)Session["User"];
                UserChoose.Multiple = true;

                object[] projdetails = findata.getprojectdetails(pid);
                txtprojname.Value = (string)projdetails[1];

                object[] projmembers = findata.getprojectmembers(pid);
                    if (projmembers != null)
                    {

                        for (int i = 0; i < projmembers.Length; i++)
                        {
                            object[] getmemberdetails = findata.getspecificuserinformation((string)projmembers[i]);


                            if ((string)getmemberdetails[0] == user.getID())
                            {

                            }
                            else
                            {

                                Object[][] userevents = findata.getalluserevents((string)projmembers[i]);
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
                                UserChoose.Items.Add(new ListItem(" " + priority(eventcount).ToString() + "     " + (string)getmemberdetails[0] + "     " + (string)getmemberdetails[2] + " ", (string)projmembers[i].ToString()));

                            }

                        }



                    }
                    else
                    {
                        Response.Redirect("Projectedit.aspx?id=" + pid);
                    }

            }


            }
            findata.Close();
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
        protected void btnprojadd_ServerClick(object sender, EventArgs e)
        {
            Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
            findata.Open();
            UserData user = (UserData)Session["User"];
          

            if (txtprojd.Value.Equals("") || txtprojt.Value.Equals("") || LevelDrop.Items[LevelDrop.SelectedIndex].Text.Equals("Choose Level"))
            {
                Invlaidproject.InnerHtml += "*Please make sure you have filled in all the fields<br/>";
                return;
            }
            else if (UserChoose.Items[UserChoose.SelectedIndex].Text.Equals("Choose Member"))
            {

                Invlaidproject.InnerHtml = "*You have to at least invite one member to issue<br/>";

            }
            else
            {
                
                      int result = findata.createissue(txtprojt.Value, txtprojd.Value, pid, LevelDrop.Items[LevelDrop.SelectedIndex].Value.ToString() ,user.getID(),DateTime.Now);
                      if (result != 0)
                         {
                         foreach (ListItem item in UserChoose.Items)
                          {
                        if (item.Selected)
                        {
                            int id = Convert.ToInt32(item.Value.ToString());
                            findata.insertissuenotifications(result.ToString(), id.ToString(), DateTime.Now);
                        }

                    }
                        


                }

            
            }




            findata.Close();
            changePage();
        }


        protected void changePage()
        {

            projectdiv.InnerHtml = "<div class=\"col s12 m6 l4 push-l4 push-m3\">";

            projectdiv.InnerHtml += "<div class=\"card white\">";
            projectdiv.InnerHtml += "<div class=\"card-content Black-text\">";
            projectdiv.InnerHtml += "<span class=\"card-title bold\">Issue added successful</span>";
            projectdiv.InnerHtml += "<p>You have successfully added an issue</p>";
            projectdiv.InnerHtml += "</div>";
            projectdiv.InnerHtml += "<div class=\"card-action\">";
            projectdiv.InnerHtml += "<a href=\"Default.aspx\" runat=\"server\" class=\"btn waves-effect waves-light\"><i class=\"material-icons\">home</i>Home</a>";
            projectdiv.InnerHtml += "<a href=\"Issues.aspx\" runat=\"server\" class=\"btn waves-effect waves-light orange\"><i class=\"material-icons\">notification_important</i>Issues</a>";
            projectdiv.InnerHtml += "<a href=\"Issueadd.aspx?id=" + pid + "\" runat=\"server\" class=\"btn waves-effect waves-light blue\"><i class=\"material-icons\">add_alert</i>Add Another Issue</a>";
            projectdiv.InnerHtml += "</div>";
            projectdiv.InnerHtml += "</div>";
            projectdiv.InnerHtml += "</div>";
        }

        protected void changePagenomem()
        {

            projectdiv.InnerHtml = "<div class=\"col s12 m6 l4 push-l4 push-m3\">";

            projectdiv.InnerHtml += "<div class=\"card white\">";
            projectdiv.InnerHtml += "<div class=\"card-content Black-text\">";
            projectdiv.InnerHtml += "<span class=\"card-title bold\">No members</span>";
            projectdiv.InnerHtml += "<p>Please add members to the project</p>";
            projectdiv.InnerHtml += "</div>";
            projectdiv.InnerHtml += "<div class=\"card-action\">";
            projectdiv.InnerHtml += "<a href=\"Default.aspx\" runat=\"server\" class=\"btn waves-effect waves-light\"><i class=\"material-icons\">home</i>Home</a>";

            projectdiv.InnerHtml += "<a href=\"Projectedit.aspx?id=" + pid + "\" runat=\"server\" class=\"btn waves-effect waves-light blue\"><i class=\"material-icons\">assignment</i>Project Edit</a>";

            projectdiv.InnerHtml += "</div>";
            projectdiv.InnerHtml += "</div>";
            projectdiv.InnerHtml += "</div>";
        }
    }
}