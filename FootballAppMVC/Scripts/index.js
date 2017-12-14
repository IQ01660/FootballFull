
$(window).resize(function(){
if($(".navSlideBtn").is(':hidden')){
    $(".dropdownNav").css("display","none")
}
})

var checkNavStatus = false;
$(".navSlideBtn").click(function(){
    if(checkNavStatus==false){
        $(".dropdownNav").slideDown();
        checkNavStatus = true;
    }
    else {
        $(".dropdownNav").slideUp();
        checkNavStatus = false;
    }
});
// *************
// slider
// *************

$(document).ready(function(){
    var frameHeight = $(".sliderFrame").height();
    $(".ikramMainSlider>.container>.sliderFrame>button").css("top",frameHeight/2.6 + "px")
})
$(window).resize(function(){
    var frameHeight = $(".sliderFrame").height();
    $(".ikramMainSlider>.container>.sliderFrame>button").css("top",frameHeight/2.6 + "px")
})

var leftPos = 0;
$(".ikramMainSlider>.container>.sliderFrame>.leftSliderBtn").click(function(){
    leftPos+=100
    if(leftPos == 100){
        leftPos = -200
    }
    $(".ikramMainSlider>.container>.sliderFrame>.sliderLent").css("left",leftPos+"%")
})
$(".ikramMainSlider>.container>.sliderFrame>.rightSliderBtn").click(function(){
    leftPos-=100
    if(leftPos == -300){
        leftPos = 0
    }
    $(".ikramMainSlider>.container>.sliderFrame>.sliderLent").css("left",leftPos+"%")
})