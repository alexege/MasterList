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

    // Change right-arrow to down-arrow for definition
    if(this.classList.contains("definition") || this.classList.contains("example")){
        var arrowIcon = this.querySelector("i");
        if(arrowIcon.classList.contains("fa-caret-right")){
            arrowIcon.classList.remove("fa-caret-right");
            arrowIcon.classList.add("fa-caret-down");
        } else {
            arrowIcon.classList.remove("fa-caret-down");
            arrowIcon.classList.add("fa-caret-right");
        }
    }

    if(this.classList.contains("wordButton")){
        this.closest(".word").classList.toggle("selection");
    }

  });
}

function openWordAccordion(word){
    
    var element = document.getElementById(word);
    var display = element.style.display;

    // element.classList.add("active");
    
    if(display == "none" || display == ""){
        element.nextElementSibling.style.display = "block";
    }
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
    var contents = document.getElementsByClassName("contents");
   
    //Loop through every contents container
    for(var i = 0; i < contents.length; i++){

        // console.log("outer:", contents[i].outerHTML);

        var content = contents[i];
        var numLines = (content.innerText.match(/\n/g)||[]).length;
        var line = content.innerText.split(/\r?\n/g);
        var newString = '';

        //For each line in this contents container
        for(var l = 0; l <= numLines; l++){
            if(line[l].length > 0){
                // console.log("line[l]:", line[l]);
            }
        }

        // Loop through each line in the textarea box
        for(var j = 0; j <= numLines; j++)
        {
            // Loop through to find if the line has an asteric or not.
            var k = 0;
            while(line[j][k] !== "*")
            {
                // If no asteric is found, break.
                if(k == line[j].length)
                {
                    break;
                }
                k++;
            }


            var content = line[j];
            var modifiedLine = '';

            if(line[j].slice(0,2) == "* "){
                modifiedLine = line[j].replace("* ", "<span class='hide' contentEditable='false'>*</span>");
                newString += `<li class="indent0">${modifiedLine}</li>`;
            } else if (line[j].slice(0,1) == "*"){
                modifiedLine = line[j].replace("*", "<span class='hide' contentEditable='false'>*</span>");
                newString += `<li class="indent0">${modifiedLine}</li>`;
            } else if (line[j].slice(0,2) == "\\t"){
                modifiedLine = line[j].replace("*", "<span class='hide' contentEditable='false'>*</span>");
                newString += `<li class="indent1">${modifiedLine}</li>`;
            } else {
                if(line[j].length > 0){
                    newString += `<p>${line[j]}</p>`
                }
            }

            // // If an asteric is found, create a li node and append the contents to it
            // if(line[j][k] == "*")
            // {
            //     console.log("Bullet found");

            //     // console.log(document.getElementById("definitionBox").innerHTML);
            //     // console.log(document.getElementById("definitionBox").outerHTML);

            //     var modifiedLine = line[j].replace("*", "<span class='hide' contentEditable='false'>*</span>");
                
            //     if(line[j][k+1] == " "){
            //         modifiedLine = line[j].replace("* ", "<span class='hide' contentEditable='false'>*</span>");
            //     }

            //     newString += `<li class="indent0">${modifiedLine}</li>`;
            // } else {
            //     newString += `<p>${line[j]}</p>`;
            // }
        }
        // if(newString.length > 0){
        //     contents[i].innerHTML = newString;
        // // }
        // }
    }
}

// On submit, replace asterics with bullet points
document.addEventListener('submit', replaceStars());

function replaceStars(){

    var numContents = document.getElementsByClassName("contents");

    for(var i = 1; i < numContents.length; i++){
        var contents = document.getElementsByClassName("contents")[i];
        var numLines = (contents.innerText.match(/\n/g)||[]).length;
        var lines = contents.innerText.split(/\r?\n/g);

        var lines2Length = (contents.innerText.match(/\n/g)||[]).length;
        // console.log("contents:", contents.innerHTML);
        var lines2 = contents.innerHTML.split(/\r?\n/g);
        // console.log("lines2split:", lines2);
        var lines2 = contents.innerHTML.split("\n");
        // console.log("lines2Length:", lines2Length);
        // console.log("lines2:", lines2);

        var newString = '';

        for(var l = 0; l <= lines2Length; l++){
            if(lines2[l].length > 0){
                // console.log(lines2[l]);
            }
        }

        for(var j = 0; j <= numLines; j++)
        {

            // console.log("this:", lines2[j]);


            var k = 0;
            while(lines[j][k] !== "*")
            {
                if(k == lines[j].length)
                {
                    break;
                }
                k++;
            }

            if(lines[j][k] == "*")
            {
                var modifiedLine = lines[j].replace("*", "<span class='hide'>*</span>");
                
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
        console.log("Focus Out Event Fired");
        
        var word =  this.closest(".word");
        var WordId = word.getAttribute("id");

        console.log("WordId:", WordId);
        console.log("this: ", this);

        var NoteId = 1;
        if(count > 0){
            // console.log("You wrote: \n" + this.innerText);
            var DefinitionData = this.innerText;

            //Title
            var TitleData = contents[0].innerText;
            // console.log("TitleData:", TitleData);

            // Fetch API to send request to update definition
            fetch(`Word/${WordId}/UpdateNote/${NoteId}`, {
                method: 'POST',
                headers: {
                    'Content-Type':'application/json'
                },
                body: JSON.stringify({Title: TitleData})
            })
            .then(res => {
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

// var lastKeyCode = '';
// var inputFields = document.querySelectorAll(".panel");
// for(var i = 0; i < inputFields.length; i++){
//     inputFields[i].addEventListener("keydown", function(e){
//         // console.log("lastKey:", lastKeyCode);
//         // console.log("current:", e.keyCode);

//         //Grab contents of panel
//         console.log("contents:", this.querySelector(".panel"));

//         if(lastKeyCode == 56 && e.keyCode == 32){
//             console.log("Last character was a space, followed by an *");



//             console.log("this:", this.querySelector(".contents").innerText).match(/\n/g)||[];
//         }


//         if(e.keyCode != 16){
//             lastKeyCode = e.keyCode;
//         }
//     })
// }

// function printText(e, element){
//     console.log("this:", element.children);

//     var numLines = (element.innerText.match(/\n/g)||[]).length;
//     var lines = element.innerText.split(/\r?\n/g);
//     var newString = '';

//     for(var i = 0; i < numLines; i++){
//         console.log(lines[i].tagName);
//     }




//     // var numLines = (contents.innerText.match(/\n/g)||[]).length;
//     // var lines = contents.innerText.split(/\r?\n/g);
// }

// var lastKeyCode = '';
// document.getElementById("definitionBox").addEventListener("keydown", function(e){
//     console.log(e.keyCode);
//     if(lastKeyCode == 56 && e.keyCode == 32){

//         console.log("Last character was a space, followed by an *");
//         console.log("lieheight");
//         var contents = this.innerHTML;
//         this.innerHTML = `<li>${contents}</li>`;
//     }
//     if(e.keyCode != 16){
//         lastKeyCode = e.keyCode;
//     }
// })

// function openAll(){
//     var panels = document.getElementsByClassName("panel");
//     console.log("panels:", panels);
//     for(var i = 0; i < panels.length; i++){
//         console.log("panel:" + i + ": " + panels[i]);
//         // var content = panels.querySelectorAll(".contents");
//         // console.log("Contents:", content);
//     }
// }



// // Detect tab press inside edit area, change class to next edit
// var contents = document.getElementsByClassName("contents");
// var lastKeyCode = '';
// for(var i = 0; i < contents.length; i++){
//     contents[i].addEventListener("keydown", function(e){
//         console.log("Key pressed:", e.keyCode);
//         if(e.keyCode == 9){
//             console.log("this", this);
//         }
//     })
// }