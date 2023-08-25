//<![CDATA[
window.leafletApiJsFunctions = {
    initialize: function (address, dotnetHelper) {

        let lat
        let lng
        
        // Check if address is not null
        if (address.length > 0)
        {
            lat = address[0].attrs.lat
            lng = address[0].attrs.lon
        } else {
            lat = address.lat
            lng = address.lng
        }
    
        // Take leaflet init from #map id 
        const container = L.DomUtil.get('map');
        // Only one map init is allowed 
        if(container != null){
            container._leaflet_id = null;
        }
        
        // Create map and attach id to element with id "map"
        const map = L.map('map', {
            // Use LV95 (EPSG:2056) projection -> SWISS
            // crs: L.CRS.EPSG2056,
        });

        // Add Esri layer with default options
        const Esri_WorldTopoMap = L.tileLayer('https://server.arcgisonline.com/ArcGIS/rest/services/World_Topo_Map/MapServer/tile/{z}/{y}/{x}', {minZoom: 1, maxZoom:28, scheme: 'tms',reuseTiles:true}).addTo(map); 
        
        // EXAMPLE: Add Swiss layer with default options
        // const mapLayer = L.tileLayer.swiss({
        //     attribution: '© <a href="https://www.swisstopo.ch/">Swisstopo</a>',
        //     pluginAttribution: true,
        //     timestamp: 'current',
        // }).addTo(map);
        
        // Add Swiss Satellite layer with default options
        const satelliteLayer = L.tileLayer.swiss({
            layer: 'ch.swisstopo.swissimage',
            maxNativeZoom: 28,
            attribution: '© <a href="https://www.swisstopo.ch/">Swisstopo</a>',
            pluginAttribution: true,
            timestamp: 'current',
        });
        
        // EXAMPLE:  Center the map on Switzerland
        // map.fitSwitzerland();

        // Multiple layers
        const baseMaps = {
            'Map': Esri_WorldTopoMap,
            'Satellite (Swissimage)': satelliteLayer
        };
        
        // Adds layers with configs into map
        L.control.layers(baseMaps, {}, { collapsed: false }).addTo(map);

        // Set center with zoom level 
        map.setView([lat, lng], 16);

        function getMaxBounds(crs) {
            const { bounds } = crs.projection;
            return new L.LatLngBounds(
                crs.unproject(bounds.min),
                crs.unproject(bounds.max),
            );
        }
        
        // Change Projection depends on map layer
        map.on('baselayerchange', function(layer) {
            let center = map.getCenter();
            let zoom = map.getZoom();
            const bounds = map.getBounds();
            if (layer.name.indexOf('Map') > -1) {
                map.removeLayer(satelliteLayer);
                map.options.crs = L.CRS.EPSG3857;
                map.options.tms = true;
                map.fitBounds(bounds);
                map.setMaxBounds(crs instanceof L.Proj.CRS ? getMaxBounds(crs) : null);
                map._resetView(center, zoom, true);
                marker.update();
                map.setView([lat, lng], 16);
            } else {
                map.removeLayer(Esri_WorldTopoMap);
                map.options.crs = L.CRS.EPSG2056;
                map.options.tms = true;
                map.fitBounds(bounds);
                map.setMaxBounds(crs instanceof L.Proj.CRS ? getMaxBounds(crs) : null);
                map._resetView(center, zoom, true);
                marker.update();
                map.setView([lat, lng], 16);
            }
            layer.redraw();
        })
        
        // Add a draggable marker to map
        const marker =  L.marker([lat, lng], {draggable: true}).addTo(map).on('dragend', () => {
           // Call callback and return data from JS to Blazor
            return dotnetHelper.invokeMethodAsync('GetLatLng', 
                marker.getLatLng().lng,
                marker.getLatLng().lat);
        })
    }}
//]]>