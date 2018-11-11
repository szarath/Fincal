<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Chatall.aspx.cs" Inherits="Fincal.Chatall" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagecontent" runat="server">

     <div class="container">
      <div class="row">
          <div class="col s12 m10 l8">
            <h4 id="indexTitle" class="bold" runat="server">Chats</h4>
        </div>  
    </div>
          <div class =" row">

         
         
         <h5 id="H4" class="thin col m10 s12 " runat="server">Project chats</h5> 

          </div>


        <div id="Projects" class="row" runat="server">
  
         </div>
        
 
   
       
   

        <div class =" row">
      <h5 class="thin col m10 s12 " runat="server">Issue chats</h5> 
            </div>


   <div id="Issues" class="row" runat="server">
   
     </div>
 
        
  
   <!-- <div class="row">
     <div id="floatingprojectcreateButton" class="fixed-action-btn " style="bottom: 45px; right: 24px;" runat="server" visible="true">
            <a class="btn-floating btn-large teal waves-effect waves-light moda" href="Projectadd.aspx">
              <i class="large material-icons">add</i>
            </a>
        </div>
        </div>-->



         </div>
</asp:Content>
