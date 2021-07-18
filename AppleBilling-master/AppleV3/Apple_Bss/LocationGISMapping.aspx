<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LocationGISMapping.aspx.cs" Inherits="Apple_Bss.LocationGISMapping" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <div>
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>SymBios Office POP</asp:ListItem>
            </asp:DropDownList>

             <asp:DropDownList ID="DropDownList2" runat="server">
                 <asp:ListItem>User Location 1001</asp:ListItem>
            </asp:DropDownList>


            <asp:Button ID="Button1"  runat="server" Text="Display Mapped Details" OnClick="Button1_Click" />


        </div>
    <div>
 



    <script type="text/javascript">

      


 function DisplayRouteDynamicRoutes() {

                  var markers = [
            {
                "title": '<%=location1Title%>',
                "lat": <%=location1Lat%>,
                "lng": <%=location1Long%>,
                "description": '<%=location1Description%>'
                            }
        
    
        ,
          {
                "title": '<%=location2Title%>',
                "lat": <%=location2Lat%>,
                "lng": <%=location2Long%>,
                "description": '<%=location2Description%>'
                            }
                    ];


            var mapOptions = {
                center: new google.maps.LatLng(markers[0].lat, markers[0].lng),
                zoom: 10,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            var map = new google.maps.Map(document.getElementById("dvMap"), mapOptions);
            var infoWindow = new google.maps.InfoWindow();


            var lat_lng = new Array();
            var latlngbounds = new google.maps.LatLngBounds();
            for (i = 0; i < markers.length; i++) {
                var data = markers[i]
                var myLatlng = new google.maps.LatLng(data.lat, data.lng);
                lat_lng.push(myLatlng);
                var marker = new google.maps.Marker({
                    position: myLatlng,
                    map: map,
                    title: data.title
                });




                latlngbounds.extend(marker.position);
                (function (marker, data) {
                    google.maps.event.addListener(marker, "click", function (e) {
                        infoWindow.setContent(data.description);
                        infoWindow.open(map, marker);
                    });
                })(marker, data);
            }
            map.setCenter(latlngbounds.getCenter());
            map.fitBounds(latlngbounds);

            //***********ROUTING****************//

            //Intialize the Path Array
            var path = new google.maps.MVCArray();

            //Intialize the Direction Service
            var service = new google.maps.DirectionsService();

            //Set the Path Stroke Color
            var poly = new google.maps.Polyline({ map: map, strokeColor: '#4986E7' });

            //Loop and Draw Path Route between the Points on MAP
            for (var i = 0; i < lat_lng.length; i++) {
                if ((i + 1) < lat_lng.length) {
                    var src = lat_lng[i];
                    var des = lat_lng[i + 1];
                    path.push(src);
                    poly.setPath(path);
                    service.route({
                        origin: src,
                        destination: des,
                        travelMode: google.maps.DirectionsTravelMode.DRIVING
                    }, function (result, status) {
                        if (status == google.maps.DirectionsStatus.OK) {
                            for (var i = 0, len = result.routes[0].overview_path.length; i < len; i++) {
                                path.push(result.routes[0].overview_path[i]);
                            }
                        }
                    });
                }
            }
        }
    </script>
    <div id="dvMap" style="width: 100%; height: 700px">
    </div>
    </div>

           <script src="http://maps.googleapis.com/maps/api/js?key=AIzaSyD0X4v7eqMFcWCR-VZAJwEMfb47id9IZao" type="text/javascript"></script>

         

    </form>
</body>
</html>
