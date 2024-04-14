(function () {
    var tileUrl = 'https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png';
    var tileAttribution = 'Map data &copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a> contributors, <a href="https://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>';

    // Global export
    window.stationsMap = {
        showOrUpdate: function (elementId, markers) {
            var element = document.getElementById(elementId);
            if (!element) {
                throw new Error('No element with ID ' + elementId);
            }

            // Initialize map if needed
            if (!element.map) {
                element.map = L.map(elementId);
                element.map.addedMarkers = [];
                L.tileLayer(tileUrl, { attribution: tileAttribution }).addTo(element.map);
            }

            var map = element.map;
            if (map.addedMarkers.length !== markers.length) {
                // Markers have changed, so reset
                map.addedMarkers.forEach(marker => marker.removeFrom(map));
                map.addedMarkers = markers.map(m => {
                    return L.marker([m.y, m.x]).bindPopup(m.description).addTo(map);
                });

                // Auto-fit the view
                var markersGroup = new L.featureGroup(map.addedMarkers);
                map.fitBounds(markersGroup.getBounds().pad(0.3));
            }
        }
    };
})();