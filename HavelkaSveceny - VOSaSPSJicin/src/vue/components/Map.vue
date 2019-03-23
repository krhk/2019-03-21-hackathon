<template>
    <div id="sMap" style="height:800px"></div>
</template>

<script>

    import EventBus from "../EventBus";

    const axios = require("axios");

    const options = {
        color: "red",
        opacity: 0.3,
        curvature: 2
    };

    export default {

        name: "Map",
        data() {
            return {
                map: null,
                areas: {},
                layers: [],
                markerLayers: [],
                i: 0
            }
        },
        methods: {
            zoomToPoly(coords) {
                let zoomRegion = this.map.computeCenterZoom(coords);
                this.map.setCenterZoom(zoomRegion[0], zoomRegion[1], true);
                this.layers.forEach((layer) =>layer.enable());
                this.markerLayers.forEach((layer) =>layer.enable());
            },
            searchRegion(id) {
                if (id in this.areas) {
                    let poly = this.areas[id];
                    let zoomRegion = this.map.computeCenterZoom(poly._coords);
                    this.map.setCenterZoom(zoomRegion[0], zoomRegion[1], true);
                    this.layers.forEach((layer) => {
                        if (layer.getId() !==  id) layer.disable();
                        else layer.enable();
                    });
                    this.markerLayers.forEach((layer) => {
                        if (layer.getId() !==  id) layer.disable();
                        else layer.enable();
                    });
                    EventBus.$emit('SHOW_SCHOOLS', id);
                } else {
                    EventBus.$emit('SHAKE');
                }

            }
        },
        created() {
            EventBus.$emit('BRANCHES_REGION', 12);
        },
        mounted() {
            this.map = new SMap(JAK.gel("sMap"));
            this.map.addControl(new SMap.Control.Sync());
            this.map.addDefaultLayer(SMap.DEF_BASE).enable();
            let mouse = new SMap.Control.Mouse(SMap.MOUSE_PAN | SMap.MOUSE_WHEEL | SMap.MOUSE_ZOOM);
            this.map.addControl(mouse);


            axios.get('api/regions').then((response1) => {
                response1.data.forEach((region) => {

                    let markerLayer = new SMap.Layer.Marker(region.slug);
                    this.map.addLayer(markerLayer);
                    markerLayer.enable();

                    this.markerLayers.push(markerLayer);

                    axios
                        .get('build/regions/'+region.slug+".json")
                        .then((response) => {
                            let coords = [];
                            response.data.coordinates[0].forEach((coord) => {
                                let point = SMap.Coords.fromWGS84(coord[0], coord[1]);
                                coords.push(point);
                            });
                            this.areas[region.slug] = new SMap.Geometry(SMap.GEOMETRY_POLYGON, region.slug, coords, options);
                            let layer = new SMap.Layer.Geometry(region.slug, {supportsAnimation: true});
                            this.map.addLayer(layer);
                            layer.enable();
                            layer.addGeometry(this.areas[region.slug]);
                            this.layers.push(layer);

                            let newThis = this;

                            this.map.getSignals().addListener(this, "geometry-click", function (e) {
                                newThis.searchRegion(e.target._id);
                            });
                        });
                    axios

                        .get('api/schools/'+region.slug)
                        .then((response2)=> {
                            let data = response2.data;
                            data.forEach((school) => {
                                let marker = new SMap.Marker(SMap.Coords.fromWGS84(school.map_x, school.map_y), school.id, {});
                                markerLayer.addMarker(marker);
                            })
                        })
                });
            });



            EventBus.$on('SEARCH_FOR', (name) => {
                this.searchRegion(name)
            });

            EventBus.$on('ZOOM_TO_POLY', (coords) => {
                this.zoomToPoly(coords)
            });


        }
    }
</script>

<style scoped>

</style>