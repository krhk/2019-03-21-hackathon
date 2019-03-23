<template>
    <div>
        <ul>
            <li v-for="item in list"><a v-on:click="clickSearch(item.slug)">{{item.name}}</a></li>
        </ul>
    </div>
</template>

<script>

    import EventBus from "../EventBus";
    const axios = require("axios");


    export default {
        name: "RegionList",
        data() {
            return {
                list: []
            }
        },
        methods: {
            clickSearch(slugName) {
                EventBus.$emit('SEARCH_FOR', slugName);
                EventBus.$emit('BRANCHES_REGION', slugName);
                EventBus.$emit('SHOW_LIST');
            }
        },
        mounted() {
            axios
                .get('/api/regions')
                .then((response) => {
                    this.list = response.data;
                });

        }
    }
</script>

<style scoped>

</style>