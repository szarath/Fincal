<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Myprofile.aspx.cs" Inherits="Fincal.Myprofile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagecontent" runat="server">
      <div class="row" id="myProfileView" runat="server">
            <div class="col s12 m10 l8 push-m1 push-l2">
              <div class="card white">
                <div class="card-content black-text">
                  <span id="myProfileTitle" runat="server" class="card-title">My Profile</span>
              

                          <div class="row">
                                    <div class="input-field col s12 m6 l6">
                                      <input id="txtFirstName" type="text" runat="server" class="black-text"/>
                                      <label for="txtFirstName">First Name</label>
                                    </div>
                                    <div class="input-field col s6">
                                      <input id="txtLastName" type="text" runat="server" class="black-text"/>
                                      <label for="txtLastName">Last Name</label>
                                    </div>
                          </div>

                          <div class="row">
                                    <div class="input-field col s12 m6 l6">
                                        <input  id="txtDoB"  runat="server" class="datepicker black-text"/>
                                        <label for="txtDoB">Date Of Birth</label>
                                    </div>
                                       <div class="input-field col s12 m6 l6">
                                       <select id="skilldrop" runat="server">
                                      <option value="" disabled selected>Choose your option</option>
    
                                      </select>
                                     <label>Skill</label>
                                          <blockquote>Choose a skill your well versed in.</blockquote>
                                       </div>

                            </div>

                          
                       

                     </div>
                         <div class="card-action">
                  
                                    
                        <div class="row">

                                   <a href="#AcceptUpdate" class="btn waves-effect waves-light modal-trigger"><i class="material-icons left">save</i>Update Account</a>
                            <a href="#AcceptDelete" class="btn red waves-effect waves-light modal-trigger"><i class="material-icons left">delete</i>Delete Account</a>

                        </div>
                 
                </div>
              </div>
            </div>
          </div>
        
                    <div class="modal" id="AcceptUpdate">
                            <div class="modal-content">
                              <h4>Confirm Update</h4>
                              <p>Are you sure you wish to update your account details?</p>
                            </div>
                            <div class="modal-footer">
                              <a href="#" runat="server" OnServerClick="btnUpdateAccount_ServerClick" class="modal-action modal-close waves-effect waves-green btn-flat green-text">Yes I'm Sure</a>
                              <a href="#" class="modal-action modal-close waves-effect waves-orange btn-flat orange-text lighten-2">Cancel</a>
                            </div>
                      </div>

                    <div class="modal" id="AcceptDelete">
                            <div class="modal-content">
                              <h4>Confirm Delete</h4>
                              <p>Are you sure you wish to delete your account?</p>
                            </div>
                            <div class="modal-footer">
                              <a href="#" runat="server" OnServerClick="btnDeleteAcc_Click" class="modal-action modal-close waves-effect waves-red btn-flat red-text">Yes I'm Sure</a>
                              <a href="#" class="modal-action modal-close waves-effect waves-green btn-flat green-text">Cancel</a>
                            </div>
                      </div>
</asp:Content>
