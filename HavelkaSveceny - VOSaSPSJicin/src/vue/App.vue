<template>
    <div id="app">
        <div class="row  h-50">
            <div class="col-md-3" style="padding-left: 40px; padding-top: 20px">
                <SearchBar></SearchBar>
                <RegionList></RegionList>
                <p v-if="showList">Seznamy Skol:</p>
                <SchoolList></SchoolList>
            </div>
            <div class="col-md-9">
                <Map></Map>
            </div>
        </div>
        <div class="row">
            <RegionInfo></RegionInfo>
        </div>

        <router-view></router-view>
    </div>
</template>

<script>

    import EventBus from "./EventBus.js";

    import Map from './components/Map.vue'
    import SearchBar from './components/SearchBar.vue'
    import RegionList from "./components/RegionList.vue";
    import RegionInfo from "./components/RegionInfo.vue";
    import SchoolList from "./components/SchoolList.vue";

    export default {
        data() {
            return {
                showList: false
            }
        },
        components: {
            Map,
            SearchBar,
            RegionList,
            RegionInfo,
            SchoolList
        },
        mounted() {
            EventBus.$on('SHOW_LIST', () => {
                this.showList = true;
            });
        }
    }
</script>

<style lang="scss">


</style>