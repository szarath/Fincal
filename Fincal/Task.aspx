<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Task.aspx.cs" Inherits="Fincal.Task" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagecontent" runat="server">
    <div class="container">
    <div class="row">
          <div class="col s12 m10 l8 ">
            <h4 id="indexTitle" class="bold" runat="server">Tasks</h4>
        </div>
        
    </div>

      
      
    <div class =" row">

         
         
         <h5 id="H6" class="thin col m10 s12 " runat="server">Inprogress</h5> 

          </div>


<div id="taskinprogress" class="row" runat="server">
  
    </div>
        
 
   
       
   

        <div class =" row">
      <h5 class="thin col m10 s12 " runat="server">Completed</h5> 
            </div>


   <div id="completedtask" class="row" runat="server">
   
     </div>
 
        
  
       
   
       
    
   
 

     
 
 
    <div class="row">
    <div id="taskaddbtn"  class="fixed-action-btn horizontal" style="bottom: 45px; right: 24px;" runat="server" visible="true">
            <a class="btn-floating btn-large teal waves-effect waves-light " href="Taskadd.aspx">
              <i class="large material-icons">add</i>
            </a>
        </div>
        </div>
        </div>
</asp:Content>
