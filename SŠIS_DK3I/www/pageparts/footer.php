</div>
<footer>
  <div id="footer">
    <div class="copyright"><hr>Tvořil: <b><a href="https://www.facebook.com/search/top/?q=ond%C5%99ej%20langr&epa=SEARCH_BOX" target=="_blank">Ondřej Langr</b></a> & <a href="https://www.facebook.com/rosta.rusz" target=="_blank"><b>Rostislav Rusz</b></a></div>
  </div>
</footer>
<script src="https://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.12.1/jquery-ui.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
<script>
  function openNav() {
    $("#mySidenav").show("blind", {direction: "right", easing: "swing"}, 500);
    $("#main-content, footer").css({
    "filter": "blur(3px)",
      transition : '.5s linear'
    });
    $(".open_menu").click(function(){
      $(this).hide();
    });
  }
  function closeNav() {
    $("#mySidenav").hide("blind", {direction: "right", easing: "swing"}, 400);
    $(".open_menu").show(250);
    $("#main-content, footer").css({
    "filter": "blur(0px)",
      transition : '.5s linear'
    });
  }
  let names = [];
  for (var x = 0; x < data.length; x++){
    names.push(data[x][0]);
  }
  let search = document.getElementById("searchCoin")
  let items = document.getElementsByClassName("dropdown-item")
  function buildDropDown(values) {
      let contents = []
      for (let name of values) {
      contents.push('<input type="button" class="dropdown-item" type="button" value="' + name + '"/>')
      }
      $('#menuItems').append(contents.join(""))
      $('#empty').hide()
  }
  window.addEventListener('input', function () {
      filter(search.value.trim().toLowerCase())
  })

  //For every word entered by the user, check if the symbol starts with that word
  //If it does show the symbol, else hide it
  function filter(word) {
      let length = items.length
      let collection = []
      let hidden = 0
      for (let i = 0; i < length; i++) {
      if (items[i].value.toLowerCase().startsWith(word)) {
          $(items[i]).show()
      }
      else {
          $(items[i]).hide()
          hidden++
      }
      }

      //If all items are hidden, show the empty view
      if (hidden === length) {
      $('#empty').show()
      }
      else {
      $('#empty').hide()
      }
  }

  //If the user clicks on any item, set the title of the button as the text of the item
  

  buildDropDown(names)
</script>
</body>
</html>
