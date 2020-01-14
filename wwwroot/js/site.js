// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function(){
    if(localStorage.getItem("lockNav") == null){
        document.getElementById("navToggleButton").innerHTML='<i class="fas fa-lock-open"></i>';
        localStorage.setItem("lockNav", false);
    }
    console.log(localStorage.getItem("lockNav"));
})

//if(localStorage.getItem("lockNav") == null) {
//        console.log("Lock Nav is false");
//        localStorage.setItem("lockNav", "false");
//    }


function toggleNavOpen() {
        document.getElementById("mySidenav").style.width = '20vw';
        document.getElementById("main").style.marginLeft = '10vw';
}

function toggleNavClosed() {
    if(localStorage.getItem("lockNav") == "false"){
        document.getElementById("mySidenav").style.width = '0vw';
        document.getElementById("main").style.marginLeft = '0vw';
    }
}

function openNav() {
  document.getElementById("mySidenav").style.width = "250px";
}

function closeNav() {
  document.getElementById("mySidenav").style.width = "0";
}

function lockNav() {
    if(localStorage.getItem("lockNav") == null){
        localStorage.setItem("lockNav", "false");
    } else if(localStorage.getItem("lockNav") == 'false'){
        document.getElementById("navToggleButton").innerHTML='<i class="fas fa-lock"></i>';
        localStorage.setItem("lockNav", "true");
    } else {
        document.getElementById("navToggleButton").innerHTML='<i class="fas fa-lock-open"></i>';
        localStorage.setItem("lockNav", "false");
    }
}

// Search bar functionality
function searchFunction() {
    var searchbox = document.getElementById("searchBar");
    var filter = searchbox.value.toUpperCase();
    var list = document.getElementById("sideNavContents");
    var items = list.getElementsByClassName("accordion");
    var items = list.querySelectorAll('a');
    console.log("items:", items);

    for (i = 0; i < items.length; i++) {
        var a = items[i];
        txtValue = a.textContent || a.innerText;
        if (txtValue.toUpperCase().indexOf(filter) > -1) {
            items[i].style.display = "";
        } else {
            items[i].style.display = "none";
        }
    }
}