<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Updateemail.aspx.cs" Inherits="Fincal.Updateemail" %>
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
    <div class="row">
        <div class="col s12 m6 l4 push-l4 push-m3">
            <div class="card white">
                <div id="updatec" class="card-content black-text" runat="server">
                    <!--Card Information-->
                    <span id="lblupdateemail" class="card-title" runat="server">Update Email Address</span>

                    <div id="invalide" class="row red-text text-lighten-2" runat="server">

                    </div>
              
                    <div class="row">
                        <div class="input-field col s12">
                            <input id="txtoe" type="email" class="validate black-text" runat="server" autofocus/> 
                            <i class="material-icons prefix">email</i>
                            <label for="txtoe">Current Email</label>
                                   <blockquote>Type in your current email</blockquote>
                        </div>
                    </div>

                    <div class="row">
                        <div class="input-field col s12">
                              <i class="material-icons prefix">email</i>
                            <input id="txtne" type="email" class="validate black-text" runat="server"/> 
                            <label for="txtne">New Email</label>
                                   <blockquote>Type in your new email</blockquote>
                        </div>
                    </div>

                    <div class="row">
                        <div class="input-field col s12">
                              <i class="material-icons prefix">email</i>
                            <input id="txtnec" type="email" class="validate black-text" runat="server"/> 
                            <label for="txtnec">Confirm New Email</label>
                                   <blockquote>Retype email to confirm</blockquote>
                        </div>
                    </div>

                    <div class="row">
                        <div class="input-field col s12">
                                <i class="material-icons prefix">vpn_key</i>
                            <input id="txtpass" type="password" class="validate black-text" runat="server"/> 
                            <label for="txtpass">Your Password</label>
                            <blockquote>Type in your current password</blockquote>
                        </div>
                    </div>

                    <div class="row">
                        <button id="btnuodate" type="submit" class="btn waves-effect waves-light" runat="server" onserverclick="btnemailupdate_ServerClick"><i class="material-icons prefix">save</i>Update</button>
                        <a href="Myprofile.aspx" runat="server"  class="waves-effect waves-light btn red"><i class="material-icons prefix">cancel</i>Cancel</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
