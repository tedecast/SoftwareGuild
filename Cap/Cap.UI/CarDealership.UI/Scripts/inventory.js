$(document).ready(function () {

    loadDvds();

    $("#search-button").click(function (event) {
        clearDvdTable();
        $('#searchContentRows').empty();

        $.ajax({
            type: 'GET',
            url: 'http://localhost:60758/inventory/search/' + $('#search-term').val(),
            success: function (dvdArray) {
                $.each(dvdArray, function (index, dvd) {
                    var title = dvd.title;
                    var releaseDate = dvd.releaseYear;
                    var director = dvd.director;
                    var rating = dvd.rating;
                    var dvdId = dvd.dvdId;
                    var row = '<tr>';
                    row += '<td><a onclick="gotoTitle(' + dvdId + ')">' + title + '</a></td>';
                    row += '<td>' + releaseDate + '</td>';
                    row += '<td>' + director + '</td>';
                    row += '<td>' + rating + '</td>';
                    row += '<td><a onclick="showEditForm(' + dvdId + ')">Edit</a> | <a id="deleteConfirm" onclick="deleteDvd(' + dvdId + ')">Delete</a></td>';
                    row += '</tr>';

                    clearDvdTable();
                    $('#searchContentRows').append(row);
                    $('#search-category').val('');
                    $('#search-term').val('');
                    $('#contentRows').hide();
                    $('#searchContentRows').show();
                    $('#search-back-button').show();

                });
            },
            error: function () {
                $("#errorMessages")
                    .append($('<li>')
                        .attr({ class: 'list-group-item list-group-item-danger' })
                        .text("Error calling web service. Please try again later."));
            }
        });
    });

    $('#search-back-button').click(function (event) {
        $('#search-category').val('');
        $('#search-term').val('');
        $('#searchContentRows').hide();
        $('#search-back-button').hide();
        $('#contentRows').show();
        loadDvds();
    });

    

    $('#edit-cancel-button').click(function (event) {
        showHomeDisplay();
    });

});
// end of on load function

function loadVehicles() {

    clearVehicles();

    var contentRows = $("#contentRows");

    $.ajax({
        type: 'GET',
        url: 'http://localhost:1391/dvds/',
        success: function (dvdArray) {
            $.each(dvdArray, function (index, dvd) {
                var title = dvd.title;
                var releaseDate = dvd.releaseYear;
                var director = dvd.director;
                var rating = dvd.rating;
                var dvdId = dvd.dvdId;

                contentRows.append(row);
            });
        },
    });
}

function clearVehicles() {
    $("#contentRows").empty();
}
