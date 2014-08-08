slideint = 1;
slideNext = 2;

$(document).ready(function() {
    $("#slideshow > img#1").fadeIn("slow");
    startSlide();
});

function startSlide() {
    count = $("#slideshow > img").size();
    loop = setInterval(function () {
        if (slideNext > count) {
            slideNext = 1;
            slideInt = 1;
        }

        $("#slideshow > img").fadeOut("slow");
        $("#slideshow > img#" + slideNext).fadeIn("slow");
        slideInt = slideNext;
        slideNext = slideNext + 1;
    },5000);
}