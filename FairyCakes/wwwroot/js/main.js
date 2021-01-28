var customEl = document.getElementById("Customisation");
var navBtn = document.getElementById("navBtn");

navBtn.addEventListener("click", openMenu);
customEl.addEventListener("click", showHide);
window.addEventListener("load", showHide);

function showHide() {
    if (customEl.checked) {
        document.getElementById("customMsg").style.display = "block";
    } else {
        document.getElementById("customMsg").style.display = "none";
    }
}

var isOpen = false;
function openMenu() {
    if (!isOpen) {
        document.getElementById("mainNav").style.transform = "translate(0)";
        isOpen = true;
    } else {
        document.getElementById("mainNav").style.transform = "translate(-250px)";
        isOpen = false;
    }
}