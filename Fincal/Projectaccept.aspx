<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Projectaccept.aspx.cs" Inherits="Fincal.Projectaccept" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagecontent" runat="server">

          <div id="projacc" runat="server" class="row">
        <div class="col s12 m10 l8 push-m1 push-l2">
          <div class="card white">
            <div class="card-content black-text">
              <span class="card-title bold">Accept/Reject Projects</span>
                
                <div id="invalidRegister" class="row red-text text-lighten-2" runat="server">

                </div>
                        
                          <div class="row">
                    <div    class="input-field col s12 m12 l12">
                         <i class="material-icons prefix">title</i>
                        <textarea readonly id="txtprojt" class="materialize-textarea bold" runat="server"></textarea>
                        <label for="txtprojt">Title</label>
                    </div>
                </div>

                 <div class="row">
                    <div   class="input-field col s12 m12 l12">
                         <i class="material-icons prefix">description</i>
                        <textarea readonly id="txtprojd" class="materialize-textarea bold" runat="server"></textarea>
                        <label for="txtprojd">Description</label>
                    </div>
                </div>
                  <div class="row">

                

                      <div  class="input-field col s12 m12 l12">
                        <i class="material-icons prefix">email</i>
                        <textarea readonly id="txtexp" class="materialize-textarea bold" runat="server"></textarea>
                        <label for="txtexp">Project Invite Expiry Date</label>
                     </div>

                </div>
                <div class="row">

                    <div  class="input-field col s12 m6 l6">
                        <i class="material-icons prefix">supervisor_account</i>
                        <textarea readonly id="txtptojectleaderuname" class="materialize-textarea bold" runat="server"></textarea>
                        <label for="txtptojectleaderuname">Project Leader Username</label>
                    </div>

                      <div  class="input-field col s12 m6 l6">
                        <i class="material-icons prefix">email</i>
                        <textarea readonly id="txtptojectleaderemail" class="materialize-textarea bold" runat="server"></textarea>
                        <label for="txtptojectleaderemail">Project Leader Email</label>
                     </div>

                </div>

               
                          

                        </div>
              <div class="card-action">


  
                  <a href="#AcceptUpdate" class="btn waves-effect waves-light modal-trigger"><i class="material-icons left">save</i>Accept</a>
                            <a href="#AcceptDelete" class="btn red waves-effect waves-light modal-trigger"><i class="material-icons left">not_interested</i>Reject</a>
              </div>

          </div>
        </div>
    </div>


         <div class="modal" id="AcceptUpdate">
                            <div class="modal-content">
                              <h4>Confirm Accept</h4>
                              <p>Are you sure you wish to be a part of this project?</p>
                            </div>
                            <div class="modal-footer">
                              <a runat="server" OnServerClick="btnacceptproject_ServerClick" class="modal-action modal-close waves-effect waves-green btn-flat green-text">Yes I'm Sure</a>
                              <a href="#" class="modal-action modal-close waves-effect waves-orange btn-flat orange-text lighten-2">Cancel</a>
                            </div>
                      </div>

     <div class="modal" id="AcceptDelete">
                            <div class="modal-content">
                              <h4>Confirm cancellation</h4>
                              <p>Are you sure you wish to not be a part of this project?</p>
                            </div>
                            <div class="modal-footer">
                              <a  runat="server" OnServerClick="btncancelprojnotification_Click" class="modal-action modal-close waves-effect waves-red btn-flat red-text">Yes I'm Sure</a>
                              <a href="#" class="modal-action modal-close waves-effect waves-green btn-flat green-text">Cancel</a>
                            </div>
                      </div>
</asp:Content>
