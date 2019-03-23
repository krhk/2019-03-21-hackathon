<!-- Call for builder -->
<?php require ($_SERVER['DOCUMENT_ROOT'] . 'constructor.php');?>
<?php
  get_header();
?>
<!-- CONTENT START -->
<div>
	<!-- here is store all the points to go-->
  <div id="dataset1" style="display: none;"></div>
  <div id="dataset2" style="display: none;"></div>
  <div id="dataset3" style="display: none;"></div>
  <div id="dataset4" style="display: none;"></div>

<div style="height: 100vh;min-height: 500px;background-color: #484848b0;padding: 10px 20px;width: 60vw;margin: 0 auto;">
  <div class="search_input">
    <h1 class="text-center" style="color:white; margin-bottom: 25px;">Vyhledávání trasy</h1>
    <form class="form-inline">
      <div class="col-12 form-row">
        <div id="geolocation_set" style="width: 50%;position: relative;left: 25%;margin: 20px;">
          <div id="search_point_btn" class="btn btn-secondary w-100" style="cursor: pointer;" type="text" placeholder="Search" aria-label="Vyhledat na mapě">Vybrat Vaší pozici</div>

        </div>
          <div id="mapa_input_nn" style="width:100%!important; height:30vh;display: none;"></div>

        <script>
          function load_input_map(){
              var center = SMap.Coords.fromWGS84(14.400307, 50.071853);
              var m = new SMap(JAK.gel("mapa_input_nn"), center);
              m.addDefaultLayer(SMap.DEF_BASE).enable();
              var mouse = new SMap.Control.Mouse(SMap.MOUSE_PAN | SMap.MOUSE_WHEEL | SMap.MOUSE_ZOOM); /* Ovládání myší */
              m.addControl(mouse);
              var l = new SMap.Layer.Marker();
              m.addLayer(l).enable();
              var mark = new SMap.Marker(center);
              mark.decorate(SMap.Marker.Feature.Draggable);
              l.addMarker(mark);
              function start(e) { /* Začátek tažení */
                  var node = e.target.getContainer();
                  node[SMap.LAYER_MARKER].style.cursor = "grabbing";
              }
              function stop(e) {
                  var node = e.target.getContainer();
                  node[SMap.LAYER_MARKER].style.cursor = "";
                  var coords = e.target.getCoords();
                  var cc = String(coords).split(",");
                  cc[0] = cc[0].replace('(','');
                  cc[1] = cc[1].replace(')','');
                  $("#dataset1").text(cc[0]);
                  $("#dataset2").text(cc[1]);
                  $("#search_point_btn").text("Vaše pozice je: " + cc[0] + ", " + cc[1] + "!");
                  $("#mapa_input_nn").hide();
                  $("#geolocation_set").show();
              }
              var signals = m.getSignals();
              signals.addListener(window, "marker-drag-stop", stop);
              signals.addListener(window, "marker-drag-start", start);
            }

        </script>
      </div>
      <div class="col-12 form-row">
        <div class="dropdown" style="width:50%; position:relative;left:25%;">
  <button style="width:100%;" class="btn btn-secondary dropdown-toggle" type="button" id="dropdown_coins" data-toggle="dropdown" aria-haspopup="true"
      aria-expanded="false">
      Vyhledat zastávku
  </button>
  <div id="menu" style="width:50%;"  class="dropdown-menu" aria-labelledby="dropdown_coins">
      <form class="px-4 py-2">
          <input type="search" class="form-control" id="searchCoin" placeholder="zastavka" autofocus="autofocus">
      </form>
      <div id="menuItems">

      </div>
      <div id="empty" class="dropdown-header">Žádné zastávky</div>
  </div>
</div>

      </div>
    </form>
  </div>
  <div class="search_output" style="display: none!important;">
    <div id="mapa_output" style="max-width:100%; height:70vh;"></div>
    <script>
      function load_mapa_output(first_marker, second_marker) { //Predavat pouze string array!!!!!!! maxindex - 1

        var centerMap = SMap.Coords.fromWGS84(14.40, 50.08);
        var m = new SMap(JAK.gel("mapa_output"), centerMap, 16);
        var l = m.addDefaultLayer(SMap.DEF_BASE).enable();
        m.addDefaultControls();


        var nalezeno = function(route) {
            var vrstva = new SMap.Layer.Geometry();
            m.addLayer(vrstva).enable();

            var coords = route.getResults().geometry;
            var cz = m.computeCenterZoom(coords);
            m.setCenterZoom(cz[0], cz[1]);
            var g = new SMap.Geometry(SMap.GEOMETRY_POLYLINE, null, coords);
            vrstva.addGeometry(g);
        }

        var coords = [
          SMap.Coords.fromWGS84(first_marker[0], first_marker[1]),
          SMap.Coords.fromWGS84(second_marker[0], second_marker[1])
        ];
        var route = new SMap.Route(coords, nalezeno);
      }
    </script>
  </div>
</div>
<script>
  function showPosition(position) {
    window.pub_inp_pins.push(String(position.coords.longitude));
    window.pub_inp_pins.push(String(position.coords.latitude));
  }
  $(document).ready(function(){
      if ("geolocation" in navigator) {
        navigator.geolocation.getCurrentPosition(
         function success(position) {
           navigator.geolocation.getCurrentPosition(showPosition);
           $("#search_point_btn").text("Vaše pozice je: " + pub_inp_pins[0] + ", " + pub_inp_pins[1] + "!");
           $("#geolocation_set #search_point_btn").addClass('isset');
         },
        function error(error_message) {console.error('An error has occured while retrieving location', error_message)
        }
      );
      } else {console.log('geolocation is not enabled on this browser')}
    $("#geolocation_set #search_point_btn").click(function(){
      if ($(this).hasClass('isset') === false){
        $(this).parent().hide();
        $(this).parent().hide().next().show();
        load_input_map();
        $(this).addClass('isset');
      }
    });
  });
  $('#menuItems').on('click', '.dropdown-item', function(){
      $('#dropdown_coins').text($(this)[0].value);
      for (var x = 0; x < data.length; x++){
        if ($(this)[0].value == data[x][0] ){
          var pos_new=[];
          $("#dataset3").text(data[x][1]);
          $("#dataset4").text(data[x][2]);
          var first = [];
          var second = [];
          first.push($("#dataset1").text());
          first.push($("#dataset2").text());
          second.push($("#dataset3").text());
          second.push($("#dataset4").text());
          $(".search_output").show();
          load_mapa_output(first, second);
        }
      }
      $("#dropdown_coins").dropdown('toggle');
  })
</script>
<style>
</div>
 footer {
   position: absolute!important;
    bottom: 16px!important;
 }
</style>
<!-- CONTENT END -->
<!-- Call for footer -->
<?php get_footer(); ?>
