<template>
  <v-navigation-drawer
    :mini-variant="mini"
    fixed
    clipped
    app
    :permanent="!mobile"
    class="navbar"
    v-model="opened"
    @mouseover.native="mini = false"
    @mouseleave.native="mini = true"    
    v-bind:class="{maximized: !mini}"
  >
    <v-list>
      <v-list-tile
        v-for="item in items"
        :key="item.title"
        router
        :to="item.route"
      >
        <v-list-tile-action>
          <v-icon medium>{{ item.icon }}</v-icon>
        </v-list-tile-action>
        <v-list-tile-content>
          <v-list-tile-title class="subheading">{{ item.title }}</v-list-tile-title>
        </v-list-tile-content>
      </v-list-tile>
    </v-list>
  </v-navigation-drawer>
</template>


<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator';
import { items } from '../shared/toolbar_items';

@Component({
})
export default class Navbar extends Vue {

  @Prop({default: false})
  public opened!: boolean;

  private opDrawer = this.opened;
  public mini = true;
  private mobile = false;

  private created() {
    // tslint:disable-next-line:max-line-length
    window.addEventListener('resize', this.handleResize);
  }

  private mounted() {
    this.handleResize();
  }

  private handleResize() {
    if (window.innerWidth < 600) {
      this.mobile = true;
      this.mini = false;
    } else {
      this.mobile = false;
      this.opened = true;
    }
  }

  private destroyed() {
    window.removeEventListener('resize', this.handleResize);
  }

  get items() {
    return items;
  }

}
</script>


<style lang="scss">
.navbar {
  box-shadow: 0px 2px 4px -1px rgba(0,0,0,0.2), 0px 4px 5px 0px rgba(0,0,0,0.14), 0px 1px 10px 0px rgba(0,0,0,0.12);
  display: flex;
  flex-direction: column;

  padding-top: 15px;

}

.maximized {
  width: 300px !important;

  .v-list__tile {
    padding-left: 26px !important;
  }
}

</style>
