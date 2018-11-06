using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fincal
{
    public partial class Issueedit : System.Web.UI.Page
    {
        string pid;
        Object[] issuemembers;
        object[] issue;
        object[] projectmembers;
        object[] project;
        object[] userdetails;
         protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Title = "Fincal: Edit Issue ";

                pid = Request.QueryString.Get("id");
                UserData user = (UserData)Session["User"];
                Currentmembers.Multiple = true;
                Othermembers.Multiple = true;
                if (!IsPostBack)
                {
                    Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
                    findata.Open();
                    issuemembers = findata.getissuemembers(pid);
                    issue = findata.getissuedetails(pid);

                    projectmembers = findata.getprojectmembers((string)issue[3]);

                   
                    
                    project = findata.getprojectdetails((string)issue[3]);
                    txtprojname.Value = (string)project[1];
               

                    txtprojt.Value = (string)project[1];
                    txtprojd.Value = (string)project[2];

                    for (int i = 0; i < projectmembers.Length; i++)
                    {
                        

                        if ((string)projectmembers[i]== user.getID())
                        {

                        }
                        else
                        {
                            Boolean userisamember = false;
                            if (projectmembers != null)
                            {
                                for (int j = 0; j < projectmembers.Length; j++)
                                {
                                    if (issuemembers != null)
                                    {

                                        if ((string)projectmembers[i] == (string)issuemembers[j])
                                        {
                                            userisamember = true;

                                        }

                                        userdetails = findata.getspecificuserinformation((string)projectmembers[j]);

                                    }
                                    else
                                    {
                                        userdetails = findata.getspecificuserinformation((string)projectmembers[j]);
                                        userisamember = false;

                                    }
                                }
                            }

                            if (userisamember == true)
                            {
                              
                                Currentmembers.Items.Add(new ListItem(" " + (string)userdetails[0] + " " + (string)userdetails[2] + " ", (string)projectmembers[i].ToString()));
                            }
                            else
                            {
                                Othermembers.Items.Add(new ListItem(" " + (string)userdetails[0] + " " + (string)userdetails[2] + " ", (string)projectmembers[i].ToString()));
                            }



                        }

                    }

                    findata.Close();

                }
            }
        }


        protected void btnissedit_ServerClick(object sender, EventArgs e)
        {
            pid = Request.QueryString.Get("id");
            UserData user = (UserData)Session["User"];

            Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
            findata.Open();
            if (txtprojd.Value.Equals("") || txtprojt.Value.Equals(""))
            {

                projecteditdiv.InnerHtml += "*Please make sure you have filled in all the fields<br/>";

            }
            else
            {

                int result = findata.updateproject(txtprojt.Value, txtprojd.Value, pid);


                if (result == 1)
                {
                    foreach (ListItem item in Currentmembers.Items)
                    {
                        if (item.Selected)
                        {
                            int id = Convert.ToInt32(item.Value.ToString());

                            findata.deleteassiguserformissue(id.ToString(), pid);
                        }

                    }
                    foreach (ListItem item in Othermembers.Items)
                    {
                        if (item.Selected)
                        {
                            int id = Convert.ToInt32(item.Value.ToString());
                            findata.insertissuenotifications(pid, id.ToString());

                        }

                    }


                }


            }

            findata.Close();
            Response.Redirect("Projects.aspx");
        }


        protected void btnissdelete_ServerClick(object sender, EventArgs e)
        {
            Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
            Chatmanagement.ChatClient chat = new Chatmanagement.ChatClient();
            chat.Open();
            UserData user = (UserData)Session["User"];
            findata.Open();

            int result = findata.deleteprojissues(pid);
            if (result == 1)
            {
                int team = findata.deleteprojteam(pid);
                int delete = findata.deleteallprojnotificaion(pid);
               int deleteiss = findata.deleteissue(pid);
                int delelteisschat = chat.deleteissuechat(pid);

                 
                if(team == 1 && delete == 1 && deleteiss == 1 && delelteisschat == 1)
                {
                    int proj = findata.deleteproject(pid);
                    if (proj == 1)
                    {
                        changePagedelete();
                    }
                }

            }
            else
            {


                changePageerror();
            }

            findata.Close();
            chat.Close();

        }

           protected void changePage()
        {

            projecteditdiv.InnerHtml = "<div class=\"col s12 m6 l4 push-l4 push-m3\">";

            projecteditdiv.InnerHtml += "<div class=\"card white\">";
            projecteditdiv.InnerHtml += "<div class=\"card-content Black-text\">";
            projecteditdiv.InnerHtml += "<span class=\"card-title bold\">Issue Edited Successful</span>";
            projecteditdiv.InnerHtml += "<p>You have successfully edited the issue </p>";
            projecteditdiv.InnerHtml += "</div>";
            projecteditdiv.InnerHtml += "<div class=\"card-action\">";

            projecteditdiv.InnerHtml += "<a href=\"Default.aspx\" runat=\"server\" class=\"btn waves-effect waves-light\"><i class=\"material-icons left\">home</i>Home</a>";
            projecteditdiv.InnerHtml += "<a href=\"Issues.aspx\" runat=\"server\" class=\"btn orange waves-effect waves-light\"><i class=\"material-icons left\">notification_important</i>Issues</a>";

            projecteditdiv.InnerHtml += "</div>";
            projecteditdiv.InnerHtml += "</div>";
            projecteditdiv.InnerHtml += "</div>";
        }
        protected void changePagedelete()
        {

            projecteditdiv.InnerHtml = "<div class=\"col s12 m6 l4 push-l4 push-m3\">";

            projecteditdiv.InnerHtml += "<div class=\"card white\">";
            projecteditdiv.InnerHtml += "<div class=\"card-content Black-text\">";
            projecteditdiv.InnerHtml += "<span class=\"card-title bold\">Issue Deleted</span>";
            projecteditdiv.InnerHtml += "<p>You have successfully delete the issue</p>";
            projecteditdiv.InnerHtml += "</div>";
            projecteditdiv.InnerHtml += "<div class=\"card-action\">";
            projecteditdiv.InnerHtml += "<a href=\"Default.aspx\" runat=\"server\" class=\"btn waves-effect waves-light\"><i class=\"material-icons left\">home</i>Home</a>";
            projecteditdiv.InnerHtml += "<a href=\"Issues.aspx\" runat=\"server\" class=\"btn orange waves-effect waves-light\"><i class=\"material-icons left\">notification_important</i>Issues</a>";
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
            projecteditdiv.InnerHtml += "<a href=\"Issues.aspx\" runat=\"server\" class=\"btn orange waves-effect waves-light\"><i class=\"material-icons left\">notification_important</i>Issues</a>";
            projecteditdiv.InnerHtml += "</div>";
            projecteditdiv.InnerHtml += "</div>";
            projecteditdiv.InnerHtml += "</div>";
        }
    }
}