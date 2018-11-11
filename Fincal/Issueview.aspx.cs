using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fincal
{
    public partial class Issueview : System.Web.UI.Page
    {  string htmldata;
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Issue Details";

            UserData user = (UserData)Session["User"];
            Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
          
            if (!IsPostBack)
            {
                string id = Request.QueryString.Get("id");
                findata.Open();
                object[] issdetails = findata.getissuedetails(id);

                if (issdetails != null)
                {
                    object[] projdetails = findata.getprojectdetails((string)issdetails[3]);


                    txtprojname.Value = (string)projdetails[1];

                    object[] userdetails = findata.getspecificuserinformation((string)projdetails[3]);

                    txtprojleader.Value = (string)userdetails[1];

                    txtissdesc.Value = (string)issdetails[2];

                    txtisstitle.Value = (string)issdetails[1];

                    object[][] issmembers = findata.issueteam((string)issdetails[0]);

                    if (issmembers != null)
                    {
                        for (int i = 0; i < issmembers.Length; i++)
                        {
                            Object[][] userevents = findata.getalluserevents((string)issmembers[i][0]);
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

                            htmldata += "<li class=\"collection-item\"><span style=\"font-weight:bold\">Schedule: " + priority(eventcount).ToString() + "&nbsp&nbsp&nbsp       Username: " + (string)issmembers[i][1] + "&nbsp&nbsp&nbsp      Email: " + (string)issmembers[i][2] + "</span></li>";

                        }
                        
                    }

                    else
                    {
                        htmldata += "<li class=\"collection-item\"><span style=\"font-weight:bold\">No memebrs yet</span></li>";
                    }

                }
                membersonissue.InnerHtml += htmldata;




               findata.Close();
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
        protected void btnDeletefromteam_ServerClick(object sender, EventArgs e)
        {
            string id = Request.QueryString.Get("id");
            UserData user = (UserData)Session["User"];
            Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
            Chatmanagement.ChatClient chat = new Chatmanagement.ChatClient();
            findata.Open();
            chat.Open();

            chat.deleteisschatuser(user.getID());
           int result= findata.deleteassiguserformissue(user.getID(), id);


            findata.Close();
            chat.Close();

            if(result == 1)
            {

                Response.Redirect("Issues.aspx");


            }
        }
    }
}