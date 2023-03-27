
let prevOrigin;
let prevDestination;

$(document).ready(function () {

    locationInit("origin")
    locationInit("destination")
});

function locationInit(id) {
    $('#' + id).select2({
        theme: 'bootstrap4',
        ajax: {
            url: "Home/SearchBusLocations",
            type: "POST",
            dataType: 'json',
            delay: 250,
            data: function (params) {
                return {
                    searchText: params.term
                };
            },
            processResults: function (data, params) {
                let options = '';
                const selectedItem = $("#" + id + " option:selected");

                $.each(data, function (index, option) {
                    options += '<option value="' + option.value + '">' + option.text + '</option>';
                });

                $('#' + id).html(options)
                $('#' + id).append(selectedItem)

                prevOrigin = $("#origin option:selected");
                prevDestination = $("#destination option:selected");

                return {
                    results: $.map(data, function (item) {
                        return {
                            text: item.text,
                            id: item.value
                        }
                    })
                };
            }
        }
    });
}

function changeLocation() {

    const selectedOrigin = $("#origin option:selected");
    const selectedDestination = $("#destination option:selected");

    if (selectedOrigin.val() !== selectedDestination.val()) {
        $("#origin").append(selectedDestination)
        $("#destination").append(selectedOrigin)

        $('#destination').val(selectedOrigin.val()).change()
        $('#origin').val(selectedDestination.val()).change()
    }
}

function handleChangeLocation(id, selectedName) {

    const selectedOrigin = $("#origin option:selected");
    const selectedDestination = $("#destination option:selected");

    if (id === 'origin' && selectedDestination.val() === selectedOrigin.val()) {
        $("#destination").append(prevOrigin)
        $('#destination').val(prevOrigin.val()).change()
    }

    if (id === 'destination' && selectedDestination.val() === selectedOrigin.val()) {
        $("#origin").append(prevDestination)
        $('#origin').val(prevDestination.val()).change()
    }

    $('#' + selectedName).val($('#' + id + ' option:selected').text());
}


