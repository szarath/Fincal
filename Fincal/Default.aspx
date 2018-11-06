<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Fincal.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2"  ContentPlaceHolderID="pagecontent" runat="server">
    <div class="container">
        <div class="row">
          <div class="col container s12 m10 l8 ">
            <h3 id="indexTitle" class="bold" runat="server">Welcome, Please Register/Login</h3>
        </div>
        
            </div>

     <div runat="server" id="projectnotificaitonmain" class="section" visible="false">
         <div class="row">
          <div class="col s12 m10 11 ">
            <h5 id="H4" class="bold" runat="server">Projects</h5>
        </div>  
    </div>

      <div class="row"  id="newprojects" runat="server">

  
    </div>
        </div>

    
     <div runat="server" id="issuenotificaitonmain" class="section" visible="false">
         <div class="row">
          <div class="col s12 m10 11 ">
            <h5 id="H5" class="bold" runat="server">Issues</h5>
        </div>  
    </div>

      <div class="row"  id="newissues" runat="server">

  
    </div>
        </div>

    <div runat="server" id="eventmain" class="section" visible="false">
         <div class="row">
          <div class="col s12 m10 11 ">
            <h5 id="H1" class="bold" runat="server">Events</h5>
        </div>  
     
   
    </div>

      <div class="row"  id="upev" runat="server">

  
    </div>
        </div>

    <div id="taskmain" class="container section" runat="server" visible="false">
                <div class="row">
          <div class="col s12 m10 11 ">
            <h5 id="H2" class="bold" runat="server">Tasks</h5>
        </div>
        
    </div>

      
      
    <div class =" row">

         
         
         <h6 id="H6" class="thin col m10 s12 10" runat="server">Inprogress</h6> 

          </div>


<div id="taskinprogress" class="row" runat="server">
  
    </div>
        
 
   
       
   

        <div class =" row">
      <h6 class="thin col m10 s12 10" runat="server">Completed</h6> 
            </div>


   <div id="completedtask" class="row" runat="server">
   
     </div>
 



    </div>


    <div id="picturemain" class="container section" runat="server" visible="false">

          <div class="row">
          <div  class="col s12 m10 11">
            <h5 id="H3" class="bold"  runat="server">Pictures</h5>
         </div>  
         </div>
 
    
                <div class="row">
                 
                   <div class="card">
                        <div id="picturecarousel" class="col" runat="server">
                        </div>
                        </div>


                        </div>


    </div>


    <div id="collabrationmain" class="container section" runat="server" visible="false">




    </div>
        </div>
    
</asp:Content>
