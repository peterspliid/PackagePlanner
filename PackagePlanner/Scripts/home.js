const list = document.getElementById("results-list");
list.style.visibility = "hidden";

const spinner = document.getElementById("spinner")
spinner.style.visibility = 'hidden';

var resultsFetched = false;

var startSpinner = function () {
    spinner.style.visibility = 'visible';
}

var stopSpinner = function() {
    spinner.style.visibility = 'hidden';
}

var fetchResults = function (completion) {
    if (resultsFetched) {
        return;
    }

    startSpinner();

    // Database code
    setTimeout(stopSpinner, 2000);
    setTimeout(function() {
        list.style.visibility = "visible";
    }, 2000)
    resultsFetched = true;
}

list.style.visibility = "hidden";

var button = document.getElementById("go-button");

button.onclick = function () {
    if (resultsFetched) {
        return;
    }

    fetchResults();
}

