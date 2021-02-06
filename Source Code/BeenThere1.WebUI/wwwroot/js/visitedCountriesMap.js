


var countriesToDisplay = [];

for (var i = 0; i < countries.length; i++) {

    countriesToDisplay.push({
        "id": countries[i],
        "showAsSelected": true
    });
};




var map = AmCharts.makeChart("mapdiv", {

    type: "map",
    theme: "dark",
    projection: "mercator",
    panEventsEnabled: true,
    backgroundColor: "#535364",
    backgroundAlpha: 1,
    zoomControl: {
        zoomControlEnabled: true
    },
    dataProvider: {
        map: "worldHigh",
        getAreasFromMap: false,
        areas: countriesToDisplay

    },
    areasSettings: {
        autoZoom: false,
        color: "#B4B4B7",
        colorSolid: "#84ADE9",
        selectedColor: "#84ADE9",
        outlineColor: "#666666",
        rollOverColor: "#9EC2F7",
        rollOverOutlineColor: "#000000"
    }
});
