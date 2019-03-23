<template>
  <v-app>
    <v-toolbar app fixed clipped-left color="white" class="toolbar">
        <v-toolbar-side-icon v-if="mobile" @click.native="toggleDrawer()"></v-toolbar-side-icon>
      <v-toolbar-title>
        Kalendář Akcí
      </v-toolbar-title>
    </v-toolbar>
    <SideBar :opened="drawerOpened"></SideBar>
    <v-content>
      <router-view/>
    </v-content>
    <v-bottom-nav
      :value="mobile"
      fixed
    >
      <v-btn 
        v-for="item in items"
        :key="item.title"
        router
        :to="item.route"
        flat
        color="primary"
      >
        <span>{{ item.title }}</span>
        <v-icon>{{ item.icon }}</v-icon>
      </v-btn>
    </v-bottom-nav>
  </v-app>
</template>
<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import SideBar from './components/SideBar.vue';
import { items } from './shared/toolbar_items';

@Component({
  components: {
    SideBar,
  },
})

export default class App extends Vue {
  get items() {
    return items;
    }
  private mobile: boolean = false;
  private drawerOpened: boolean = false;

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
    } else {
      this.mobile = false;
    }
  }

  private toggleDrawer() {
    this.drawerOpened = !this.drawerOpened;
  }
}
</script>

<style lang="scss">
@import url('./assets/latolatinfonts.css');

html {
  overflow-y: auto;
}

body, .application {
  font-family: "LatoLatinWeb" !important;
}

.toolbar {
  z-index: 2;
  @media screen and (max-width: 959px) {
    height: 56px !important; 
  }
}

.v-toolbar__content {
  height: 64px !important;

  @media screen and (max-width: 959px) {
    height: 56px !important; 
  }
}

.v-content[data-booted="true"] {
  transition-property: width, padding-left;

  padding-top: 64px !important;

  @media screen and (max-width: 959px) {
    padding-top: 56px !important; 
  }
}

.v-toolbar[data-booted="true"] {
  transition: none;
}

.v-navigation-drawer[data-booted="true"] {
  transition-property: width, transform;

  margin-top: 64px !important;
  max-height: calc(100% - 64px) !important;

  @media screen and (max-width: 959px) {
    margin-top: 56px !important; 
    max-height: calc(100% - 56px) !important;
  }
}

.v-navigation-drawer__border {
  background-color: white !important;
}
</style>

<!-- Custom scrollbar styles -->
<style lang="scss">
.vb > .vb-dragger {
  z-index: 5;
  width: 12px;
  right: 0;
  transition:
      width 100ms ease-out;
}

.vb > .vb-dragger:hover {
  width: 12px;
}

.vb > .vb-dragger > .vb-dragger-styler {
  backface-visibility: hidden;
  transform: rotate3d(0,0,0,0);
  transition:
      background-color 100ms ease-out,
      width 100ms ease-out;
  background-color: #7e57c2;
  width: 12px;
  height: 100%;
  display: block;
}

.vb-content {
  box-sizing: inherit !important;
  padding-right: 0 !important;
}

.vb > .vb-dragger:hover > .vb-dragger-styler {
  width: 12px;
}
</style>

