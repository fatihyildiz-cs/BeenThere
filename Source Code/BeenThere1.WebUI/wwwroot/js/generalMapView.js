
"use strict";
var existingMarkers = @Html.Raw(ViewBag.markers);

let markers = [];

var existingMarkersArray = [];

let autocomplete;

const componentForm = {
    street_number: "short_name",
    route: "long_name",
    locality: "long_name",
    administrative_area_level_1: "long_name",
    country: "long_name",
    postal_code: "short_name"
};

function initMap() {
    const map = new google.maps.Map(document.getElementById("map"), {
        center: {
            lat: 40.416775,
            lng: -3.703790
        },
        zoom: 3
    });
    const card = document.getElementById("pac-card");
    const input = document.getElementById("pac-input");
    const countrySelector = document.getElementById("countrySelector");
    map.controls[google.maps.ControlPosition.TOP_RIGHT].push(card);
    map.controls[google.maps.ControlPosition.TOP_CENTER].push(countrySelector);

    autocomplete = new google.maps.places.Autocomplete(input); // Bind the map's bounds (viewport) property to the autocomplete object,
    // so that the autocomplete requests use the current map bounds for the
    // bounds option in the request.

    autocomplete.bindTo("bounds", map); // Set the data fields to return when the user selects a place.

    autocomplete.setFields([
        "address_components",
        "geometry",
        "icon",
        "name"
    ]);

    const geocoder = new google.maps.Geocoder();
    const infowindow1 = new google.maps.InfoWindow();

    map.addListener('click', function (e) {

        deleteMarkers();
        const coordinates = e.latLng.lat() + "," + e.latLng.lng();
        geocodeFillAddress(e.latLng);
        geocodeLatLng(geocoder, map, infowindow1, coordinates);
    });

    for (var i = 0; i < existingMarkers.length; i++) {

        AddInitialMarkers(existingMarkers[i])
    };


    function AddInitialMarkers(object) {

        var myLatlng = new google.maps.LatLng(object.lat, object.lng);

        var marker = new google.maps.Marker({

            position: myLatlng,
            map: map
        });

        var infoWindow = new google.maps.InfoWindow({
            content: object.title
        });

        marker.addListener('click', function () {
            infoWindow.open(map, marker);
            map.setZoom(10);
            map.setCenter(marker.getPosition());
        });

        existingMarkersArray.push(marker);
    };

    var markerCluster = new MarkerClusterer(map, existingMarkersArray, {
        averageCenter: true,
        imagePath: 'https://developers.google.com/maps/documentation/javascript/examples/markerclusterer/m'
    });


    const infowindow = new google.maps.InfoWindow();
    const infowindowContent = document.getElementById("infowindow-content");
    infowindow.setContent(infowindowContent);
    const marker = new google.maps.Marker({
        map,
        anchorPoint: new google.maps.Point(0, -29),
        draggable: true
    });



    marker.addListener('dragend', (e) => {

        map.setCenter(marker.getPosition());
        geocodeFillAddress(e.latLng);
    });


    autocomplete.addListener("place_changed", () => {
        deleteMarkers();
        fillInAddress();
        infowindow.close();

        marker.setVisible(false);
        const place = autocomplete.getPlace();

        if (!place.geometry) {
            // User entered the name of a Place that was not suggested and
            // pressed the Enter key, or the Place Details request failed.
            window.alert(
                "No details available for input: '" + place.name + "'"
            );
            return;
        } // If the place has a geometry, then present it on a map.

        if (place.geometry.viewport) {
            map.fitBounds(place.geometry.viewport);
        } else {
            map.setCenter(place.geometry.location);
            map.setZoom(17); // Why 17? Because it looks good.
        }

        marker.setPosition(place.geometry.location);
        marker.setVisible(true);
        let address = "";

        if (place.address_components) {
            address = [
                (place.address_components[0] &&
                    place.address_components[0].short_name) ||
                "",
                (place.address_components[1] &&
                    place.address_components[1].short_name) ||
                "",
                (place.address_components[2] &&
                    place.address_components[2].short_name) ||
                ""
            ].join(" ");
        }

        infowindowContent.children["place-icon"].src = place.icon;
        infowindowContent.children["place-name"].textContent = place.name;
        infowindowContent.children["place-address"].textContent = address;
        infowindow.open(map, marker);
    }); // Sets a listener on a radio button to change the filter type on Places
    // Autocomplete.

    function setupClickListener(id, types) {
        const radioButton = document.getElementById(id);
        radioButton.addEventListener("click", () => {
            autocomplete.setTypes(types);
        });
    }

    setupClickListener("changetype-all", []);
    setupClickListener("changetype-address", ["address"]);
    setupClickListener("changetype-establishment", ["establishment"]);
    setupClickListener("changetype-geocode", ["geocode"]);
    document
        .getElementById("use-strict-bounds")
        .addEventListener("click", function () {
            console.log("Checkbox clicked! New state=" + this.checked);
            autocomplete.setOptions({
                strictBounds: this.checked
            });
        });



}

function geocodeLatLng(geocoder, map, infowindow1, coordinates) {

    deleteMarkers();
    const latlngStr = coordinates.split(",", 2);
    const latlng = {
        lat: parseFloat(latlngStr[0]),
        lng: parseFloat(latlngStr[1])
    };


    geocoder.geocode(
        {
            location: latlng
        },
        (results, status) => {
            if (status === "OK") {
                if (results[0]) {
                    @* map.setZoom(11);*@
            const marker = new google.maps.Marker({
                        position: latlng,
                        map: map,
                @* animation: google.maps.Animation.DROP,*@
                    draggable: true
                });
    markers.push(marker);
    marker.addListener('click', () => {
        map.setZoom(10);
        map.setCenter(marker.getPosition());
    });
    marker.addListener('dragend', (e) => {
        const geocoder = new google.maps.Geocoder();
        const coordinates1 = e.latLng.lat() + "," + e.latLng.lng();
        const infowindow2 = new google.maps.InfoWindow();
        geocodeLatLng(geocoder, map, infowindow2, coordinates1);
        geocodeFillAddress(e.latLng);
    });

    map.panTo(latlng);
    infowindow1.setContent(results[0].formatted_address);
    infowindow1.open(map, marker);


} else {
    window.alert("No results found");
}
    } else {
    window.alert("Geocoder failed due to: " + status);
}
}
);
}


function setMapOnAll(map) {
    for (let i = 0; i < markers.length; i++) {
        markers[i].setMap(map);
    }
}

function clearMarkers() {
    setMapOnAll(null);
}

function showMarkers() {
    setMapOnAll(map);
}

function deleteMarkers() {
    clearMarkers();
    markers = [];
}

function geocodeFillAddress(latLng) {

    document.getElementById('latitude').value = "";
    document.getElementById('latitude').disabled = false;
    document.getElementById('latitude').value = latLng.lat();

    document.getElementById('longitude').value = "";
    document.getElementById('longitude').disabled = false;
    document.getElementById('longitude').value = latLng.lng();
}


function fillInAddress() {
    // Get the place details from the autocomplete object.

    const place = autocomplete.getPlace();

    document.getElementById('name').value = "";
    document.getElementById('name').disabled = false;
    document.getElementById('name').value = place.name;

    document.getElementById('latitude').value = "";
    document.getElementById('latitude').disabled = false;
    document.getElementById('latitude').value = place.geometry.location.lat();

    document.getElementById('longitude').value = "";
    document.getElementById('longitude').disabled = false;
    document.getElementById('longitude').value = place.geometry.location.lng();


    for (const component in componentForm) {
        document.getElementById(component).value = "";
        document.getElementById(component).disabled = false;
    } // Get each component of the address from the place details,
    // and then fill-in the corresponding field on the form.

    for (const component of place.address_components) {

        const addressType = component.types[0];
        if (componentForm[addressType]) {
            const val = component[componentForm[addressType]];
            document.getElementById(addressType.toString()).value = val;

        }
    }
}
