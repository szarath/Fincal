<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Meetingview.aspx.cs" Inherits="Fincal.Meetingview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagecontent" runat="server">
          <div class="row" id="projectdiv" runat="server">
        <div class="col s12 m10 l8 push-m1 push-l2">
          <div class="card white">
            <div class="card-content black-text">
              <span class="card-title">Meeting Details</span>
              
                <div id="Invlaidproject" runat="server" class="row red-text text-lighten-2">

                </div>
                <div class="row">
                 <div class="input-field col s12 m12 l12">
                         <i class="material-icons prefix">assignment</i>
                        <textarea readonly id="txtprojname" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtprojname">Project</label>
                    </div>
                      </div>
                  <div class="row">
                    <div class="input-field col s12 m12 l12">
                         <i class="material-icons prefix">title</i>
                        <textarea readonly id="txtprojt" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtprojt">Meeting title</label>
                    </div>
                </div>

                 <div class="row">
                    <div class="input-field col s12 m12 l12">
                         <i class="material-icons prefix">description</i>
                        <textarea readonly id="txtprojd" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtprojd">Meeting description</label>
                    </div>
                </div>

                <div class="row">
                     <div class="input-field col s12 m12 l12">
                         <i class="material-icons prefix">date_range</i>
                        <textarea readonly id="Textarea1" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtprojd">Meeting date</label>
                    </div>

                </div>


                          </div>   
            <div class="card-action">
              <button id="btnmeetdelete" class=" red btn waves-effect waves-light" runat="server" onserverclick="btnmeetdel_ServerClick"><i class="material-icons left">delete</i>Delete</button>
              <a href="Meeting.aspx" class="waves-effect waves-light btn orange"><i class="material-icons left">cancel</i>Cancel</a>
            </div>
         
        </div>
      </div>
              </div>

</asp:Content>
