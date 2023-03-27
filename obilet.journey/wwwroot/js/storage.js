$(document).ready(function () {

    const storageOrigin = localStorage.getItem("selectedOrigin");
    const storageDestination = localStorage.getItem("selectedDestination");

    if (storageOrigin) {
        const splitStorageOrigin = storageOrigin.split('|');

        $('#origin-name').val(splitStorageOrigin[1])
        $('#origin').append(new Option(splitStorageOrigin[1], splitStorageOrigin[0], true, true))
    }

    if (storageDestination) {
        const splitStorageDestination = storageDestination.split('|');

        $('#destination-name').val(splitStorageDestination[1])
        $('#destination').append(new Option(splitStorageDestination[1], splitStorageDestination[0], true, true))
    }

    $("#searchJourney").on("submit", function () {
        saveStorage()
    });
});

function saveStorage() {

    const selectedOrigin = $("#origin option:selected");
    const selectedDestination = $("#destination option:selected");
    const departureDate = $("#departureDate");

    localStorage.setItem("selectedOrigin", selectedOrigin.val() + '|' + selectedOrigin.text());
    localStorage.setItem("selectedDestination", selectedDestination.val() + '|' + selectedDestination.text());
    localStorage.setItem("departureDate", departureDate.val());

    $('#searchJourney').submit();
}
