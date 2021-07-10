$(window).resize(adjustLayout);
/* call function in ready handler*/
$(document).ready(function(){
    adjustLayout();
    /* your other page load code here*/
})
function adjustLayout(){
    $('.cover-center .container').css({
        position:'relative',
        left: ($(window).width() - $('.cover-center').outerWidth())/2,
        top: ($('.cover-center').height() - $('.cover-center .container').outerHeight())/2
    });
    $('.cover-center-2 div').css({
        position:'relative',
        left: ($('.cover-center-2').width() - $('.cover-center-2 div').outerWidth())/2,
        top: ($('.cover-center-2').height() - $('.cover-center-2 div').outerHeight())/2
    });
}
