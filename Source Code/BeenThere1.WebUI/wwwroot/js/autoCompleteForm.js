let placeSearch;
let autocomplete;

const componentForm = {
    street_number: "short_name",
    route: "long_name",
    locality: "long_name",
    administrative_area_level_1: "short_name",
    country: "long_name",
    postal_code: "short_name"
};

function initAutocomplete() {

    autocomplete = new google.maps.places.Autocomplete(
        document.getElementById("autocomplete"),
        {
        //types: ["geocode"]
        }
    ); 
    autocomplete.setFields([
        //"address_components",
        //"geometry",
        //"icon",
        //"name",
        //"place_id"
     ]);

    autocomplete.addListener("place_changed", () => {

        const place = autocomplete.getPlace();

        fillInAddress(place);

        

    });
}

// Get the place details from the autocomplete object.

function fillInAddress(place) {

    document.getElementById('locationName').value = "";
    document.getElementById('locationName').value = place.name;

    document.getElementById('name').value = "";
    document.getElementById('name').disabled = false;
    document.getElementById('name').value = place.name;

    document.getElementById('latitude').value = "";
    document.getElementById('latitude').disabled = false;
    document.getElementById('latitude').value = place.geometry.location.lat();

    document.getElementById('longitude').value = "";
    document.getElementById('longitude').disabled = false;
    document.getElementById('longitude').value = place.geometry.location.lng();

    document.getElementById('placeId').value = "";
    document.getElementById('placeId').disabled = false;
    document.getElementById('placeId').value = place.place_id;


    for (const component in componentForm) {
        document.getElementById(component).value = "";
        document.getElementById(component).disabled = false;
    }

    // Get each component of the address from the place details,
    // and then fill-in the corresponding field on the form.

    for (const component of place.address_components) {

        const addressType = component.types[0];
        if (componentForm[addressType]) {
            const val = component[componentForm[addressType]];
            document.getElementById(addressType.toString()).value = val;

            //when gettting the country name, also get the country code so that we can add it to visited
            //country list. That list's update function only accepts country codes as input.
            if (addressType == "country") {
                document.getElementById("countryCode").value = component["short_name"];
            }
        }
    }

    //use the getDetails method to retrieve phone number, website info etc.

    const request = {
        placeId: place.place_id,
        fields: ["website", "international_phone_number", "url"]
    };

    var service = new google.maps.places.PlacesService(document.createElement('div'));
    service.getDetails(request, (place, status) => {
        if (status === google.maps.places.PlacesServiceStatus.OK) {

            document.getElementById('website').value = "";
            document.getElementById('website').disabled = false;
            document.getElementById('website').value = place.website;

            document.getElementById('phoneNumber').value = "";
            document.getElementById('phoneNumber').disabled = false;
            document.getElementById('phoneNumber').value = place.international_phone_number;

            document.getElementById('url').value = "";
            document.getElementById('url').disabled = false;
            document.getElementById('url').value = place.url;


        }
    });

    
}