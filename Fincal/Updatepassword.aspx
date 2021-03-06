﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Updatepassword.aspx.cs" Inherits="Fincal.Updatepassword" %>
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
                <div id="updatepc" class="card-content black-text" runat="server">
                    <!--Card Information-->
                    <span id="lblup" class="card-title" runat="server">Update Password</span>

                    <div id="invalidp" class="row red-text text-lighten-2" runat="server">

                    </div>
              
                    <div class="row">
                        <div class="input-field col s12">
                            <input id="txte" type="email" class="validate black-text" runat="server" autofocus/> 
                            <label for="txte">Email address</label>
                        </div>
                    </div>

                    <div class="row">
                        <div class="input-field col s12">
                            <input id="txtop" type="password" class="validate black-text" runat="server"/> 
                            <label for="txtop">Current password</label>
                        </div>
                    </div>

                    <div class="row">
                        <div class="input-field col s12">
                            <input id="txtnp" type="password" class="validate black-text" runat="server"/> 
                            <label for="txtnp">New password</label>
                        </div>
                    </div>

                    <div class="row">
                        <div class="input-field col s12">
                            <input id="txtnpc" type="password" class="validate black-text" runat="server"/> 
                            <label for="txtnpc">Confirm new password</label>
                        </div>
                    </div>

                    <div class="row">
                        <button id="btnupdatepass" type="submit" class="btn waves-effect waves-light" runat="server" onserverclick="btnupdate_ServerClick"><i class="material-icons prefix">save</i>Update</button>
                        <a href="MyProfile.aspx" runat="server"  class="waves-effect waves-light btn red"><i class="material-icons prefix">cancel</i>Cancel</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
