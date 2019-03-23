$(document).ready(function(){

    //Scroll to element
    $('.search-down-icon').on('click', function () {
        $('html, body').animate({
          scrollTop: 250 + $('.filter-page').offset().top
        }, 500, 'linear');
    });

    $("body").on('click', '.return-back-btn', function () {
      console.log("click");
      $('html, body').animate({
        scrollTop: 0
      }, 500, 'linear');
  });

});

