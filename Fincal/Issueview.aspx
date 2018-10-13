<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Issueview.aspx.cs" Inherits="Fincal.Issueview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagecontent" runat="server">

            <div id="regCard" runat="server" class="row">
        <div class="col s12 m10 l8 push-m1 push-l2">
          <div class="card white">
            <div class="card-content black-text">
              <span class="card-title bold">Register a New Account</span>
                
                <div id="invalidRegister" class="row red-text text-lighten-2" runat="server">

                </div>
                        
                          <div class="row">
                    <div  disabled  class="input-field col s12 m12 l12">
                         <i class="material-icons prefix">title</i>
                        <textarea id="txtprojt" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtprojt">Title</label>
                    </div>
                </div>

                 <div class="row">
                    <div disabled  class="input-field col s12 m12 l12">
                         <i class="material-icons prefix">description</i>
                        <textarea id="txtprojd" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtprojd">Description</label>
                    </div>
                </div>

                <div class="row">
                    <div disabled class="input-field col s12 m12 l12">
                        <i class="material-icons prefix">account_circle</i>
                        <textarea id="txtptojectmember" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtptojectmember">Project Leader</label>
                    </div>
                </div>
                          

                        </div>
              <div class="card-action">


  <a href="#" runat="server" class="btn waves-effect waves-light" onserverclick="btnacceptproject_ServerClick">Accept</a>
               <a href="Login.aspx" runat="server"  class="waves-effect waves-light btn red">Cancel</a>

              </div>

          </div>
        </div>
    </div>
</asp:Content>
