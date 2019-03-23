<template>
    <ul>
        <li v-for="school in schools"> {{school.address}} - {{school.branch}}</li>
    </ul>
</template>

<script>
    const axios = require("axios");
    import EventBus from "../EventBus";

    export default {

        data() {
            return {
                schools: []
            }
        },
        name: "SchoolList",
        mounted() {


            EventBus.$on('SHOW_SCHOOLS', (slugName) => {
                axios
                    .get('/api/schools/' + slugName)
                    .then((response) => {
                        this.schools = response.data;
                    });
            });
        }
    }
</script>

<style scoped>

</style>