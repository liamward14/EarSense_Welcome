function triggerModal() {
    $('#push').modal('show');
}

$(window).on('load', triggerModal);

$('#push').on('hidden.bs.modal', function () {
    console.log('hidden');
});