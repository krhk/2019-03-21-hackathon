<!-- Call for builder -->
<?php require 'constructor.php';?>
<?php get_header();
?>
<!-- CONTENT START -->
<div class="parallax position-relative">
  <div class="filter w-100 h-100 position-absolute">
  </div>
  <div class="h1text text-center w-100">
    <h1 class="">Mapa zastávek IREDO </h1>
  </div>
</div>
<div class="search_content">
  <div class="form_search">
    <h3 class="text-center" style="color: white;">Rychlé vyhledávání zastávky  <i class="fas fa-map-marker-alt" aria-hidden="true" style="color: #ff1a1a;"></i></h3>

      <div class="text-center w-100">
        <div class="dropdown">
  <button style="width:50%;" class="btn btn-secondary dropdown-toggle" type="button" id="dropdown_coins" data-toggle="dropdown" aria-haspopup="true"
      aria-expanded="false">
      Vyhledat zastávku
  </button>
  <div id="menu" style="width:50%;"  class="dropdown-menu" aria-labelledby="dropdown_coins">
      <form class="px-4 py-2">
          <input type="search" class="form-control" id="searchCoin" placeholder="Jméno zastávky" autofocus="autofocus">
      </form>
      <div id="menuItems">

      </div>
      <div id="empty" class="dropdown-header">Žádné zastávky</div>
  </div>
</div>

      </div>
  </div>
  <div class="map_view">
    <div id="mapa" style="max-width:100%; height:60vh;"></div>
  </div>
</div>

<script type="text/javascript">
    $(document).ready(function(){
      var mapa = new SMap(JAK.gel("mapa"), SMap.Coords.fromWGS84(15.9143722 ,50.2137857), 9); //vytvoření mapy
      mapa.addControl(new SMap.Control.Sync()); //reagovaní na približení
      mapa.addDefaultLayer(SMap.DEF_BASE).enable(); //tur poklad
      //var mouse = new SMap.Control.Mouse(SMap.MOUSE_PAN | SMap.MOUSE_SCROLL); //myš
      //mapa.addControl(mouse); //přidání controls
      mapa.addDefaultControls();
      var souradnice = [];
      var options = {}
      var autobusove_zastavky = [];
      var vrstva = new SMap.Layer.Marker();
      var clusterer = new SMap.Marker.Clusterer(mapa);
      vrstva.setClusterer(clusterer);
      for (var pos = 0; pos < data.length; pos++) {
        var c = SMap.Coords.fromWGS84(data[pos][1], data[pos][2]);
        var options = {
            title:data[pos][0]
        }
        var znacka = new SMap.Marker(c, null, options);
        souradnice.push(c);
        autobusove_zastavky.push(znacka);
      }
      mapa.addLayer(vrstva);
      for (var i=0;i<autobusove_zastavky.length;i++) {
        vrstva.addMarker(autobusove_zastavky[i]);
      }
      vrstva.enable();
    });
    function nacti_mapu_hledani(pos_new){
      var center = SMap.Coords.fromWGS84(pos_new[0], pos_new[1]);
      var m = new SMap(JAK.gel("mapa"), center, 13);
      m.addDefaultLayer(SMap.DEF_BASE).enable();
      m.addDefaultControls();

      var layer = new SMap.Layer.Marker();
      m.addLayer(layer);
      layer.enable();

      var options = {
          title:pos_new[2]
      };
      var marker = new SMap.Marker(center, pos_new[2], options);
      layer.addMarker(marker);
    }
    $('#menuItems').on('click', '.dropdown-item', function(){
        $('#dropdown_coins').text($(this)[0].value);
        for (var x = 0; x < data.length; x++){
          if ($(this)[0].value == data[x][0] ){
            var pos_new=[];
            pos_new.push(data[x][1]);
            pos_new.push(data[x][2]);
            pos_new.push(data[x][0]);
            nacti_mapu_hledani(pos_new)
          }
        }
        $("#dropdown_coins").dropdown('toggle');
    })
</script>
<!-- CONTENT END -->
<!-- Call for footer -->
<?php get_footer(); ?>
