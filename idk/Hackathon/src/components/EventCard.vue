<template>
  <v-card
    @mouseover.native="over = true"
    @mouseleave.native="over = false"
    v-bind:class="{ [`elevation-${16}`]: over }">
    <v-img v-if="img" v-bind:src="img"></v-img>
    <v-card-title primary-title>
      <div>
        <div class="headline" v-on:click="openDetail()">{{title}}</div>
        <div class="infotext">
          <div class="grey--text" v-show="this.date"><v-icon>calendar_today</v-icon>{{date}}</div>
          <div class="grey--text" v-show="this.place"><v-icon>place</v-icon>{{place}}</div>
        </div>
      </div>
    </v-card-title>
    <v-card-text>
      {{text}}
    </v-card-text>
    <v-card-actions>
      <v-spacer></v-spacer>
      <v-btn icon>
        <v-icon>favorite</v-icon>
      </v-btn>
    </v-card-actions>
  </v-card>
</template>

<script lang="ts">
import { Component, Vue, Prop } from 'vue-property-decorator';

@Component({
  components: {
  },
})
export default class EventCard extends Vue {

    @Prop()
    public eventId!: number;

    @Prop({default: 'Chybějící titulek'})
    public title!: string;

    @Prop({default: ''})
    public date!: string;

    @Prop({default: ''})
    public place!: string;

    @Prop({default: ''})
    public text!: string;

    @Prop()
    public img!: string;

    private over = false;

    private openDetail() {
      this.$router.push({ path: 'akce/' + this.eventId });
    }
}
</script>

<style lang="scss" scoped>
.headline{
  font-size: 35px !important;
  margin-bottom: 5px;
  font-family: LatoLatinWebSemibold !important;
  color: #4C4C4C;
  line-height: 40px !important;
  &:hover{
    text-decoration: underline;
  }
}
.infotext{
  display:flex;
  flex-wrap: wrap;
  flex-direction: row;
  align-items: center;
}
.grey--text{
  margin-right: 15px;
  font-size: 15px !important;
  color: #6F6F6F !important;
  .v-icon{
    font-size: 17px !important;
    margin-right: 10px;
  }
}
.v-card__text{
  padding-bottom: 0;
  padding-top: 10px;
  font-size: 16px;
}
.v-card{
  padding: 20px;
  margin-bottom: 30px;
}
.v-card__title{
  padding-bottom: 0;
  &:hover{
    cursor:pointer;
  }
}
.v-btn__content .v-icon{
  color:#6F6F6F;
  &:hover{
    color: black;
  }
}
.v-image{
  margin-bottom: 15px;
}
</style>

