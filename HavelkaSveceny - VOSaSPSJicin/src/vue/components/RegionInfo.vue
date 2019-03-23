<template>
    <div v-if="show" id="regionInfo" class=" mt-3 d-flex w-100 justify-content-end">
            <div class="card ml-4 pr-1 pl-1" style="width: 18rem;"  v-for="branch in branches">
                <div class="card-body">
                    <h5 class="card-title">{{branch.branch}}</h5>
                    <h6 class="card-subtitle mb-2 text-muted">Počet výskytů: {{branch.rank}} </h6>
                    <p class="card-text">Procentuální výskyt z celku: {{Math.round(branch.percantage * 100)/100}}</p>
                </div>
            </div>
            <ul>
                <!--<li> : {{branch.rank}} : {{Math.round(branch.percantage * 100)/100}} %</li>-->
            </ul>
    </div>
</template>

<script>

    import EventBus from "../EventBus";
    const axios = require("axios");


    export default {
        name: "RegionInfo",
        data() {
            return {
                show: false,
                branches: []
            }
        },
        mounted() {

            EventBus.$on('BRANCHES_REGION', (slug) => {
                axios
                    .get('/api/schools/branches/' + slug)
                    .then((response) => {
                        this.branches = response.data;
                    });
            });

            EventBus.$on('SHOW_LIST', () => {
                this.show = true;
            });


        }
    }
</script>

<style scoped>

</style>