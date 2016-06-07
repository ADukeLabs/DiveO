var initialLocation;
var southPacific = new google.maps.LatLng(-20.170303, -159.959026);
var browserSupportFlag = new Boolean();

function initialize() {
    var mapOptions = {
        zoom: 12
    };
    var mapObject = new google.maps.Map(document.getElementById("mapDiv"), mapOptions);
    new google.maps.Marker({ map: mapObject, postition: initialLocation });

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
}

function DiveLatLng() {
    // data variable containing initalLocation lat and long
    var coords = {
        Latitude: new google.maps.LatLng(position.coords.latitude),
        Longitude: new google.maps.LatLng(position.coords.longitude)
    }

    $.ajax({
        type: 'POST',
        url: '/Dive/Create',
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({mapPoint: coords}),
        success: function (data) {
            alert: "Data sent successfully";
            alert: (data);
        },
        error: function(){
            alert: "Error: data not sent successully";
        }
    });
}

function DiveDetailsMap(lat,lng) {

    var diveSite = new google.maps.LatLng(lat, lng);

    var mapOptions = {
        center: diveSite,
        zoom: 12
    };
    var map = new google.maps.Map(document.getElementById("map"), mapOptions);
}

google.maps.event.addDomListener(window, "load", initialize);
google.maps.event.addDomListener(window, "load", mapForDiveDetails);