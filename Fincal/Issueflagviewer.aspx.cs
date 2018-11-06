using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fincal
{
    public partial class Issueflagviewer : System.Web.UI.Page
    {
        private string id;
        private object[] projdetails;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {

                if (!IsPostBack)
                {
                     id = Request.QueryString.Get("id");
                    Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
                    findata.Open();

                    object[] issdetails = findata.getspecificissflag(id);

                    if (issdetails != null)
                    {
                      projdetails = findata.getprojectdetails((string)issdetails[5]);
                        txtprojname.Value = (string)projdetails[1];
                        txtruser.Value = (string)issdetails[1];
                        txtisstitle.Value = (string)issdetails[3];
                        txtissdesc.Value = (string)issdetails[4];


                    }




                    findata.Close();
                }
            }
            else
            {
                Response.Redirect("Login.aspx");

            }


           
        }
        protected void btnissueadd_ServerClick(object sender, EventArgs e)
        {
            Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
            findata.Open();
            UserData user = (UserData)Session["User"];
            Object[][] members = findata.getuserinformation();


            if (txtisstitle.Value.Equals("") || txtissdesc.Value.Equals("") || UserChoose.Items[UserChoose.SelectedIndex].Text.Equals(""))
            {
                Invlaidproject.InnerHtml += "*Please make sure you have filled in all the fields<br/>";

            }
            else
            {

                int result = findata.createissue(txtisstitle.Value, txtissdesc.Value, id, user.getID());
                if (result != 0)
                {
                    foreach (ListItem item in UserChoose.Items)
                    {
                        if (item.Selected)
                        {
                            int id = Convert.ToInt32(item.Value.ToString());
                            findata.insertissuenotifications(result.ToString(), id.ToString());

                        }

                    }



                }


            }




            findata.Close();
            changePage();
        }

        protected void btnissreject_ServerClick(object sender, EventArgs e)
        {
            Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
            findata.Open();
            UserData user = (UserData)Session["User"];

            int result = findata.deleteissflag(id);

            if (result == 1)
            {
                changePagerejected();

            }
           
            findata.Close();
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
            projectdiv.InnerHtml += "<a href=\"Default.aspx\" runat=\"server\" class=\"btn waves-effect waves-light\"><i class=\"material - icons\">home</i>Home</a>";
            projectdiv.InnerHtml += "<a href=\"Issues.aspx\" runat=\"server\" class=\"btn waves-effect waves-light orange\"><i class=\"material - icons\">notification_important</i>Issues</a>";
         
            projectdiv.InnerHtml += "</div>";
            projectdiv.InnerHtml += "</div>";
            projectdiv.InnerHtml += "</div>";
        }

        protected void changePagerejected()
        {

            projectdiv.InnerHtml = "<div class=\"col s12 m6 l4 push-l4 push-m3\">";

            projectdiv.InnerHtml += "<div class=\"card white\">";
            projectdiv.InnerHtml += "<div class=\"card-content Black-text\">";
            projectdiv.InnerHtml += "<span class=\"card-title bold\">No members</span>";
            projectdiv.InnerHtml += "<p>Please add members to add issues</p>";
            projectdiv.InnerHtml += "</div>";
            projectdiv.InnerHtml += "<div class=\"card-action\">";
            projectdiv.InnerHtml += "<a href=\"Default.aspx\" runat=\"server\" class=\"btn waves-effect waves-light\"><i class=\"material - icons\">home</i>Home</a>";

            projectdiv.InnerHtml += "<a href=\"Issues.aspx\" runat=\"server\" class=\"btn waves-effect waves-light orange\"><i class=\"material - icons\">notification_important</i>Issues</a>";

            projectdiv.InnerHtml += "</div>";
            projectdiv.InnerHtml += "</div>";
            projectdiv.InnerHtml += "</div>";
        }
    }
}