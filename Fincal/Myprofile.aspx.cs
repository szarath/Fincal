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
        private object[] skills;
        private string htmldata;
        private string link= null;
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
                    txtgithublink.Value = user.getGitlink();

                    Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
                    findata.Open();

                    skills = findata.getskills();





                 
                        for (int i = 0; i < skills.Length; i++)
                        {
                            skilldrop.Items.Add(new ListItem((string)skills[i], i.ToString()));

                        }

                    skilldrop.SelectedIndex = Convert.ToInt32( user.getSkill().ToString());

                    findata.Close();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void btnDeleteAcc_Click(object sender, EventArgs e)
        {
            user = (UserData)(Session["User"]);
            Userservice.UserserviceClient service = new  Userservice.UserserviceClient();
            Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
            Chatmanagement.ChatClient chat = new Chatmanagement.ChatClient();
            service.Open();
            findata.Open();
            chat.Open();

            Object[][] getuserprojects = findata.getprojects(user.getID());
                if(getuserprojects != null)
                     {
                for (int j = 0; j < getuserprojects.Length; j++)
                {
                    string pid = (string)getuserprojects[j][0];
                    int team = findata.deleteprojteam(pid);
                    int delete = findata.deleteallprojnotificaion(pid);
                    int deleteprojchat = chat.deleteprojchat(pid);
                    int deltepissflags = findata.deleteissflagproj(pid);
                    object[] getmeetingid = findata.getprojmeetings(pid);

                    if (getmeetingid != null)
                    {

                        for (int i = 0; i < getmeetingid.Length; i++)
                        {
                            int meetmemdel = findata.deletemeetingmembers((string)getmeetingid[i]);

                            if (meetmemdel == 1)
                            {
                                findata.deletemeeting((string)getmeetingid[i]);

                            }


                        }
                    }



                    object[][] getprojiss = findata.getprojissues(pid);

                    if (getprojiss != null)
                    {
                        for (int i = 0; i < getprojiss.Length; i++)
                        {
                            object[] issnotice = findata.getissnoticeiss((string)getprojiss[i][0]);
                            if (issnotice != null)
                            {
                                findata.deleteissnoticeiss((string)getprojiss[i][0]);
                            }
                            chat.deleteissuechat((string)getprojiss[i][0]);

                            findata.deleteissue((string)getprojiss[i][0]);




                        }
                    }


                    int proj = findata.deleteproject(pid);
                  


                }

               


               
            }
            int projchat = chat.deleteprojchatuser(user.getID());
            int isschat = chat.deleteisschatuser(user.getID());
            int meetinglinks = findata.deleteuserfrommeetinglink(user.getID());
            int projteams = findata.deleteuserfromprojteams(user.getID());
            int issteams = findata.deleteuserfromissteams(user.getID());
            int issflag = findata.deleteuserfromisflags(user.getID());
                int deletedvents = findata.deletealluserevents(user.getID());

                int deletetasks = findata.deleteallusertasks(user.getID());
            int deletepic = findata.deleteallpictures(user.getID());


            int result = service.deleteUser(user.getID());
           
            if (result == 1)//if the result is one then the user is deleted and redirected to the index page 
            {
                Session["User"] = null;
                //Response.Write("<script>alert('User Account Deleted!');</script>");
                Response.Redirect("Default.aspx");
            }

            service.Close();
            findata.Close();
            chat.Close();

        }

        protected void btnUpdateAccount_ServerClick(object sender, EventArgs e)
        {
            if (txtFirstName.Value.Equals("") || txtLastName.Value.Equals("") || txtDoB.Value.Equals(""))
            {
                invalidprof.InnerHtml = "* Fill in all the fields</br>";
             
            }
            else {
                if (txtgithublink.Value.Equals(""))
                {

                    invalidprof.InnerHtml = "*You can add a repo link later in your profile.<br/>";
                    link = "";
                }
                else if (!txtgithublink.Value.Contains("https://github.com/"))
                {
              
                    invalidprof.InnerHtml = "Your repo link is not a valid GitHub repo.<br/>";


                }
                else
                {
                    link = txtgithublink.Value.ToString();
                }
                user = (UserData)(Session["User"]);
            Userservice.UserserviceClient service = new
             Userservice.UserserviceClient();

            int skill = skilldrop.SelectedIndex;
            service.Open();

            int result = service.updateUserInfo(user.getID(), txtFirstName.Value, txtLastName.Value, Convert.ToDateTime(txtDoB.Value), skill.ToString(), link);
            service.Close();
            if (result == 1)//if the result is one then the user is deleted and redirected to the index page 
            {
                Session["User"] = null;

                htmldata = "<div class=\"col s12 m6 push-m3\">";
                htmldata += "<div class=\"card white\">";
                htmldata += "<div class=\"card-content Black-text\">";
                htmldata += "<span class=\"card-title bold\">Account Updated Successfully</span>";
                htmldata += "<p>Your account has been updated successfully.<br/><br/>Please proceeed to log back into your account to view the changes.</p>";

                htmldata += "</div>";
                htmldata += "<div class=\"card-action\"> ";
                htmldata += "<a href=\"Login.aspx\" class=\"btn waves-effect waves-light\">Continue</a> ";
                htmldata += "<a href=\"Default.aspx\" class=\"btn waves-effect waves-light orange lighten-2\">Cancel</a> ";
                htmldata += "</div>";
                htmldata += "</div>";
                htmldata += "</div>";


            }
            else
            {
                Session["User"] = null;

                htmldata = "<div class=\"col s12 m6 push-m3\">";
                htmldata += "<div class=\"card white\">";
                htmldata += "<div class=\"card-content Black-text\">";
                htmldata += "<span class=\"card-title bold\">Oh No...An Error Occured</span>";
                htmldata += "<p>Unfortunately we were unable to update your account.<br/><br/>As a precaution, please log back into your account where you may try again.</p>";

                htmldata += "</div>";
                htmldata += "<div class=\"card-action\"> ";
                htmldata += "<a href=\"Login.aspx\" class=\"btn waves-effect waves-light\">Continue</a> ";
                htmldata += "<a href=\"Default.aspx\" class=\"btn waves-effect waves-light orange lighten-2\">Cancel</a> ";
                htmldata += "</div>";
                htmldata += "</div>";
                htmldata += "</div>";


            }

            myProfileView.InnerHtml = htmldata;
        }
        }
    }
}