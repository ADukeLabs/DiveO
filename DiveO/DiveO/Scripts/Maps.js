var initialLocation;
var browserSupportFlag = new Boolean();

function initialize() {
    var mapOptions = {
        center: new google.maps.LatLng(0, 0),
        zoom: 4
    };
    var map = new google.maps.Map(document.getElementById("mapDiv"), mapOptions);

    if (navigator.geolocation) {
        browserSupportFlag = true;
        navigator.geolocation.getCurrentPosition(function (position) {
            initialLocation = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
            map.setCenter(initialLocation);
        }, function () {
            handleNoGeolocation(browserSupportFlag);
        });
    }
}
google.maps.event.addDomListener(window, "load", initialize);