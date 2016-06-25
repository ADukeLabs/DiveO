var initialLocation;
var southPacific = new google.maps.LatLng(-20.170303, -159.959026);
var browserSupportFlag = new Boolean();

function CreateDiveMap() {

    var mapOptions = {
        zoom: 12,
        center: initialLocation
    };
    var mapObject = new google.maps.Map(document.getElementById("mapDiv"), mapOptions);

    if (navigator.geolocation) {
        browserSupportFlag = true;
        navigator.geolocation.getCurrentPosition(function (position) {
            initialLocation = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
            mapObject.setCenter(initialLocation);
        }, function () {
            handleNoGeolocation(browserSupportFlag);
        });
    }

    else {
        browserSupportFlag = false;
        handleNoGeolocation(browserSupportFlag);
    }

    function handleNoGeolocation(errorFlag) {
        if (errorFlag == true) {
            alert("Geolocation Service Failed");
        } else {
            alert("Your browser doesn't support geolocation. We've placed you in the South Pacific");
            initialLocation = southPacific;
        }
        mapObject.setCenter(initialLocation);
    }

    var circle = new google.maps.circle({
        center: initialLocation,
        radius: position.coords.accuracy,
        map: mapObject,
        fillColor: '#0000FF',
        fillOpacity: 0.5,
        strokeColor: '#0000FF',
        strokeOpacity: 1.0
    });

    mapObject.fitBounds(circle.getBounds());
}

function DiveLatLng() {

    var Latitude = initialLocation.coords.latitude;
    var Longitude = initialLocation.coords.longitude;

    var url = "http://localhost:52737/Dive/Create/";

    $.ajax({
        type: 'POST',
        url: url,
        data: {'lat': Latitude, 'lng': Longitude},
        success: function () {
            alert: "Data sent successfully";
        },
        error: function(){
            alert: "Error: data not sent successully";
        }
    });
}

function mapForDiveDetails() {

    //var diveSite = new google.maps.LatLng(southPacific);

    var mapOptions = {
        zoom: 12,
        center: southPacific
    };
    
    //var marker = new google.maps.Marker({
    //    position: diveSite,
    //    map: map
    //});

    var map = new google.maps.Map(document.getElementById("map"), mapOptions);
}

google.maps.event.addDomListener(window, "load", CreateDiveMap);
google.maps.event.addDomListener(window, "load", mapForDiveDetails);