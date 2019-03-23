<template>
<div class="container-main" v-bar="{
  preventParentScroll: false
}" ref="scrollbar">
  <div @scroll="handleScroll" ref="contentContainer">
    <v-container class="container-header">
      <h1 class="display-3 font-weight-black ">Všechny akce</h1>
    </v-container>
    <v-container class="container-search">
      <v-layout align-center justify-start row fill-height>
        <span class="text">Řazeno od:</span>
        <v-menu
          ref="datePickerFrom"
          v-model="datePickerFrom"
          :close-on-content-click="false"
          :nudge-right="40"
          :return-value.sync="date"
          lazy
          transition="scale-transition"
          offset-y
          full-width
          min-width="290px"
        >
          <template v-slot:activator="{ on }">
            <v-text-field
              v-model="date"
              prepend-icon="event"
              readonly
              v-on="on"
            ></v-text-field>
          </template>
          <v-date-picker v-model="date" no-title scrollable>
            <v-spacer></v-spacer>
            <v-btn flat color="primary" @click="datePickerFrom = false">Cancel</v-btn>
            <v-btn flat color="primary" @click="$refs.datePickerFrom.save(date)">OK</v-btn>
          </v-date-picker>
        </v-menu>
        <span class="text"></span>
      </v-layout>
      <v-layout class="container-categories">
        <v-select
          v-model="value"
          :items="eventTypeItems"
          attach
          chips
          label="Kategorie"
          multiple
        ></v-select>
      </v-layout>
    </v-container>
    <v-container class="container-content" ref="content">
      <masonry
        :cols="cols"
        gutter="30"
        >
        <event-card
          v-for="event in events"
          :key="event.id"
          :eventId="event.id"
          :text="event.anotation"
          :title="event.name"
          :date="formatDate(event.date_time_start_first.toDate())"
          :place="places.has(String(event.place)) ? places.get(String(event.place)).name : ''"
          :img="(event.photos && event.photos.length > 0) ? 'http://www.hkregion.cz/galerie/obrazky/imager.php?img=' + event.photos[0] + '&x=500' : undefined"></event-card>
      </masonry>
    </v-container>
  </div>
</div>
</template>

<script lang="ts">
import { Component, Vue, Watch } from 'vue-property-decorator';
import EventCard from '../components/EventCard.vue';
import Firebase from 'firebase';
import { eventTypes } from '../shared/event_types';

@Component({
  components: {
    EventCard,
  },
})
export default class Home extends Vue {

  private datePickerFrom = false;
  private date = new Date().toISOString().substr(0, 10);

  private columns = 4;
  private events: any[] = [];
  private places = new Map<string, any>();

  private loading = false;
  private step = 80;
  private lastDate: Date = new Date();

  private items: string[] = [];
  private value: string[] = [];

  private created() {

    for (const type of eventTypes) {
      this.items.push(type.name);
    }

    window.addEventListener('resize', this.handleResize);

    this.loadNext();
  }

  @Watch('value')
  private onValueChanged(value: string, oldValue: string) {
    console.log('value changed');
    this.events = [];
    this.loadNext();
  }

  @Watch('date')
  private onDateChanged(value: string, oldValue: string) {
    console.log('date changed');
    this.events = [];
    this.lastDate = new Date(value);
    this.loadNext();
  }

  private loadNext() {
    this.loading = true;

    const date = new Date(this.lastDate);
    date.setMonth(date.getMonth() + 1);

    Firebase.firestore()
      .collection('events')
      .orderBy('date_time_start_first')
      .startAt(Firebase.firestore.Timestamp.fromDate(date))
      .limit(this.step).get().then((snapshot) => {
        this.loadPlaces(snapshot).then(() => {
          snapshot.docs.forEach((doc) => {
            if (!this.checkForId(doc.id)) {
              const data = doc.data();
              data.id = doc.id;
              this.events.push(data);
            }
          });
          this.lastDate = this.events[this.events.length - 1].date_time_start_first;
          this.loading = false;
        });

      });
  }

  private getValueID(value: string) {
    for (const type of eventTypes) {
      if (value === type.name) {
        return type.id;
      }
    }

    return '';
  }

  private formatDate(date: Date) {
    // tslint:disable-next-line:max-line-length
    return date.getDate() + '.' + date.getMonth() + '.' + date.getFullYear();
  }

  private checkForId(id: string) {
    for (const event of this.events) {
      if (event.id === id) {
        return true;
      }
    }

    return false;
  }


  private mounted() {
    this.handleResize();
  }

  private handleResize() {
    if ((this.$refs.content as Element).clientWidth < 960) {
      this.columns = 1;
    } else if ((this.$refs.content as Element).clientWidth < 1280) {
      this.columns = 2;
    } else if ((this.$refs.content as Element).clientWidth < 1690) {
      this.columns = 3;
    } else {
      this.columns = 4;
    }
  }

  private handleScroll() {
    this.handleResize();

    // @ts-ignore
    // tslint:disable-next-line:max-line-length
    if ((this.$refs.contentContainer as Element).clientHeight - 100 < this.$vuebar.getState(this.$refs.scrollbar).barTop + this.$vuebar.getState(this.$refs.scrollbar).barHeight) {
      if (!this.loading) {
        this.loadNext();
      }
    }
  }

  private async loadPlaces(snapshot: Firebase.firestore.QuerySnapshot) {
    const promises = [];

    for (const doc of snapshot.docs) {
      if (!this.places.has(String(doc.data().place))) {
        promises.push(Firebase.firestore().collection('places').doc(String(doc.data().place)).get());
      }
    }

    const results = await Promise.all(promises);
    results.forEach((place) => {
      if (!this.places.has(String(place.id))) {
        this.places.set(String(place.id), place.data());
      }
    });
  }

  private destroyed() {
    window.removeEventListener('resize', this.handleResize);
  }

  get cols() {
    return this.columns;
  }

  get eventTypeItems() {
    return this.items;
  }
}
</script>

<style lang="scss">
.container-main {
  height: calc(100vh - 64px) !important;
  height: calc(calc(var(--vh, 1vh) * 100) - 64px);

  @media screen and (max-width: 959px) {
    height: calc(100vh - 56px) !important;
    height: calc(calc(var(--vh, 1vh) * 100) - 56px);
  }

  width: 100%;
  max-width: initial;
}

.text {
  margin-inline-start: 20px;
  margin-inline-end: 20px;
}

.container-header {
  padding-top: 50px;
  padding-left: 70px;
  padding-right: 70px;
  max-width: initial;

  @media screen and (max-width: 959px) {
    padding-left: 25px;
    padding-right: 25px;
  }
}

.container-content {
  padding-left: 70px;
  padding-right: 70px;
  max-width: initial;

  @media screen and (max-width: 959px) {
    padding-left: 25px;
    padding-right: 25px;
  }
}

.container-search {
  padding-left: 70px;
  padding-right: 70px;
  max-width: initial;

  @media screen and (max-width: 959px) {
    padding-left: 25px;
    padding-right: 25px;
  }
}

.container-categories {
  padding-left: 142px;
  padding-right: 38px;

  @media screen and (max-width: 959px) {
    padding-left: 25px;
    padding-right: 38px;
  }
}

.display-3 {
  font-family: "LatoLatinWebHeavy" !important;
  font-weight: bold !important;
}
</style>