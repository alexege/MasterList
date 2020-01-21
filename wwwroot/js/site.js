// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function(){
    if(localStorage.getItem("lockNav") == null){
        document.getElementById("navToggleButton").innerHTML='<i class="fas fa-lock-open"></i>';
        localStorage.setItem("lockNav", false);
    }
})

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

// Collapse Accordion
var acc = document.getElementsByClassName("accordion");
var i;

for (i = 0; i < acc.length; i++) {
  acc[i].addEventListener("click", function() {
    this.classList.toggle("active");

    /* Toggle between hiding and showing the active panel */
    var panel = this.closest(".accordion").nextElementSibling;
    if (panel.style.display === "block") {
      panel.style.display = "none";
    } else {
      panel.style.display = "block";
    }
  });
}

function openWordAccordion(word){
    
    var element = document.getElementById(word);
    console.log("Element:", element);
    var display = element.style.display;
    console.log("Panel:", element.nextElementSibling);
    
    if(display == "none" || display == ""){
        console.log("Display is hidden");
        element.nextElementSibling.style.display = "block";
        // document.getElementById(word).style.display = "inline-block";

        // var panel = document.getElementById()
        // this.closest(".accordion").nextElementSibling;
        


        // if (panel.style.display === "block") {
        // panel.style.display = "none";
        // } else {
        // panel.style.display = "block";
        // }
    } else {

    }
    console.log("display:", display);
}

function editWordTitle(event, element) {
    
    var contents = element.closest("button").querySelector(".contents");
    var isVisible = element.closest(".word").querySelector("form").style.display;
    
    if(isVisible == "none" || isVisible == ""){
        element.closest(".word").querySelector("form").style.display = "inline-block";
        contents.style.display = "none";
        isVisible = "inline-block";
    } else {
        element.closest(".word").querySelector("form").style.display = "none";
        contents.style.display = "inline-block";
        isVisible = "none";
    }
}

function editWordDefinition(event, element) {

    var contents = element.closest("button").nextElementSibling.querySelector(".contents");
    var isVisible = element.closest(".accordion").nextElementSibling.querySelector("form").style.display;
    
    if(!element.closest("button").classList.contains("active")){
        element.closest("button").classList.addEventListener("active");
    }

    if(isVisible == "none" || isVisible == ""){
        element.closest(".accordion").nextElementSibling.querySelector("form").style.display = "block";
        contents.style.display = "none";
        isVisible = "block";
    } else {
        element.closest(".accordion").nextElementSibling.querySelector("form").style.display = "none";
        contents.style.display = "inline-block";
        isVisible = "none";
    }
}

function editWordExample(event, element) {

    var contents = element.closest("button").nextElementSibling.querySelector(".contents");
    var isVisible = element.closest(".accordion").nextElementSibling.querySelector("form").style.display;
    
    if(!element.closest("button").classList.contains("active")){
        element.closest("button").classList.addEventListener("active");
    }

    if(isVisible == "none" || isVisible == ""){
        element.closest(".accordion").nextElementSibling.querySelector(".updateExampleForm").style.display = "block";
        contents.style.display = "none";
        isVisible = "block";
    } else {
        element.closest(".accordion").nextElementSibling.querySelector(".updateExampleForm").style.display = "none";
        contents.style.display = "inline-block";
        isVisible = "none";
    }
}

// Display word configuration menu
function showMenu(word){
    word.querySelector('.menu').style.display = "inline-block";
}

// Hide word configuration menu
function hideMenu(word){
    word.querySelector('.menu').style.display = "none";
}

document.addEventListener('submit', replaceStars());

function replaceStars(){

    var numContents = document.getElementsByClassName("contents");

    for(var i = 0; i < numContents.length; i++){
        var contents = document.getElementsByClassName("contents")[i];
        var numLines = (contents.innerText.match(/\n/g)||[]).length;
        var lines = contents.innerText.split(/\r?\n/g);
        var newString = '';

        for(var j = 0; j <= numLines; j++)
        {
            var k = 0;
            while(lines[j][k] !== "*")
            {
                // console.log(`lines[${j}][${k}]: ${lines[j][k]}`);
                if(k == lines[j].length)
                {
                    break;
                }
                k++;
                // console.log("end k:", k);
            }

            if(lines[j][k] == "*")
            {
                // var modifiedLine = lines[j].replace("*", "");
                var modifiedLine = lines[j];

                modifiedLine = lines[j].replace("*", "<span class='hide'>*</span>");
                
                if(lines[j][k+1] == " "){
                    modifiedLine = lines[j].replace("* ", "<span class='hide'>*</span>");
                }

                newString += `<li>${modifiedLine}</li>`;
            } else {
                newString += `<p>${lines[j]}</p>`;
            }
        }
        if(newString.length > 0){
            numContents[i].innerHTML = newString;
        }
    }
}

// Check if user entered anythign into the edit box
var contents = document.getElementsByClassName("contents");
for(var i = 0; i < contents.length; i++){
    var count = 0;
    contents[i].addEventListener("input", function(){
        count++;
    }, false);

    contents[i].addEventListener("focusout", function(){
        var wordId = this.closest(".word").getAttribute("id");
        if(count > 0){
            console.log("You wrote: \n" + this.innerText);

            var formData = this.innerText;

            console.log("Fetching: /Word/UpdateDefinition/" + wordId);
            fetch(`/Word/UpdateDefinition/${wordId}`, {
                method: 'POST',
                headers: {
                    'Content-Type':'application/json'
                },
                body: JSON.stringify({ Definition: formData})
            })
            .then(res => {
                // document.getElementById("ContentsPanel").innerHTML = formData;
                console.log(res);
                replaceStars();
            })
            .catch(err => {
                console.log("Error found: ", err);
            });
        } else {
            console.log("Nothing was written");
        }
        count = 0;
    }, false);
}
// document.getElementsByClassName("contents").addEventListener("input", function() {
//     console.log("input event fired");
// }, false);