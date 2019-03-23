function timer(){
	var timingDraw = setTimeout(draw_map,1000)
}

function draw_map() {
	var center = SMap.Coords.fromWGS84(15.860000, 50.380000);
	var map = new SMap(JAK.gel("SMap"), center, 8);
	map.addDefaultLayer(SMap.DEF_BASE).enable();
	map.addDefaultControls();

	var layer = new SMap.Layer.Marker();
	map.addLayer(layer);
	layer.enable();


	if(navigator.geolocation) {
				var options = {timeout:60000};
				navigator.geolocation.getCurrentPosition(getLocation, errorHandler, options);
	}
	else {
				errorHandler();
	}

	function getLocation(position) {
			var latitude = position.coords.latitude;
			var longitude = position.coords.longitude;
	}

	function errorHandler() {
			var address = prompt("Nebylo možné získat Vaši polohu. Pokud chcete využít možnosti zobrazení nejbližších stomatologů napište zde Vaši adresu: ", "");
	}

	//----------GEOCODER----------------

	for (i = 0; i < 1; i++) {
			fetch('php/test.php')
			  .then(function(response) {
					var myObj = JSON.parse(response);

			  })
			  .then(function(myJson) {
			    console.log(JSON.stringify(myJson));
			  });

			alert(query);
			var result = new SMap.Geocoder(query, odpoved).getResults();

			function odpoved(geocoder) {
			var item = geocoder.getResults()[0].results.shift();

			var data = SMap.Coords.fromWGS84(item.coords.toWGS84(0).join(", "));

			var options = {};
			var marker = new SMap.Marker(data, "myMarker", options);
			layer.addMarker(marker);
			}
	}
	//----------GEOCODER----------------
}
