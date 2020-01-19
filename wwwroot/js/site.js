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
        element.closest(".accordion").nextElementSibling.querySelector("#updateExampleForm").style.display = "block";
        contents.style.display = "none";
        isVisible = "block";
    } else {
        element.closest(".accordion").nextElementSibling.querySelector("#updateExampleForm").style.display = "none";
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

// ob = window.document.getElementById("check");
// function checkWord(e){
//     console.log(e.keyCode);
//     if(e.keyCode === 56){
//         ob.value = "--";
//         ob.keyCode = 20;
//     }
// }
// ob.addEventListener("keydown",checkWord); 

// function checkForBullets(event){

//     console.log(e.KeyCode);

//     if(e.Key === '*'){
//         console.log(" we found one");
//     }

//     // console.log(event.shiftKey);
//     // console.log(event.KeyCode);
//     // console.log(event.Key);
//     // console.log(event.Code);


//     // if(event.KeyCode === 56){
//     //     console.log("They wrote a *");
//     // }
//     // if(event.KeyCode === 42){
//     //     console.log("They wrote a *");
//     // }
//     // if(event.KeyCode === 97){
//     //     console.log("They wrote a *");
//     // }
//     // console.log(element.value);
// }

var content = document.getElementsByClassName("contents");
console.log(content);
for(var i = 0; i < content.length; i++){
    console.log("content:", content[i].innerText);
    var idx = 0;
    if(content[i].innerText[idx] == " "){
        while(content[i].innerText[idx] == " "){
            idx++;
        }
    }
    if(content[i].innerText[idx] == '*'){
        console.log("Starts with a *");

        console.log(content[i]);

        content[i].innerHTML = `<li>${content[i].innerText}</li>`;
        
        // var newstr = document.createTextNode(content[i].innerText);
        // newstr.setAttribute()
        // prepend("<li>");
        // newstr.append("</li>");
        // document.body.append(newstr);
        // content[i].innerText.replace("*", "--");
        // content.value.replace("*", "--");
    }
}


var replace = document.getElementById("replace").innerText;
replace.replace("string", "doggo");
console.log("replace:", replace);