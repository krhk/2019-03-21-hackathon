import Vue from 'vue';
import './plugins/vuetify';
import App from './App.vue';
import router from './router';
import store from './store';
import './registerServiceWorker';

import Vuebar from 'vuebar';
// @ts-ignore
import VueMasonry from 'vue-masonry-css';
import Firebase from 'firebase';
 
import * as VueGoogleMaps from 'vue2-google-maps';
 
Vue.use(Vuebar);
Vue.use(VueMasonry);

Vue.use(VueGoogleMaps, {
  load: {
    key: 'AIzaSyDDsbrELBuPLz5oaB0QykaDtE7NEmQYC9U',
    libraries: 'places',
  },
});

Vue.config.productionTip = false;

// Configure Firebase
Firebase.initializeApp({
  apiKey: 'AIzaSyDp3w13E8Xkhe8j_sJpY01CFKopMRdQDD0',
  authDomain: 'hackathon-hk-2019.firebaseapp.com',
  databaseURL: 'https://hackathon-hk-2019.firebaseio.com',
  projectId: 'hackathon-hk-2019',
  storageBucket: 'hackathon-hk-2019.appspot.com',
  messagingSenderId: '678624030793',
});

// Taken from https://css-tricks.com/the-trick-to-viewport-units-on-mobile/

// First we get the viewport height and we multiple it by 1% to get a value for a vh unit
const vh = window.innerHeight * 0.01;
// Then we set the value in the --vh custom property to the root of the document
document.documentElement.style.setProperty('--vh', `${vh}px`);

window.addEventListener('resize', () => {
  // We execute the same script as before
  const newVh = window.innerHeight * 0.01;
  document.documentElement.style.setProperty('--vh', `${newVh}px`);
});

new Vue({
  router,
  store,
  render: (h) => h(App),
}).$mount('#app');
