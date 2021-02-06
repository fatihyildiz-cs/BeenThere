$(document).ready(function () {
    initMap();
});

function initMap() {
    const map = new google.maps.Map(document.getElementById("map"), {
        center: currentPlace,
        zoom: 11
    });
    var marker = new google.maps.Marker({ position: currentPlace, map: map });

    var contentString;

    contentString = '<div id="content">' +


        '<p>' + '@Model.Location.Name ' + '<hr> <a href="' + "@Model.Location.GoogleMapsUrl" + '">' +
        'View </a>this place on Google Maps' +
        '</div>';



    var infoWindow = new google.maps.InfoWindow({
        content: contentString
    });

    marker.addListener('click', function () {
        map.setZoom(15);
        map.setCenter(marker.getPosition());
        infoWindow.open(map, marker);

    });

}
