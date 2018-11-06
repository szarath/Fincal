<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Issueview.aspx.cs" Inherits="Fincal.Issueview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagecontent" runat="server">

            <div id="regCard" runat="server" class="row">
        <div class="col s12 m10 l8 push-m1 push-l2">
          <div class="card white">
            <div class="card-content black-text">
              <span class="card-title bold">Accept/Reject Projects</span>
                
                <div id="invalidRegister" class="row red-text text-lighten-2" runat="server">

                </div>
                         <div class="row">
                    <div class="input-field col s12 m12 l12">
                         <i class="material-icons prefix">label_important</i>
                        <textarea readonly id="txtprojname" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtprojname">Title</label>
                    </div>
                </div>
                          <div class="row">
                    <div  disabled  class="input-field col s12 m12 l12">
                         <i class="material-icons prefix">title</i>
                        <textarea readonly id="txtisstitle" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtisstitle">Title</label>
                    </div>
                </div>

                 <div class="row">
                    <div disabled  class="input-field col s12 m12 l12">
                         <i class="material-icons prefix">description</i>
                        <textarea readonly id="txtissdesc" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtissdesc">Description</label>
                    </div>
                </div>

                <div class="row">
                    <div disabled class="input-field col s12 m12 l12">
                        <i class="material-icons prefix">account_circle</i>
                        <textarea readonly id="txtprojleader" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtprojleader">Project Leader</label>
                    </div>
                </div>
                          

                        </div>
              <div class="card-action">


           <a href="Default.aspx" runat="server"  class="waves-effect waves-light btn"><i class="material-icons left">home</i>Home</a>
               <a href="Issues.aspx" runat="server"  class="waves-effect waves-light btn red"><i class="material-icons left">notification_important</i>Issues</a>

              </div>

          </div>
        </div>
    </div>
</asp:Content>
