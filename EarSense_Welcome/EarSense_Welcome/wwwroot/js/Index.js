//Set body gradient during load and window resize
function setGradient() {

    //Define jumbotron section
    
    let elemHeight = $('#welcomeCard').height();
    let initPos = Math.round($('#welcomeCard').offset()["top"]);
    let height = elemHeight + initPos;

    let pageHeight = $(document).height();
    let middlePercentage = Math.round(100 * (height / pageHeight)) + 1.8;
    console.log(middlePercentage);

    //Define 'Contact Us' Section
    let contactInitPos = Math.round($('#contactCard').offset()["top"]);
    let endPercentage = Math.round(100 * (contactInitPos / pageHeight)) - 1.5;

    //Set dynamic background css property thorugh background-image
    let background = `linear-gradient(rgb(128,128,128) 0%,
                              rgb(128,128,128) `+ middlePercentage + `%,
                              rgb(62,63,58) `+ middlePercentage + `%,
                              rgb(62,63,58) `+ endPercentage + `%,
                              rgb(208,162,48) `+ endPercentage + `%,
                              rgb(208,162,48) 100%)`;

    $('body').css('background-image', background);

    console.log('resize');
    
}

function setDynamicSize() {
    $('#factsCard').height($('#frontImg').height());
    $('#importantCard').height($('#wordBlurbImg').height());
}

//Handle resize event

$(document).ready(function () {

    //$(window).resize(setGradient);

    //set gradient once when loading
    //setGradient();

    setDynamicSize();   
});