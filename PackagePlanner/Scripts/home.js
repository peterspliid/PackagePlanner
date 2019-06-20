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

var isFetchingResults = false;

const makeRequest = function(endpoint, completion) {
    $.ajax({
        url: endpoint,
        dataType: 'jsonp',
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

var fetchResults = function (completion) {
    list.style.visibility = "hidden";
    errorView.style.display = 'none';
    isFetchingResults = true;
    startSpinner();

    // Database code
    const from = fromField.value;
    const to = toField.value;
    const weight = weightField.value;
    const customerId = customerIdInput.value;

    console.log(`From: ${from}, To: ${to}, Weight: ${weight}, customerId: ${customerId}`);

    const fastestTimeLabel = document.getElementById("fastest-time");
    const fastestPriceLabel = document.getElementById("fastest-price");
    const bestTimeLabel = document.getElementById("best-time");
    const bestPriceLabel = document.getElementById("best-price");
    const cheapestTimeLabel = document.getElementById("cheapest-time");
    const cheapestPriceLabel = document.getElementById("cheapest-price");

    fastestTimeLabel.innerHTML = "8";
    fastestPriceLabel.innerHTML = "15";
    bestTimeLabel.innerHTML = "8";
    bestPriceLabel.innerHTML = "15";
    cheapestTimeLabel.innerHTML = "24";
    cheapestPriceLabel.innerHTML = "12";


    if (customerId === "") {
        errorView.innerHTML = "No customer id provided"
        errorView.style.display = 'block';
        stopSpinner();
        isFetchingResults = false;
        return;
    }

    setTimeout(stopSpinner, 2000);
    setTimeout(function() {
        list.style.visibility = "visible";
        isFetchingResults = false;
        makeRequest('', function(e) {  // API ENDPOINT GOES IN HERE!!
            console.log(e);
        });
    }, 2000)
}

list.style.visibility = "hidden";

const button = document.getElementById("go-button");

button.onclick = function () {
    if (isFetchingResults) {
        return;
    }

    fetchResults();
}

const selectBestButton = document.getElementById("select-best-button");
selectBestButton.onclick = function (e) {
    console.log("Best clicked");
}

const selectFastestButton = document.getElementById("select-fastest-button");
selectFastestButton.onclick = function(e) {
    console.log("Fastest clicked");
}

const selectCheapestButton = document.getElementById("select-cheapest-button");
selectCheapestButton.onclick = function(e) {
    console.log("Cheapest clicked");
}