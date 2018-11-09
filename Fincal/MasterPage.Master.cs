using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fincal
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {

                logInSideNav.Visible = false;
                registerSideNav.Visible = false;
                Loggedinnav.Visible = true;

                calsidenav.Visible = true;
                eventsidenav.Visible = true;
                projectsidenav.Visible = true;
                tasksidenav.Visible = true;
                issuessidenav.Visible = true;
                Allpicturesnav.Visible = true;
                myProfileSideNav.Visible = true;
                signOutSideNav.Visible = true;
                //  searchSmallTopNav.Visible = true;
                presistenicon.Visible = true;
                chatsidenav.Visible = true;
                meetingsidenav.Visible = true;



            }
            else
            {
                logInSideNav.Visible = true;
                registerSideNav.Visible = true;

                Loggedinnav.Visible = false;
                calsidenav.Visible = false;
                eventsidenav.Visible = false;
                projectsidenav.Visible = false;
                tasksidenav.Visible = false;
                issuessidenav.Visible = false;
                Allpicturesnav.Visible = false;
                myProfileSideNav.Visible = false;
                signOutSideNav.Visible = false;
                presistenicon.Visible = false;
                chatsidenav.Visible = false;
                meetingsidenav.Visible = false;

                //  searchSmallTopNav.Visible = false;
            }
        }



        protected void dropDownMenuSignOut_ServerClick(object sender, EventArgs e)
        {
            Session.Remove("User");
            Session.RemoveAll();
            Session.Abandon();
            Session.Clear();
            
            Response.Redirect("Login.aspx");
            return;
        }

        protected void btnsubmitsearch(object sender, EventArgs e)
        {
            if (!searchusers.Value.Equals(""))
            {

                Response.Redirect("Usersearch.aspx?term=" + searchusers.Value.ToString());
                return;
            }
         
        }
    }
}