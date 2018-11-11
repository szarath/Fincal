using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fincal
{
    public partial class Issuereport : System.Web.UI.Page
    {
        Dataservice.DatamanagementClient findata;
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Issue Report";
            if (Session["User"] != null)
            {
                if (!IsPostBack)
                {
                    UserData user = (UserData)Session["User"];
                     findata = new Dataservice.DatamanagementClient();
                    findata.Open();
                    
                    object[] userassingedproj = findata.getassignedprojects(user.getID());

                    if (userassingedproj != null)
                    {

                        for (int i = 0; i < userassingedproj.Length; i++)
                        {
                            object[] projdetails = findata.getprojectdetails((string)userassingedproj[i]);

                            Projectchoose.Items.Add(new ListItem(" " + (string)projdetails[1], projdetails[0].ToString()));
                         

                        }



                    }



                    findata.Close();
                }


            }
            else
            { Response.Redirect("Login.aspx"); }



        }


        protected void btnissflagadd_ServerClick(object sender, EventArgs e)
        {
            findata = new Dataservice.DatamanagementClient();

            UserData user = (UserData)Session["User"];
            if (txtisst.Value.Equals("") || txtissd.Value.Equals("") || Projectchoose.Items[Projectchoose.SelectedIndex].Text.Equals(""))
            {
                Invlaidproject.InnerHtml = "*Please make sure you have filled in all the fields<br/>";
                return;
            }
            else
            {
                findata.Open();

                int result = findata.insertissflag(txtisst.Value.ToString(),txtissd.Value.ToString(),Projectchoose.Items[Projectchoose.SelectedIndex].Value.ToString(),user.getID());

                if (result != 0)
                {

                    changePage();


                }


                findata.Close();

            }

        }
        private void changePage()
        {

            projectdiv.InnerHtml = "<div class=\"col s12 m6 l4 push-l4 push-m3\">";

            projectdiv.InnerHtml += "<div class=\"card white\">";
            projectdiv.InnerHtml += "<div class=\"card-content Black-text\">";
            projectdiv.InnerHtml += "<span class=\"card-title bold\">Issue reported successfully</span>";
            projectdiv.InnerHtml += "<p>You have successfully reported the issue</p>";
            projectdiv.InnerHtml += "</div>";
            projectdiv.InnerHtml += "<div class=\"card-action\">";
            projectdiv.InnerHtml += "<a href=\"Default.aspx\" runat=\"server\" class=\"btn waves-effect waves-light\"><i class=\"material-icons left\">home</i>Home</a>";
            projectdiv.InnerHtml += "<a href=\"Issues.aspx\" runat=\"server\" class=\"btn waves-effect waves-light orange\"><i class=\"material-icons left\">assignment</i>Issues</a>";
            projectdiv.InnerHtml += "<a href=\"Issuereport.aspx\" runat=\"server\" class=\"btn waves-effect waves-light orange\"><i class=\"material-icons left\">add_circle</i>Report another issue</a>";
            projectdiv.InnerHtml += "</div>";
            projectdiv.InnerHtml += "</div>";
            projectdiv.InnerHtml += "</div>";
        }
    }
}