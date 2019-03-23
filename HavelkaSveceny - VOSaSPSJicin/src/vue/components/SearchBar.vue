<template>
    <div id="searchContainer" v-on:submit.prevent>
        <form class="form-inline">
            <label for="search" class="mr-3">Hledat:</label>
            <input v-model="searchItem" id="search" v-bind:class="{ 'animated shake': state }" type="text" @keyup.enter="findItem">
            <button v-on:click="findItem" class="btn btn-primary ml-3">Hledat {{searchItem}}</button>
        </form>
        <button v-on:click="zoomBack()" class="btn btn-primary ml-3">Zobrazit celý kraj</button>

    </div>

</template>

<script>

    const axios = require("axios");
    import EventBus from "../EventBus";
    export default {
        name: "SearchBar",
        data() {
            return {
                searchItem: '',
                state: false,
                coords: [],
            }
        },
        methods: {
            findItem() {
                EventBus.$emit('SEARCH_FOR', this.searchItem)
            },
            zoomBack() {
                EventBus.$emit('ZOOM_TO_POLY', this.coords)
            }
        },
        mounted() {
            EventBus.$on('SHAKE', () => {
                console.log("test");
                this.state = true;
                setTimeout(()=>{this.state = false}, 1500)
            });

            axios
                .get('/build/regions/HK.json')
                .then((response) => {
                    response.data.coordinates[0].forEach((coord) => {
                        let point = SMap.Coords.fromWGS84(coord[0], coord[1]);
                        this.coords.push(point);
                    });

                });

        }
    }
</script>

<style scoped>

</style>