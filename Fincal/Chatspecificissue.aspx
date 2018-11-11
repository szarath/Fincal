<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Chatspecificissue.aspx.cs" Inherits="Fincal.Chatspecificissue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagecontent" runat="server">
           <style>
        .thumb 
        {
            height: 75px;
            margin: 10px 5px 0 0;
        }
    </style>
        <div class="row" id="chatdiv" runat="server">
        <div class="col s12 m10 l8 push-m1 push-l2">
          <div class="card white">
            <div class="card-content black-text">
              <span class="card-title">Chat</span>
              
                <div id="Invlaidproject" runat="server" class="row red-text text-lighten-2">

                </div>

                  <div class="row">
                    <div class="input-field col s12 m12 l12 ">


                         <i class="material-icons prefix">chat</i>


                        <textarea  readonly id="txtmsg" class="materialize-textarea scrollspy" runat="server"></textarea>


                        <label id="lblidname" for="txtmsg" runat="server"></label>
                    </div>
                </div>

                
                 
            </div>


            <div class="card-action">
                 <div class="row">
                    <div class="input-field col s12 m12 l12">
                         <i class="material-icons prefix">send</i>
                        <textarea  id="txtsend" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtsend">Message</label>
                    </div>
                </div>
              <button id="btnsendchat" class="btn waves-effect waves-light" runat="server" onserverclick="btnsendchat_ServerClick"><i class="material-icons left">send</i>Add</button>
                      <a href="Projects.aspx" class="waves-effect waves-light btn blue"><i class="material-icons left">assignment</i>Projects</a>
                      
              <a href="Chatall.aspx" class="waves-effect waves-light btn orange"><i class="material-icons left">chat</i>Chats</a>
            </div>
          </div>
        </div>
      </div>
</asp:Content>
