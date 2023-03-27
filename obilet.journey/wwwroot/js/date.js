const today = moment().format("YYYY-MM-DDTHH:mm");
const tomorrow = moment().add(1, 'days').format("YYYY-MM-DDTHH:mm");
const max = moment().add(1, 'years').format("YYYY-MM-DDTHH:mm");

$(document).ready(function () {

    $("#departureDate").attr("min", today);
    $("#departureDate").attr("max", max);

    const storageDepartureDate = localStorage.getItem("departureDate");

    if (storageDepartureDate) {
        $("#departureDate").val(storageDepartureDate);
    } else {
        $("#departureDate").val(tomorrow)
    }
});

function getToday() {

    $("#departureDate").val(today);
}

function getTomorrow() {

    $("#departureDate").val(tomorrow);
}