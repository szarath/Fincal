<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" Async="true" CodeBehind="Eventedit.aspx.cs" Inherits="Fincal.Eventedit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagecontent" runat="server">
    <div class="container">
    <div class="row " id="editeventDiv" runat="server">
        <div class="col s12 m10 l8 push-m1 push-l2">
          <div class="card white">
            <div class="card-content black-text">
              <span class="card-title">Edit Ad</span>
                
                <div id="InvlaideventAd" runat="server" class="row red-text text-lighten-2">

                </div>

                   




                <div class="row">
                     
                                    <div class="input-field col s12 m6 l6">
                                       <i class="material-icons prefix">today</i>
                                        <input  id="txtdoe" runat="server" class="datepicker black-text"/>
                                        <label for="txtdoe">Date of Event</label>
                                    </div>

                                     <div class="input-field col s12 m6 l6">
                                       <i class="material-icons prefix">access_time</i>
                                        <input  id="txttime" runat="server" class="timepicker black-text"/>
                                        <label for="txttime">Time of Event</label>
                                    </div>


                            </div>


               <div class="row">
                    <div class="input-field col s12 m12 l12">
                         <i class="material-icons prefix">title</i>
                        <textarea id="txtesummary" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtesummary">Title</label>
                    </div>
                </div>

               <div class="row">
                    <div class="input-field col s12 m12 l12">
                           <i class="material-icons prefix">description</i>
                        <textarea id="txtedesc" class="materialize-textarea" runat="server"></textarea>
                        <label for="txtedesc">Description</label>
                    </div>
                </div>

                <div class="row">
                    <div id="locationField" class="input-field col s12 m12 l12">
                        <i class="material-icons prefix">add_location</i>
                       <input id="txteLocation" onFocus="geolocate()" type="text" runat="server" ClientIDMode="static" placeholder=""/>
                       <label for="txteLocation">Location</label>
                    </div>
                </div>

                <div class="row">

                    <div id="carouselimage" class="carousel">



                    </div>


                </div>
               

<!-- 
              <div class="row">
                    <div class="file-field input-field col s12 m4 l4">
                          <div class="btn waves-effect waves-light">
                            <span>Pic 1</span>
                            <input id="pic1files" type="file" name="pic1files[]" ClientIDMode="static" runat="server"/>
                          </div>
                          <div class="file-path-wrapper">
                            <input  id="txtPicUpload1" type="text" class="file-path validate" placeholder="Upload Photo" runat="server"/>
                          </div>
                        <div id="pic1Thumb" runat="server" ClientIDMode="static"></div>
                     </div>
                    
                

                
                <script>
                    function handleFileSelect(evt) {
                        var pic1files = evt.target.files; // FileList object

                        // Loop through the FileList and render image files as thumbnails.
                        for (var i = 0, f; f = pic1files[i]; i++) {

                            // Only process image files.
                            if (!f.type.match('image.*')) {
                                continue;
                            }

                            var reader = new FileReader();

                            // Closure to capture the file information.
                            reader.onload = (function (theFile) {
                                return function (e) {
                                    // Render thumbnail.
                                    document.getElementById('pic1Thumb').innerHTML = ['<img class="thumb" src="', e.target.result, '" title="', escape(theFile.name), '"/>'].join('');
                                };
                            })(f);

                            // Read in the image file as a data URL.
                            reader.readAsDataURL(f);
                        }
                    }

                    document.getElementById('pic1files').addEventListener('change', handleFileSelect, false);
                </script>

                    <div class="file-field input-field col s12 m4 l4">
                          <div class="btn waves-effect waves-light">
                            <span>Pic 2</span>
                            <input id="pic2files" type="file" name="pic2files[]" ClientIDMode="static" runat="server"/>
                          </div>
                          <div class="file-path-wrapper">
                            <input id="txtPicUpload2" class="file-path validate" type="text" placeholder="Upload Photo" runat="server"/>
                          </div>
                        <div id="pic2Thumb" runat="server" ClientIDMode="static"></div>
                        </div>

                     <script>
                         function handleFileSelect(evt) {
                             var pic2files = evt.target.files; // FileList object

                             // Loop through the FileList and render image files as thumbnails.
                             for (var i = 0, f; f = pic2files[i]; i++) {

                                 // Only process image files.
                                 if (!f.type.match('image.*')) {
                                     continue;
                                 }

                                 var reader = new FileReader();

                                 // Closure to capture the file information.
                                 reader.onload = (function (theFile) {
                                     return function (e) {
                                         // Render thumbnail.
                                         document.getElementById('pic2Thumb').innerHTML = ['<img class="thumb" src="', e.target.result, '" title="', escape(theFile.name), '"/>'].join('');
                                     };
                                 })(f);

                                 // Read in the image file as a data URL.
                                 reader.readAsDataURL(f);
                             }
                         }

                         document.getElementById('pic2files').addEventListener('change', handleFileSelect, false);
                </script>







                    <div class="file-field input-field col s12 m4 l4">
                          <div class="btn waves-effect waves-light">
                            <span>Pic 3</span>
                            <input id="pic3files" type="file" name="pic3files[]" ClientIDMode="static" runat="server"/>
                          </div>
                          <div class="file-path-wrapper">
                            <input id="txtPicUpload3" class="file-path validate" type="text" placeholder="Upload Photo" runat="server"/>
                          </div>
                        
                    <div id="pic3Thumb" runat="server" ClientIDMode="static"></div>
                    </div>



                 <script>
                         function handleFileSelect(evt) {
                             var pic3files = evt.target.files; // FileList object

                             // Loop through the FileList and render image files as thumbnails.
                             for (var i = 0, f; f = pic3files[i]; i++) {

                                 // Only process image files.
                                 if (!f.type.match('image.*')) {
                                     continue;
                                 }

                                 var reader = new FileReader();

                                 // Closure to capture the file information.
                                 reader.onload = (function (theFile) {
                                     return function (e) {
                                         // Render thumbnail.
                                         document.getElementById('pic3Thumb').innerHTML = ['<img class="thumb" src="', e.target.result, '" title="', escape(theFile.name), '"/>'].join('');
                                     };
                                 })(f);

                                 // Read in the image file as a data URL.
                                 reader.readAsDataURL(f);
                             }
                         }

                         document.getElementById('pic3files').addEventListener('change', handleFileSelect, false);
                </script>
              -->

              
                   </div>
                 
           
       <div class="card-action">
              <button id="btnupdateevent" type="submit" class="btn waves-effect waves-light" runat="server" onserverclick="btnUpdateevent_ServerClick">Update</button> 
                    <a href="#AcceptDelete" class="btn waves-effect waves-light red modal-trigger"><i class="material-icons left">delete_forever</i> Delete</a> 
              <a href="Eventslist.aspx" class="waves-effect waves-light btn orange lighten-2">Cancel</a>
            </div>
     
         </div>
             </div>
     
           
    
    </div>
    
    
    <div class="modal" id="AcceptDelete" >
                            <div class="modal-content">
                              <h4>Confirm Delete</h4>
                              <p>Are you sure you wish to delete this Event?</p>
                            </div>
                            <div class="modal-footer">
                              <a href="#" runat="server" OnServerClick="btnDeleteevent_ServerClick" class="modal-action modal-close waves-effect waves-red btn-flat red-text">Yes I'm Sure</a>
                              <a href="#" class="modal-action modal-close waves-effect waves-green btn-flat green-text">Cancel</a>
                            </div>
                      </div>
       
    </div>
    
    <script>
                     // This example displays an address form, using the autocomplete feature
                     // of the Google Places API to help users fill in the information.

                     // This example requires the Places library. Include the libraries=places
                     // parameter when you first load the API. For example:
                     // <script src="https://maps.googleapis.com/maps/api/js?key=YOUR_API_KEY&libraries=places">

                     var placeSearch, autocomplete;
                     var componentForm = {
                         street_number: 'short_name',
                         route: 'long_name',
                         locality: 'long_name',
                         administrative_area_level_1: 'short_name',
                         country: 'long_name',
                         postal_code: 'short_name'
                     };

                     function initAutocomplete() {
                         // Create the autocomplete object, restricting the search to geographical
                         // location types.
                         autocomplete = new google.maps.places.Autocomplete(
            /** @type {!HTMLInputElement} */(document.getElementById('txteLocation')),
                             { types: ['geocode'] });

                         // When the user selects an address from the dropdown, populate the address
                         // fields in the form.
                         autocomplete.addListener('place_changed', fillInAddress);
                     }

                     function fillInAddress() {
                         // Get the place details from the autocomplete object.
                         var place = autocomplete.getPlace();

                         for (var component in componentForm) {
                             document.getElementById(component).value = '';
                             document.getElementById(component).disabled = false;
                         }



                         // Get each component of the address from the place details
                         // and fill the corresponding field on the form.

                         /*for (var i = 0; i < place.address_components.length; i++)
                         {
                             var addressType = place.address_components[i].types[0];
                             if (componentForm[addressType])
                             {
                                 var val = place.address_components[i][componentForm[addressType]];
                                 document.getElementById(txtGameLocation).value += val;
                             }
                         }*/
                     }

                     // Bias the autocomplete object to the user's geographical location,
                     // as supplied by the browser's 'navigator.geolocation' object.
                     function geolocate() {
                         if (navigator.geolocation) {
                             navigator.geolocation.getCurrentPosition(function (position) {
                                 var geolocation = {
                                     lat: position.coords.latitude,
                                     lng: position.coords.longitude
                                 };
                                 var circle = new google.maps.Circle({
                                     center: geolocation,
                                     radius: position.coords.accuracy
                                 });
                                 autocomplete.setBounds(circle.getBounds());
                             });
                         }
                     }
    </script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyB7eq5IZFtbXZitO0yI53upIROFqC5RBcY&libraries=places&callback=initAutocomplete"
        async defer></script>

</asp:Content>
