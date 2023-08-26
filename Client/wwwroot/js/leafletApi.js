//<![CDATA[
window.leafletApiJsFunctions = {
    initialize: function (dataCases, dataEmergencies, dotnetHelper) {
    
        let lat = 46.947975
            let lng =7.447447
        
        // Take leaflet init from #map id 
        const container = L.DomUtil.get('map');
        // Only one map init is allowed 
        if(container != null){
            container._leaflet_id = null;
        }
        
        // Create map and attach id to element with id "map"
        const map = L.map('map', {});

        const mapLayer = L.tileLayer('https://tiles.stadiamaps.com/tiles/alidade_smooth/{z}/{x}/{y}{r}.{ext}', {
            minZoom: 4,
            maxZoom: 28,
            attribution: '',
            ext: 'png',
            pluginAttribution: true,
            timestamp: 'current',
        }).addTo(map);

        
        // Add Swiss Satellite layer with default options
        const satelliteLayer = L.tileLayer.swiss({
            layer: 'ch.swisstopo.swissimage',
            maxNativeZoom: 28,
            attribution: '© <a href="https://www.swisstopo.ch/">Swisstopo</a>',
            pluginAttribution: true,
            timestamp: 'current',
        });

        // Multiple layers
        const baseMaps = {
            'Map': mapLayer,
            'Satellite (Swissimage)': satelliteLayer
        };
        
        // Adds layers with configs into map
        L.control.layers(baseMaps, {}, { collapsed: false }).addTo(map);

        // Set center with zoom level 
        map.setView([lat, lng], 12);

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
                map.setView([lat, lng], 12);
            } else {
                map.removeLayer(mapLayer);
                map.options.crs = L.CRS.EPSG2056;
                map.options.tms = true;
                map.fitBounds(bounds);
                map.setMaxBounds(crs instanceof L.Proj.CRS ? getMaxBounds(crs) : null);
                map._resetView(center, zoom, true);
                marker.update();
                map.setView([lat, lng], 12);
            }
            layer.redraw();
        })

        const svgIcon = L.divIcon({
            html: `
            <svg  viewBox="-4 0 36 36" version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink">
    <!-- Uploaded to: SVG Repo, www.svgrepo.com, Generator: SVG Repo Mixer Tools -->
    <title>map-marker</title>
    <defs>

</defs>
    <g id="Vivid.JS" stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
        <g id="Vivid-Icons" transform="translate(-125.000000, -643.000000)">
            <g id="Icons" transform="translate(37.000000, 169.000000)">
                <g id="map-marker" transform="translate(78.000000, 468.000000)">
                    <g transform="translate(10.000000, 6.000000)">
                        <path d="M14,0 C21.732,0 28,5.641 28,12.6 C28,23.963 14,36 14,36 C14,36 0,24.064 0,12.6 C0,5.641 6.268,0 14,0 Z" id="Shape" fill="#f0953c">

</path>
                        <circle id="Oval" fill="#da2f24" fill-rule="nonzero" cx="14" cy="14" r="7">

</circle>
                    </g>
                </g>
            </g>
        </g>
    </g>
</svg>
            `,
            className: "",
            iconSize: [24, 40],
            // iconAnchor: [24, 40],
        });
        
        for (let i = 0; i < dataCases.length; i++) {
            new L.marker([dataCases[i]['lat'], dataCases[i]['lng']], {draggable: false, icon: svgIcon})
                .addTo(map);
        }

        for (let i = 0; i < dataEmergencies.length; i++) {
            new L.circle([dataEmergencies[i]['lat'],dataEmergencies[i]['lng']], dataEmergencies[i]['radius']*1000,  {color: "red", opacity:.5}).addTo(map);
        }


        
        // Add a draggable marker to map
        // const marker =  L.marker([lat, lng], {draggable: false, icon: svgIcon}).addTo(map);
    }}
//]]>