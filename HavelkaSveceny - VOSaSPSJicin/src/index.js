import Vue from 'vue'
import App from './vue/App.vue'
import VueRouter from 'vue-router'


Vue.config.productionTip = false;
Vue.use(VueRouter);

const routes = [

];

const router = new VueRouter({
    routes
});




/* eslint-disable no-new */
new Vue({
    el: '#app',
    template: '<App/>',
    router: router,
    components: { App }
});
