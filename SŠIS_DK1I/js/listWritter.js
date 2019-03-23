function writeFromList(id){
  var getJson;
  fetch('php/getJson.php')
  .then(function(response) {
    return response.json();
  })
  .then(function(myJson) {
    getJson = JSON.parse(JSON.stringify(myJson));
    var name = getJson.name;
    var street = getJson.street;
    var number = getJson.number;
    var city_name = getJson.city_name;
    var phone = "Tel." + getJson.phone;
    var opening ="Otevírací doba:" + getJson.opening;

    document.getElementById("doctor-name").innerHTML = name;
    document.getElementById("street").innerHTML = street;
    document.getElementById("number").innerHTML = number;
    document.getElementById("city-name").innerHTML = city_name;
    document.getElementById("phone").innerHTML = phone;
    document.getElementById("opening").innerHTML = opening;
  });
}
