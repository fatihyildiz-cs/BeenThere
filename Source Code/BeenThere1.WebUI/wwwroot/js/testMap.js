
$(document).ready(function () {
    initMap();
});

function initMap() {
    var uluru = { lat: -25.344, lng: 131.036 };
    var uluru2 = { lat: -35.344, lng: 121.036 };
    var uluru3 = { lat: -45.344, lng: 111.036 };
    var uluru4 = { lat: -55.344, lng: 101.036 };
    var uluru5 = { lat: -65.344, lng: 91.036 };
    var uluru6 = { lat: -30.344, lng: 91.036 };
    var map = new google.maps.Map(
        document.getElementById('map'), { zoom: 4, center: uluru });

    var marker = new google.maps.Marker({ position: uluru, map: map });
    var marker = new google.maps.Marker({ position: uluru2, map: map });
    var marker = new google.maps.Marker({ position: uluru3, map: map });
    var marker = new google.maps.Marker({ position: uluru4, map: map });
    var marker = new google.maps.Marker({ position: uluru5, map: map });
    var marker = new google.maps.Marker({ position: uluru6, map: map });

}