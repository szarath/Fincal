<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Taskadd.aspx.cs" Async="true" Inherits="Fincal.Taskadd" %>
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
  

    <div class="row" id="taskDiv" runat="server">
        <div class="col s12 m10 l8 push-m1 push-l2">
          <div class="card white">
            <div class="card-content black-text">
              <span class="card-title">Add Task</span>
              
                <div id="Invlaidtask" runat="server" class="row red-text text-lighten-2">

                </div>

                <div class="row">
                    <div class="input-field col s6 m8 l9"> 
                        <input id="txttaskanme" type="text" class="validate autocomplete-content" runat="server"/>
                        <label for="txttaskname">Task Name</label>
                    </div>
                    <div class="input-field col s6 m4 l3">
                        <select id="PlatformDrop" runat="server">
                            <option value="" disabled selected>Choose Level</option>
                           
                        </select> 
                        <label for="PlatformDrop">Level</label>
                    </div>
                </div> 



           

         
                    
                
                 
            </div>
            <div class="card-action">
              <button id="btntaskadd" class="btn waves-effect waves-light" runat="server" onserverclick="btntaskadd_ServerClick">Add</button>
              <a href="Task.aspx" class="waves-effect waves-light btn red">Cancel</a>
            </div>
          </div>
        </div>
      </div>
</asp:Content>
