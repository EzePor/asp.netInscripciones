function searchAlumnos() {
    var searchString = document.getElementById("searchString").value;
    var xhr = new XMLHttpRequest();
    xhr.open("GET", "/Alumnos/Search?searchString=" + encodeURIComponent(searchString), true);
    xhr.setRequestHeader("X-Requested-With", "XMLHttpRequest");
    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4 && xhr.status === 200) {
            document.getElementById("alumnosTableBody").innerHTML = xhr.responseText;
        }
    };
    xhr.send();
}

function clearSearch() {
    document.getElementById("searchString").value = "";
    searchAlumnos();
}
