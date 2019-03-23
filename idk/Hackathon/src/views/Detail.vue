<template>
    <div class="container-main">
        <div class="container-content" ref ="content">
        <div class="container-header"><h1>{{title}}</h1></div>
        <div class="grey--text evinfo"><v-icon>calendar_today</v-icon>{{date}}</div>
        <div class="grey--text evinfo" v-show="this.place"><v-icon>place</v-icon>{{place}}</div>
        <div class="text"><p>{{desc}}</p></div>
        <GmapMap 
            v-if="gps && gps.latitude && gps.longitude"
            :center="{lat:gps.latitude, lng:gps.longitude}"
            :zoom="18"
            :options="{zoomControl: true,
            mapTypeControl: false,
            fullscreenControl: true}"
            style="width: 100%; height: 500px"
            >
              <GmapMarker
                :position="{lat:gps.latitude, lng:gps.longitude}"
                :clickable="true"
                @click.native="test()"
  />
        </GmapMap>
        <v-container class="imgcontainer">
              <masonry
        :cols="cols"
        gutter="30"
        >
                <v-img 
                class="test"
                v-for="img in imgs"
                :key = "img"
                @click.native="showImg(img)"
                v-bind:src="img"></v-img> 
            </masonry>
        </v-container>
    </div>
    <v-dialog
      v-model="dialog"
      width="500"
    >


      <v-card>

        <v-img v-if="clickedImg" v-bind:src="clickedImg"></v-img>
      </v-card>
    </v-dialog>
    </div>
</template>

<script lang="ts">
import Firebase from 'firebase';
import { Component, Vue } from 'vue-property-decorator';


@Component({
  components: {
  },
    
})

export default class Detail extends Vue {
    private columns = 4;
    private dialog = false;
    private clickedImg = "";
    private showImg(id:any){
        this.dialog = true;
        this.clickedImg = id;
        console.log(this.clickedImg);

    }
    private title = "";
    private date = "";
    private placeid = "";
    private place = "";
    private desc = "";
    private event ="";
    private gps: any = null;
    private imgs: Array<string> = [];
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
    get cols() {
    return this.columns;
  }
    private formatDate(date: Date) {
    // tslint:disable-next-line:max-line-length
        return date.getDate() + '.' + date.getMonth() + '.' + date.getFullYear() + ' ' + date.getHours() + ':' + (date.getMinutes() === 0 ? '00' : date.getMinutes());
    }  
    created() {
        
       Firebase.firestore().collection('events').doc(String(this.$route.params.id)).get().then((event) => {
            if (event.data()!.place) {
                Firebase.firestore().collection('places').doc(String(event.data()!.place)).get().then((place) => {
                    this.title = event.data()!.name;
                    this.date = this.formatDate(event.data()!.date_time_start_first.toDate());
                    this.placeid = event.data()!.place;
                    this.desc = event.data()!.description;
                    this.place = place.data()!.name;
                    this.gps = place.data()!.gps;

                    if(event.data()!.photos && event.data()!.photos.length > 0){
                        for (let index = 0; index < event.data()!.photos.length; index++) {
                            this.imgs.push('http://www.hkregion.cz/galerie/obrazky/imager.php?img=' + event.data()!.photos[index] + '&x=500');
                        }
                    }
                }); 
            } else {
                this.title = event.data()!.name;
                this.date = this.formatDate(event.data()!.date_time_start_first.toDate());
                this.placeid = event.data()!.place;
                this.desc = event.data()!.description;
                if(event.data()!.photos && event.data()!.photos.length > 0){
                    for (let index = 0; index < event.data()!.photos.length; index++) {
                        this.imgs.push('http://www.hkregion.cz/galerie/obrazky/imager.php?img=' + event.data()!.photos[index] + '&x=500');
                    }
                }
            }  
        }); 

         
    }

}

</script>

<style lang="scss" scoped>
    h1{
        font-size: 35px;
        font-weight: bold;
    }
    .evinfo{
        display: flex;
        align-items: center;
        margin-top: 10px;
        .v-icon {
            margin-right: 10px;
        }
    }
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
.container-content {
  padding-left: 70px;
  padding-right: 70px;
  max-width: initial;
    @media screen and (max-width: 959px) {
    padding-left: 25px;
    padding-right: 25px;
    padding-bottom: 81px;
  }
}
.container-header {
  padding-top: 50px;
  padding-left: 0 !important;
  max-width: initial;
    @media screen and (max-width: 959px) {
    padding-left: 0 !important;
    padding-right: 25px;
  }
}
.text{
    max-width: 75vw;
    margin-top: 15px;
}
.test{
    width: 250px !important;
}
.imgcontainer{
    padding-left: 0;
}

</style>
