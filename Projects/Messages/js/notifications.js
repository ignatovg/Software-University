const notifications = {};

$(() => {
    // Notifications
    $(document).on({
        ajaxStart: () => $('#loadingBox').show(),
        ajaxStop: () => $('#loadingBox').fadeOut()
    });

    $('#infoBox').click((event) => $(event.target).hide());
    $('#errorBox').click((event) => $(event.target).hide());

    notifications.showInfo = function (message) {
        $('#infoBox').text(message);
        $('#infoBox').show();
        setTimeout(() => $('#infoBox').fadeOut(), 3000);
    };

    notifications.showError = function (message) {
        $('#errorBox').text(message);
        $('#errorBox').show();
    };

    notifications.handleError = function (reason) {
        showError(reason.responseJSON.description);
    };
});
