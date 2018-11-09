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
        private string projid;
        private object[] projdetails;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                UserData user = (UserData)Session["User"];
                if (!IsPostBack)
                {
                    id = Request.QueryString.Get("id");
                    Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
                    findata.Open();

                    object[] issdetails = findata.getspecificissflag(id);

                    if (issdetails != null)
                    {
                        projdetails = findata.getprojectdetails((string)issdetails[5]);
                        projid = (string)issdetails[5];
                        txtprojname.Value = (string)projdetails[1];
                        txtruser.Value = (string)issdetails[1];
                        txtisstitle.Value = (string)issdetails[3];
                        txtissdesc.Value = (string)issdetails[4];
                    }

                    object[] projmembers = findata.getprojectmembers(projid);
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
                                UserChoose.Items.Add(new ListItem(" " + priority(eventcount).ToString() + "     " + (string)getmemberdetails[1] + "     " + (string)getmemberdetails[2] + " ", (string)projmembers[i].ToString()));

                            }

                        }



                    }


                    findata.Close();
                }
                else
                {
                    Response.Redirect("Issues.aspx");

                }
            }
            else
            {
                Response.Redirect("Login.aspx");

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
        protected void btnissueadd_ServerClick(object sender, EventArgs e)
        {
            Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
            findata.Open();
            UserData user = (UserData)Session["User"];
 


            if (txtisstitle.Value.Equals("") || txtissdesc.Value.Equals("") || UserChoose.Items[UserChoose.SelectedIndex].Text.Equals("") || LevelDrop.Items[LevelDrop.SelectedIndex].Text.Equals("Choose Level"))
            {
                Invlaidproject.InnerHtml = "*Please make sure you have filled in all the fields<br/>";
                return;
            }
            else
            {

                int result = findata.createissue(txtisstitle.Value, txtissdesc.Value, projid.ToString(), LevelDrop.Items[LevelDrop.SelectedIndex].Text.ToString() ,user.getID(),DateTime.Now);
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
                    findata.deleteissflag(id);
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