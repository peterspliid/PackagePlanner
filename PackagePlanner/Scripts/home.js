const list = document.getElementById("results-list");
list.style.visibility = "hidden";

const errorView = document.getElementById("error-view");
errorView.style.display = 'none';

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

const makeRequest = function(endpoint, data, completion) {
    $.ajax({
        url: endpoint,
        dataType: 'json',
        data: data,
        success: function (data) {
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

var fetchResults = function (completion) {
    list.style.visibility = "hidden";
    errorView.style.display = 'none';
    isFetchingResults = true;
    startSpinner();

    const from = fromField.value;
    const to = toField.value;
    const weight = weightField.value;
    const customerId = customerIdInput.value;

    console.log(`From: ${from}, To: ${to}, Weight: ${weight}, customerId: ${customerId}`);

    const fastestTimeLabel = document.getElementById("fastest-time");
    const fastestPriceLabel = document.getElementById("fastest-price");
    const fastestRouteLabel = document.getElementById("fastest-route");
    const bestTimeLabel = document.getElementById("best-time");
    const bestPriceLabel = document.getElementById("best-price");
    const bestRouteLabel = document.getElementById("best-route");
    const cheapestTimeLabel = document.getElementById("cheapest-time");
    const cheapestPriceLabel = document.getElementById("cheapest-price");
    const cheapestRouteLabel = document.getElementById("cheapest-route");

    if (customerId === "") {
        errorView.innerHTML = "No customer id provided"
        errorView.style.display = 'block';
        stopSpinner();
        isFetchingResults = false;
        return;
    }

    var data = {
        "from": from,
        "to": to,
        "weight": weight,
        "customerId": customerId,
        "lenght": lengthField.value,
        "height": heightField.value,
        "width": widthField.value,
        "discount": discountField.value,
        "type": typeField.value
    }

    makeRequest('api/delivery', data, function (e) {
        fastestTimeLabel.innerHTML = e.fastest.time;
        fastestPriceLabel.innerHTML = e.fastest.price;
        bestTimeLabel.innerHTML = e.best.time;
        bestPriceLabel.innerHTML = e.best.price;
        cheapestTimeLabel.innerHTML = e.cheapest.time;
        cheapestPriceLabel.innerHTML = e.cheapest.price;

        if (e.fastest.route) {
            var text = convertArrayToString(e.fastest.route)
            fastestRouteLabel.innerHTML = text;
        }

        if (e.best.route) {
            var text = convertArrayToString(e.best.route)
            bestRouteLabel.innerHTML = text;
        }

        if (e.cheapest.route) {
            var text = convertArrayToString(e.cheapest.route)
            cheapestRouteLabel.innerHTML = text;
        }

        stopSpinner();
        list.style.visibility = "visible";
        isFetchingResults = false;
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

const selectBestButton = document.getElementById("select-best-button");
selectBestButton.onclick = function (e) {
    var data_select = {
        CustomerID: customerIdInput.value,
        type: typeField.value,
        price: $('#best-price').text(),
        discount : discountField.value
    }


    $.ajax({
        url: "/api/select",
        data: data_select,
        success: () => console.log("success")
    });
}

const selectFastestButton = document.getElementById("select-fastest-button");
selectFastestButton.onclick = function(e) {
    var data_select = {
        CustomerID: customerIdInput.value,
        type: typeField.value,
        price: $('#fastest-price').text(),
        discount: discountField.value
    }


    $.ajax({
        url: "/api/select",
        data: data_select,
        success: () => console.log("success")
    });
}

const selectCheapestButton = document.getElementById("select-cheapest-button");
selectCheapestButton.onclick = function(e) {
    var data_select = {
        CustomerID: customerIdInput.value,
        type: typeField.value,
        price: $('#cheapest-price').text(),
        discount: discountField.value
    }


    $.ajax({
        url: "/api/select",
        data: data_select,
        success: () => console.log("success")
    });
}