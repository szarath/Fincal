<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Allpictures.aspx.cs" Inherits="Fincal.Allpictures" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagecontent" runat="server">

       <div class="row">
          <div class="col s12 m10 l8 push-m1 push-l2">
            <h4 id="indexTitle" class="bold" runat="server">Pictures</h4>
        </div>  
     
   
    </div>
  


      

    
                <div class="row">
                 
                   <div class="card">
                        <div id="picturecarousel" class="col" runat="server">
                          

                        </div>
                     </div>


                        </div>

      <div class="row">
     <div id="floatingpictureaddButton" class="fixed-action-btn " style="bottom: 45px; right: 24px;" runat="server" visible="true">
            <a class="btn-floating btn-large teal waves-effect waves-light" href="Pictureadd.aspx">
              <i class="large material-icons">add</i>
            </a>
        </div>
        </div>


</asp:Content>
