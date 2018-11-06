<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Issues.aspx.cs" Inherits="Fincal.Issues" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagecontent" runat="server">
    <div class="container">
      <div class="row">
          <div class="col s12 m10 l8">
            <h4 id="indexTitle" class="bold" runat="server">Issues</h4>
        </div>  
     
   
    </div>

          <div class =" row">

         
         
         <h4 id="H6" class="thin col m10 s12 " runat="server">Your Project Issues</h4> 

          </div>


<div id="yourprojects" class="row" runat="server">
  
    </div>
        
 
   
       
   

        <div class =" row">
      <h4 class="thin col m10 s12 " runat="server">Other Project Issues</h4> 
            </div>


   <div id="otherprojects" class="row" runat="server">
   
     </div>

        <div class =" row">
      <h4 class="thin col m10 s12 " runat="server">Flagged Issues</h4> 
            </div>
 <div id="flagged" class="row" runat="server">
   
     </div>
        
  
    <div class="row">
    <div id="floatingissuecreateButton" class="fixed-action-btn " style="bottom: 45px; right: 24px;" runat="server" visible="true">
            <a class="btn-floating btn-large teal waves-effect waves-light moda" href="Issuereport.aspx">
              <i class="large material-icons">add</i>
            </a>
        </div>
        </div>
    </div>
</asp:Content>
