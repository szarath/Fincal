using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fincal
{
    public partial class Chatspecificissue : System.Web.UI.Page
    {
        string id;
        Object[][] chatdata;
        object[] issuedetails;
        object[] projdetails;
        string messageformat;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                id = Request.QueryString.Get("id");
                Dataservice.DatamanagementClient findata = new Dataservice.DatamanagementClient();
                Chatmanagement.ChatClient chat = new Chatmanagement.ChatClient();
                UserData user = (UserData)Session["User"];
                if (!IsPostBack)
                {
                    Title = "Fincal: Issue Chat";

                    findata.Open();
                    chat.Open();

                }







                issuedetails = findata.getissuedetails(id);
                projdetails = findata.getprojectdetails((string)issuedetails[3]);
                lblidname.InnerHtml = "Project : " + (string)projdetails[1] + " Issue : " + (string)issuedetails[1];
                chatdata = chat.getissuechat(id);




                if (chatdata != null)
                {
                    for (int i = 0; i < chatdata.Length; i++)
                    {




                        if ((string)chatdata[i][0] == user.getID())
                        {

                            messageformat += (string)chatdata[i][2];
                            messageformat += "----------------------------------------------------------------------------------";


                        }
                        else
                        {

                            messageformat += "                                                          " + (string)chatdata[i][1];
                            messageformat += "                                                                                  ";
                            messageformat += (string)chatdata[i][2];
                            messageformat += "----------------------------------------------------------------------------------";

                        }


                    }
                }
                else
                {


                }



                txtmsg.Value = messageformat;

                findata.Close();
                chat.Close();



            }
            
        }

        protected void btnsendchat_ServerClick(object sender, EventArgs e)
        {
            Chatmanagement.ChatClient chat = new Chatmanagement.ChatClient();
            UserData user = (UserData)Session["User"];
            chat.Open();
            if (txtsend.Equals(""))
            {
                Invlaidproject.InnerHtml += "<p>No message to send.</p>";
            }
            else
            {

            
                int result = chat.insertissuechat(txtsend.Value.ToString(), id, user.getID());
                if (result == 1)
                {
                    chat.Close();

                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                  
                }
                
                chat.Close();




            }


            chat.Close();



        }


    }
}
