const list = document.getElementById("results-list");
list.style.visibility = "hidden";

const spinner = document.getElementById("spinner")
spinner.style.visibility = 'hidden';

const fromField = document.getElementById("from-field");
const toField = document.getElementById("to-field");
const weightField = document.getElementById("weight-field");
const customerIdInput = document.getElementById("customerId-input");
const typeField = document.getElementById("type-field");
const lengthField = document.getElementById("size-length");
const widthField = document.getElementById("size-width");
const heightField = document.getElementById("size-height");
const discountField = document.getElementById("discount-input");

var isFetchingResults = false;

const makeRequest = function (endpoint, data, completion, errorHandling) {
    isFetchingResults = true;
    $.ajax({
        url: endpoint,
        dataType: 'json',
        data: data,
        error: function(e) {
            isFetchingResults = false;
            errorHandling(e);
        },
        statusCode: {
            500: function (e) {
                isFetchingResults = false;
                errorHandling(e);
            }
        },
        success: function (data) {
            isFetchingResults = false;
            completion(data);
        }
    });
}

var startSpinner = function () {
    spinner.style.visibility = 'visible';
}

var stopSpinner = function() {
    spinner.style.visibility = 'hidden';
}

var convertArrayToString = function(array) {
    var text = "";

    for (var i = 0; i < array.length; i++) {
        text += array[i];

        if (i < array.length - 1) {
            text += " → "
        }
    }

    return text;
}

var getData = function () {
    const from = fromField.value;
    const to = toField.value;
    const weight = weightField.value;
    const customerId = customerIdInput.value;
    return {
        "fromDestination": from,
        "toDestination": to,
        "packageWeight": weight,
        "customerId": customerId,
        "packageLength": lengthField.value,
        "packageHeight": heightField.value,
        "packageWidth": widthField.value,
        "discount": discountField.value,
        "cargoType": typeField.value,
        "recorded": "false"
    };
}

var fetchResults = function (completion) {
    list.style.visibility = "hidden";
    isFetchingResults = true;
    startSpinner();

    const fastestTimeLabel = document.getElementById("fastest-time");
    const fastestPriceLabel = document.getElementById("fastest-price");
    const fastestRouteLabel = document.getElementById("fastest-route");
    const bestTimeLabel = document.getElementById("best-time");
    const bestPriceLabel = document.getElementById("best-price");
    const bestRouteLabel = document.getElementById("best-route");
    const cheapestTimeLabel = document.getElementById("cheapest-time");
    const cheapestPriceLabel = document.getElementById("cheapest-price");
    const cheapestRouteLabel = document.getElementById("cheapest-route");

    makeRequest('api/deliveryInternal', getData(), function (e) {
        fastestTimeLabel.innerHTML = e.fastest.time;
        fastestPriceLabel.innerHTML = e.fastest.price;
        bestTimeLabel.innerHTML = e.best.time;
        bestPriceLabel.innerHTML = e.best.price;
        cheapestTimeLabel.innerHTML = e.cheapest.time;
        cheapestPriceLabel.innerHTML = e.cheapest.price;
        var route = e.fastest.route;
        route = [getData().fromDestination].concat(route)
        $("#error-view p").text("");


        if (e.fastest.success) {
            list.style.visibility = "visible";
            if (e.fastest.route) {
                var text = convertArrayToString(route)
                fastestRouteLabel.innerHTML = text;
            }

            if (e.best.route) {
                var text = convertArrayToString(route)
                bestRouteLabel.innerHTML = text;
            }

            if (e.cheapest.route) {
                var text = convertArrayToString(route)
                cheapestRouteLabel.innerHTML = text;
            }
        } else {
            list.style.visibility = "hidden";
            $("#error-view p").text("No routes found");
        }
        
        stopSpinner();
    }, function (e) {
        stopSpinner();
        list.style.visibility = "hidden";
        errorView.innerHTML = "Server could not complete the request."
        errorView.style.display = 'block';
    });
}

const button = document.getElementById("go-button");

button.onclick = function () {
    if (isFetchingResults) {
        return;
    }

    fetchResults();
}

const discountInput = document.getElementById("discount-input");
discountInput.onkeypress = function(e) {
    e.preventDefault();
}

function selectButtonClick(btn_price, btn_time) {
    var data = getData();

    data['price'] = $('#' + btn_price).text();
    data['time'] = $('#' + btn_time).text();


    $.ajax({
        url: "/api/select",
        data: data,
        success: () => window.alert("The route has been saved to the database")
    });
}

const selectBestButton = document.getElementById("select-best-button");
selectBestButton.onclick = function (e) {
    selectButtonClick("best-price", "best-time");
}

const selectFastestButton = document.getElementById("select-fastest-button");
selectFastestButton.onclick = function(e) {
    selectButtonClick("fastest-price", "fastest-time");
}

const selectCheapestButton = document.getElementById("select-cheapest-button");
selectCheapestButton.onclick = function(e) {
    selectButtonClick("cheapest-price", "cheapest-time");
}