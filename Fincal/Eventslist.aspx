<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Eventslist.aspx.cs" Inherits="Fincal.Eventslist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagecontent" runat="server">
     <div class="row">
          <div class="col s12 m10 l8">
            <h4 id="indexTitle" class="bold" runat="server">Events</h4>
        </div>  
     
   
    </div>

      <div class="row"  id="upev" runat="server">

  
    </div>
    <div class="row">
     <div id="floatingeventcreateButton" class="fixed-action-btn " style="bottom: 45px; right: 24px;" runat="server" visible="true">
            <a class="btn-floating btn-large teal waves-effect waves-light moda" href="Eventcreate.aspx">
              <i class="large material-icons">add</i>
            </a>
        </div>
        </div>
</asp:Content>
