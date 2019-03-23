$(document).ready(function(){

    $('.filter-bar .data').click(function(){
        $(".filter-bar .data").removeClass("active");
        $(this).addClass('active');

        $(".filter-sub-bar").hide();

        let child = $(this).attr("data-child");
        $("." + child).toggle();
    });

    $('.filter-sub-bar .data').click(function(){
        $(this).siblings().removeClass("active");
        $(this).toggleClass('active');
    });

    $(".search-bar").submit(function(e) {
        e.preventDefault();

        let q = $(this).serializeArray()[0]['value'];

        $.ajax({
            url: "results",
            method: "POST",
            data: {search_subm:true, q},
            success: function(response) {
                console.log(response);
                $(".results-container").html(response);

                $(".results").show();

                $('html, body').animate({
                    scrollTop: $('.return-back-btn').offset().top - 100
                  }, 500, 'linear');
            }
        });
    });

    $(".filter-page").submit(function(e) {
        e.preventDefault();

        let filters = $(this).serializeArray();

        for(let i = 0; i < 4; i++) {
            if(filters[i] === undefined)
                filters[i] = "";
        }
        
        $.ajax({
            url: "results",
            method: "POST",
            data: {search_filters_subm:true, type:filters[0], who:filters[1], okres_name:filters[2], obec_name:filters[3]},
            success: function(response) {
                console.log(response);
                $(".results-container").html(response);

                $(".results").show();

                $('html, body').animate({
                    scrollTop: $('.return-back-btn').offset().top - 100
                  }, 500, 'linear');
            }
        });
    });
});