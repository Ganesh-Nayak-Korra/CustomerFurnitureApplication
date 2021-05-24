function productList() {
    // Call Web API to get a list of Product
    $.ajax({
        url: 'https://localhost:44370/api/Customer',
        type: 'GET',
        dataType: 'json',
        success: function (furniture) {
            furnitureListSuccess(furnitures);
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        }
    });
}

function furnitureListSuccess(furnitures) {
    // Iterate over the collection of data
    $.each(furnitures, function (index, furniture) {
        // Add a row to the Product table
        furnitureAddRow(furniture);
    });
}

function furnitureAddRow(furniture) {
    // Check if <tbody> tag exists, add one if not
    if ($("#tablefur tbody").length == 0) {
        $("#tablefur").append("<tbody></tbody>");
    }
    // Append row to <table>
    $("#tablefur tbody").append(
        furnitureBuildTableRow(furniture));
}

function furnitureBuildTableRow(furniture) {
    var ret =
        "<tr>" +
        "<td>" + + "</td>" +
        "<td>" + + "</td>"
        + "<td>" ++ "</td>" +
        "</tr>";
    return ret;
}

function handleException(request, message, error) {
    var msg = "";
    msg += "Code: " + request.status + "\n";
    msg += "Text: " + request.statusText + "\n";
    if (request.responseJSON != null) {
        msg += "Message" + request.responseJSON.Message + "\n";
    }
    alert(msg);
}