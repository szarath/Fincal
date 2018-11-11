using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fincal
{
    public partial class Chatspecific : System.Web.UI.Page
    {
        string id;
        Object[][] chatdata;
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
                    
                     Title = "Project Chat";
              
                   
                }
               
            
                 findata.Open();
                    chat.Open();
              

                

                projdetails = findata.getprojectdetails(id);
                lblidname.InnerHtml = "Project : " + (string)projdetails[1];
                chatdata = chat.getprojchat(id);

                


                if (chatdata != null)
                {
                    for (int i = 0; i < chatdata.Length; i++)
                    {
                    



                        if ((string)chatdata[i][0] == user.getID())
                        {
                            txtmsg.InnerText += Environment.NewLine;

                            txtmsg.InnerText += (string)chatdata[i][2];
                            txtmsg.InnerText += Environment.NewLine;


                        }
                        else {
                            txtmsg.InnerText += Environment.NewLine;
                            txtmsg.InnerText += "                                " + (string)chatdata[i][1].ToString().ToUpper();
                            txtmsg.InnerText += Environment.NewLine;
                            txtmsg.InnerText += "                                " + (string)chatdata[i][2];
                            txtmsg.InnerText += Environment.NewLine;

                        }


                    }
                }
                else
                {


                }



                txtmsg.InnerHtml += messageformat;

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


                int result = chat.insertprojchat(txtsend.Value.ToString(), id, user.getID());
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