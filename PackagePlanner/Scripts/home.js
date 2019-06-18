var button = document.getElementById("go-button");
var list = document.getElementById("results-list");

list.style.visibility = "hidden";

button.onclick = function() {
    list.style.visibility = "visible";
}

