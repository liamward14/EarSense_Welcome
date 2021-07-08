
/*
function setDynamicSize() {
    $('#factsCard').height($('#frontImg').height());
    $('#importantCard').height($('#wordBlurbImg').height());
}
*/

function dealWithValidation() {
    var validationhtml = $('#validationSummary').html();
    if (validationhtml == null) { return; }
    if (validationhtml.indexOf('display:none') == -1) { //validation shown
        $(document).scrollTop($('#contactFormRow').position()["top"]);
    }
}

function dealWithNavSpacing() {
    //Set spacing
    $('#addressContainer').width($('#navbarimg').width());
}

//Handle resize event
$(document).ready(function () {
   // setDynamicSize();

    dealWithValidation();
    //dealWithNavSpacing();

});
