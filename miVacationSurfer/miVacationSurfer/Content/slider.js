slideint = 1;
slideNext = 2;

$(document).ready(function() {
    $("#slideshow > img#1").fadeIn(300);
    startSlide();
});

function startSlide() {
    count = $("#slideshow > img").size();
    loop = setInterval(function () {
        if (slideNext > count) {
            slideNext = 1;
            slideInt = 1;
        }

        $("#slideshow > img").fadeOut(300);
        $("#slideshow > img#" + slideNext).fadeIn(300);
        slideInt = slideNext;
        slideNext = slideNext + 1;
    },3000);
}