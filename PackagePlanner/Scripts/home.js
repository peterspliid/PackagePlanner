const list = document.getElementById("results-list");
list.style.visibility = "hidden";

const spinner = document.getElementById("spinner")
spinner.style.visibility = 'hidden';

const fromField = document.getElementById("from-field");
const toField = document.getElementById("to-field");
const weightField = document.getElementById("weight-field");
const customerIdInput = document.getElementById("customerId-input");

var isFetchingResults = false;

var startSpinner = function () {
    spinner.style.visibility = 'visible';
}

var stopSpinner = function() {
    spinner.style.visibility = 'hidden';
}

var fetchResults = function (completion) {
    list.style.visibility = "hidden";
    isFetchingResults = true;
    startSpinner();

    // Database code
    const from = fromField.value;
    const to = toField.value;
    const weight = weightField.value;
    const customerId = customerIdInput.value;

    console.log(`From: ${from}, To: ${to}, Weight: ${weight}, customerId: ${customerId}`);

    var fastestTimeLabel;
    var fastestPriceLabel;
    var bestTimeLabel;
    var bestPriceLabel;
    var cheapestTimeLabel;
    var cheapestPriceLabel;

    setTimeout(stopSpinner, 2000);
    setTimeout(function() {
        list.style.visibility = "visible";
        isFetchingResults = false;
    }, 2000)
}

list.style.visibility = "hidden";

var button = document.getElementById("go-button");

button.onclick = function () {
    if (isFetchingResults) {
        return;
    }

    fetchResults();
}
