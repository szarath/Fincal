using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fincal
{
    public partial class Projectadd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else { 
            UserData user = (UserData)Session["User"];
            UserChoose.Multiple = true;
            if (!IsPostBack)
            {
                Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
            findata.Open();
            Object[][] members = findata.getuserinformation();
           

            for (int i = 0; i < members.Length; i++)
            {
                if ((string)members[i][0] == user.getID())
                {

                }
                else {

                    UserChoose.Items.Add(new ListItem(" " + (string)members[i][1] + " " + (string)members[i][2] + " ", members[i][0].ToString()));

                }

            }

            }
            }
        }

        protected void btnprojadd_ServerClick(object sender, EventArgs e)
        {
            Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
            findata.Open();
            UserData user = (UserData)Session["User"];
            Object[][] members = findata.getuserinformation();


            if (txtprojd.Value.Equals("") || txtprojt.Value.Equals("") || UserChoose.Value.Equals(""))
            {
                Invlaidproject.InnerHtml += "*Please make sure you have filled in all the fields<br/>";

            }
            else {

                int result = findata.createproject(txtprojt.Value, txtprojd.Value, user.getID());
                if (result != 0)
                {
                    foreach (ListItem item in UserChoose.Items)
                    {
                        if (item.Selected)
                        {
                            int id = Convert.ToInt32(item.Value.ToString());
                            findata.insertprojectnotifications(result.ToString(), id.ToString());

                        }

                    }



                }
            }
          
            
           

            findata.Close();

        }


        protected void changePage()
        {

            projectdiv.InnerHtml = "<div class=\"col s12 m6 l4 push-l4 push-m3\">";

            projectdiv.InnerHtml += "<div class=\"card white\">";
            projectdiv.InnerHtml += "<div class=\"card-content Black-text\">";
            projectdiv.InnerHtml += "<span class=\"card-title bold\">Registration Successful</span>";
            projectdiv.InnerHtml += "<p>You have successfully added a Project</p>";
            projectdiv.InnerHtml += "</div>";
            projectdiv.InnerHtml += "<div class=\"card-action\">";
            projectdiv.InnerHtml += "<a href=\"Projects.aspx\" runat=\"server\" class=\"btn waves-effect waves-light\">Continue</a>";
            projectdiv.InnerHtml += "</div>";
            projectdiv.InnerHtml += "</div>";
            projectdiv.InnerHtml += "</div>";
        }
    }
}