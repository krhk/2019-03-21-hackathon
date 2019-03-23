<div id="mapid" class="map"></div>
<script>
    var map = L.map('mapid').setView([50.4000000, 15.84], 10);

    let count = 0;
	let poptext = "";
	let index = 0;

    let values = [];
    let colors = [];

    L.tileLayer('https://api.tiles.mapbox.com/v4/{id}/{z}/{x}/{y}.png?access_token=pk.eyJ1IjoiamV0YW0iLCJhIjoiY2p0aGsxenE4MmZjbzQ5bDY0NnR3bXpjciJ9.C_uobQeZSeDT6VBoe1vKQw', {
        maxZoom: 18,
        attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a> contributors, ' +
            '<a href="https://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, ' +
            'Imagery © <a href="https://www.mapbox.com/">Mapbox</a>, data from DeltaSquat Team!',
        id: 'mapbox.streets'
    }).addTo(map);

	function getColor(d) {
        let color = "black";
        let level;

        let proc = 100/35*d * 4; 
        level = index*2;
        if(level < 0) level = 0;
        color = "rgb(255, "+level+", 0)";

        pushValue(d, level);

        return color;
    }
    
    function pushValue(v, c){
        if(values.indexOf(v)==-1){
            values.push(v);
            colors.push(c)
        }
    }

    function style(feature) {
		return {
			weight: 2,
			opacity: 1,
			color: 'white',
			dashArray: '3',
            fillOpacity: 0.7,
            fillColor: getColor(count)
		};
    }
    
    function styleKraj(feature) {
		return {
			weight: 2,
			opacity: 1,
			color: 'white',
			dashArray: '3',
            fillOpacity: 0.5,
            fillColor: "lightblue",
		};
	}

    function onEachFeature(feature,layer) {
		layer.bindPopup(poptext);
    }

    function skonujNemovitosti(n){
        if(n == 1) return "nemovitost";
        if(n < 5) return "nemovitosti";

        return "nemovitostí";
    }
    
    fetch("data/kraje.geojson")
        .then(function(response){
            return response.json();
        })
        .then(function(myJson){
            const geojson =  L.geoJson(myJson, {style: styleKraj,}).addTo(map);
        })
    
    fetch('http://khk-api.grimir.cz/regions')
        .then(function(response) {
            return response.json();
		})
		.catch(function(){
            document.getElementsByClassName("alert")[0].style.display = "block";   
        })
        .then(function(myJson) {
            myJson.data.forEach(val=>{
				count = val.count;
				index = Math.round((127/1000*val.unemployedCount) + (127/35*val.count));
				if(index > 255) index = 255;
				index = 255 - index;
                poptext = "<b>"+ val.addr.address.city+"</b><br> <b>počet nemovitostí v prodeji:</b> "+val.count+" <br><b>nezaměstnanost:</b> "+val.unemployedCount;
                const geojson =  L.geoJson(val.addr.geojson,{style: style, onEachFeature: onEachFeature,}).addTo(map);
            })
        })
        .then(function(){
            writeLegend();
        });

   

    function writeLegend(){
        values.sort((a,b)=>a-b);
        colors.sort((a,b)=>a-b);
        let c = 0;
        for(let i = 0; i < values.length; i++){
            document.getElementsByClassName("legend")[0].innerHTML += '<tr class="item"><td class="color" style="background-color: rgb(255, '+colors[values.length-i-1]+', 0);"></td><td class="text">'+values[i]+' '+skonujNemovitosti(values[i])+'</td></tr>';
            c++;
        }
        if(c<1){
			
            document.getElementsByClassName("alert")[0].style.display = "block"; 
		}

		console.log("Count area: "+c)
		
		document.getElementsByClassName("legend")[0].style.display = "none";
    }

    
</script>
