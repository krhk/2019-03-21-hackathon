let click = 0;

$('.menu-btn').click(function(){
    click++;
    $('.menu').slideToggle(255);
    if(click % 2) {
        $('.logo').css({
            'border-bottom': '1px solid #011627'
        });
    } else {
        $('.logo').css({
            'border-bottom': '0px solid #011627'
        }); 
    }

});