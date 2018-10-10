using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fincal
{
    public partial class Myprofile : System.Web.UI.Page
    {
        private UserData user;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] != null) //Logged in
                {
                    Title = "Fincal: Account";
                     user = (UserData)(Session["User"]);
                    txtFirstName.Value = user.getFirstName();
                    txtLastName.Value = user.getSurname();

                    txtDoB.Value = user.getDoB().ToShortDateString();


                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void btnDeleteAcc_Click(object sender, EventArgs e)
        {
            Userservice.UserserviceClient service = new
            Userservice.UserserviceClient();
            service.Open();
            int result = service.deleteUser(user.getID());
            service.Close();
            if (result == 1)//if the result is one then the user is deleted and redirected to the index page 
            {
                Session["User"] = null;
                //Response.Write("<script>alert('User Account Deleted!');</script>");
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnUpdateAccount_ServerClick(object sender, EventArgs e)
        {

            Userservice.UserserviceClient service = new
             Userservice.UserserviceClient();
            service.Open();

            int result = service.updateUserInfo(user.getID(), txtFirstName.Value, txtLastName.Value, Convert.ToDateTime(txtDoB.Value));
            service.Close();
            if (result == 1)//if the result is one then the user is deleted and redirected to the index page 
            {
                Session["User"] = null;

                myProfileView.InnerHtml = "<div class='col s12 m6 push-m3'>";
                myProfileView.InnerHtml += "<div class='card white'>";
                myProfileView.InnerHtml += "<div class='card-content Black-text'>";
                myProfileView.InnerHtml += "<span class='card-title bold'>Account Updated Successfully</span>";
                myProfileView.InnerHtml += "<p>Your account has been updated successfully.<br/><br/>Please proceeed to log back into your account to view the changes.</p>";

                myProfileView.InnerHtml += "</div>";
                myProfileView.InnerHtml += "<div class='card-action'> ";
                myProfileView.InnerHtml += "<a href='Login.aspx' class='btn waves-effect waves-light'>Continue</a> ";
                myProfileView.InnerHtml += "<a href='Default.aspx' class='btn waves-effect waves-light orange lighten-2'>Cancel</a> ";
                myProfileView.InnerHtml += "</div>";
                myProfileView.InnerHtml += "</div>";
                myProfileView.InnerHtml += "</div>";

                Response.Redirect("Index.aspx");
            }
            else
            {
                Session["User"] = null;

                myProfileView.InnerHtml = "<div class='col s12 m6 push-m3'>";
                myProfileView.InnerHtml += "<div class='card white'>";
                myProfileView.InnerHtml += "<div class='card-content Black-text'>";
                myProfileView.InnerHtml += "<span class='card-title bold'>Oh No...An Error Occured</span>";
                myProfileView.InnerHtml += "<p>Unfortunately we were unable to update your account.<br/><br/>As a precaution, please log back into your account where you may try again.</p>";

                myProfileView.InnerHtml += "</div>";
                myProfileView.InnerHtml += "<div class='card-action'> ";
                myProfileView.InnerHtml += "<a href='Login.aspx' class='btn waves-effect waves-light'>Continue</a> ";
                myProfileView.InnerHtml += "<a href='Default.aspx' class='btn waves-effect waves-light orange lighten-2'>Cancel</a> ";
                myProfileView.InnerHtml += "</div>";
                myProfileView.InnerHtml += "</div>";
                myProfileView.InnerHtml += "</div>";
            }
        }
    }
}