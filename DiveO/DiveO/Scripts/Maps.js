var initialLocation;
var middleOfOcean = new google.maps.LatLng(-20.170303, -159.959026);
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

    else {
        browserSupportFlag = false;
        handleNoGeolocation(browserSupportFlag);
    }

    function handleNoGeolocation(errorFlag) {
        if (errorFlag == true) {
            alert("Geolocation Service Failed");
        } else {
            alert("Your browser doesn't support geolocation. We've placed you in the South Pacific");
            initialLocation = middleOfOcean;
        }
        map.setCenter(initialLocation);
    }
}

function mapForDiveDetails() {
    var mapOptions = {
        center: new google.maps.LatLng(0, 0),
        zoom: 4
    };
    var map = new google.maps.Map(document.getElementById("map"), mapOptions);
}

google.maps.event.addDomListener(window, "load", initialize);
google.maps.event.addDomListener(window, "load", mapForDiveDetails);