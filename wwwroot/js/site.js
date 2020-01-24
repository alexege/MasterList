// On initial page load
$(document).ready(function(){
    if(localStorage.getItem("lockNav") == null){
        document.getElementById("navToggleButton").innerHTML='<i class="fas fa-lock-open"></i>';
        localStorage.setItem("lockNav", false);
    }
    AddEventListeners();
})

function AddEventListeners(){
    collapseAccordion();
    applyFocusOutEvent();
    toggleBulletPoint();
    indentNote();
    outdentNote();
    deleteNote();
    changeStyle();
}

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
    console.log("--[Locking Navbar]--");
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
function collapseAccordion(){
    console.log("--[Collapse Accordion]--");
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
}

function openWordAccordion(word){
    console.log("--[Open Word Accordion]--");
    var element = document.getElementById(word);
    var display = element.style.display;
    
    if(display == "none" || display == ""){
        element.nextElementSibling.style.display = "block";
    }
}

function editWordTitle(event, element) {
    console.log("--[Editing Word Title]--");
    var contents = element.closest("button").querySelector(".content");
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

// Display word configuration menu
function showMenu(word){
    word.querySelector('.menu').style.display = "inline-block";
}

// Hide word configuration menu
function hideMenu(word){
    word.querySelector('.menu').style.display = "none";
}

// Check if user entered anythign into the edit box
function applyFocusOutEvent(){
    console.log("--[Applying FocusOut Event]--");
    var contents = document.getElementsByClassName("content");
    console.log("contents:", contents);
    for(var i = 0; i < contents.length; i++){
        var count = 0;
        contents[i].addEventListener("input", function(){
            count++;
        }, false);

        contents[i].addEventListener("keydown", function(e){
            console.log("key:", e.keyCode);

            console.log("this:", this);
            
            // Listen for Up key press
            if(e.keyCode == 38){
                if(this.previousElementSibling.tagName == "DIV"){
                    this.previousElementSibling.focus();
                } else {
                    console.log("Next element is not an editable div");
                }
            }

            // Listen for  key press
            if(e.keyCode == 40){
                if(this.nextElementSibling.tagName == "DIV"){
                    this.nextElementSibling.focus();
                } else {
                    console.log("Next element is not an editable div");
                }
            }
        })

        contents[i].addEventListener("focusout", function(){
            console.log("Focus Out Event Fired");

            var word =  this.closest(".word");
            var WordId = word.getAttribute("id");
            var NoteId = this.getAttribute("id");

            console.log("Length of note:", this.innerText.length);

            if(this.innerText.length == 0){
                console.log("Length of note was 0, deleting note.")
                fetch(`Word/${WordId}/DeleteNote/${NoteId}`, {
                    method: 'DELETE',
                    headers: {
                        'Content-Type':'application/json'
                    },
                })
                .then(res => {
                    console.log(res);
                })
                .catch(err => {
                    console.log("There was an error deleting the note: ", err);
                })
            }

            console.log("NoteId:", NoteId);
            if(count > 0){
                //Title
                var ContentData = this.innerText;
                // console.log("TitleData:", TitleData);

                // Fetch API to send request to update definition
                fetch(`Word/${WordId}/UpdateNote/${NoteId}`, {
                    method: 'POST',
                    headers: {
                        'Content-Type':'application/json'
                    },
                    body: JSON.stringify({Content: ContentData})
                })
                .then(res => {
                    console.log(res);
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
}

// var contents = document.getElementsByClassName("content");
// console.log("contents:", contents);

// var count = 0;
// for(var i = 0; i < contents.length; i++){
//     contents[i].addEventListener("input", function(){
//         count++;
//         console.log("count:", count);
//     }, false)
// }

// document.querySelectorAll(".content").forEach(item => {
//     console.log("item:", item);
//     item.addEventListener("input", e => {
//         console.log(e);
//     })
// })

// Toggle Bullet Point
function toggleBulletPoint(){
    console.log("--[Toggling Bullet Point]--");
    document.querySelectorAll(".fa-list-ul").forEach(item => {
        item.addEventListener("click", e => {
        e.preventDefault();

        console.log(e.target);

        var word =  e.target.closest(".word");
        var WordId = word.getAttribute("id");
        var NoteId = e.target.closest(".contents").querySelector(".content").getAttribute("id");
        var Note = e.target.closest(".contents").querySelector(".replaceContent")

        // Fetch API to send request to update definition
        fetch(`Word/${WordId}/Note/${NoteId}/ToggleBullets`, {
            method: 'POST',
            headers: {
                'Content-Type':'application/json'
            },
            body: JSON.stringify({NoteId: NoteId}, {WordId: WordId})
        })
        .then(res => {
            console.log(res);
            return res.text();
        })
        .then(result => {
            console.log("result", result);
            console.log("note:", Note);
            Note.innerHTML = result;
            applyFocusOutEvent();
            // $("#output").html(result);
        })
        .catch(err => {
            console.log("Error found: ", err);
        });
    })
    });
}

// Indent Note
function indentNote(){
    console.log("--[Indenting Note]--");
    document.querySelectorAll(".fa-indent").forEach(item => {
        item.addEventListener("click", e => {
        e.preventDefault();

        console.log(e.target);

        var word =  e.target.closest(".word");
        var WordId = word.getAttribute("id");
        var NoteId = e.target.closest(".contents").querySelector(".content").getAttribute("id");
        var Note = e.target.closest(".contents").querySelector(".replaceContent")

        // Fetch API to send request to update definition
        fetch(`Word/${WordId}/Note/${NoteId}/Indent`, {
            method: 'POST',
            headers: {
                'Content-Type':'application/json'
            },
            body: JSON.stringify({NoteId: NoteId}, {WordId: WordId})
        })
        .then(res => {
            console.log(res);
            return res.text();
        })
        .then(result => {
            console.log("result", result);
            console.log("note:", Note);
            Note.innerHTML = result;
            applyFocusOutEvent();
            // $("#output").html(result);
        })
        .catch(err => {
            console.log("Error found: ", err);
        });
    })
    });
}

// Outdent Note
function outdentNote(){
    console.log("--[Outdenting Note]--");
    document.querySelectorAll(".fa-outdent").forEach(item => {
        item.addEventListener("click", e => {
        e.preventDefault();

        console.log(e.target);

        var word =  e.target.closest(".word");
        var WordId = word.getAttribute("id");
        var NoteId = e.target.closest(".contents").querySelector(".content").getAttribute("id");
        var Note = e.target.closest(".contents").querySelector(".replaceContent")

        // Fetch API to send request to update definition
        fetch(`Word/${WordId}/Note/${NoteId}/Outdent`, {
            method: 'POST',
            headers: {
                'Content-Type':'application/json'
            },
            body: JSON.stringify({NoteId: NoteId}, {WordId: WordId})
        })
        .then(res => {
            console.log(res);
            return res.text();
        })
        .then(result => {
            console.log("result", result);
            console.log("note:", Note);
            Note.innerHTML = result;
            applyFocusOutEvent();
        })
        .catch(err => {
            console.log("Error found: ", err);
        });
    })
    });
}

// Delete Note
function deleteNote(){
    console.log("--[Deleting Note]--");
    document.querySelectorAll(".fa-trash").forEach(item => {
        item.addEventListener("click", e => {
        e.preventDefault();

        console.log(e.target);

        var word =  e.target.closest(".word");
        var WordId = word.getAttribute("id");
        var NoteId = e.target.closest(".contents").querySelector(".content").getAttribute("id");
        var Note = e.target.closest(".contents").querySelector(".replaceContent")

        // Fetch API to send request to update definition
        fetch(`Word/${WordId}/Note/${NoteId}/DeleteNote`, {
            method: 'POST',
            headers: {
                'Content-Type':'application/json'
            },
            body: JSON.stringify({NoteId: NoteId}, {WordId: WordId})
        })
        .then(res => {
            console.log(res);
            return res.text();
        })
        .then(result => {
            console.log("result", result);
            console.log("note:", Note);
            document.getElementsByClassName("words")[0].innerHTML = result;
            AddEventListeners();
        })
        .catch(err => {
            console.log("Error found: ", err);
        });
    })
    });
}

// Change Style
function changeStyle(){
    console.log("--[Changing Note Style]--");
    document.querySelectorAll(".fa-heading").forEach(item => {
        item.addEventListener("click", e => {
        e.preventDefault();

        console.log(e.target);

        var word =  e.target.closest(".word");
        var WordId = word.getAttribute("id");
        var NoteId = e.target.closest(".contents").querySelector(".content").getAttribute("id");
        var Note = e.target.closest(".contents").querySelector(".replaceContent")

        // Fetch API to send request to update definition
        fetch(`Word/${WordId}/Note/${NoteId}/ChangeStyle`, {
            method: 'POST',
            headers: {
                'Content-Type':'application/json'
            },
            body: JSON.stringify({NoteId: NoteId}, {WordId: WordId})
        })
        .then(res => {
            console.log(res);
            return res.text();
        })
        .then(result => {
            console.log("result", result);
            console.log("note:", Note);
            
            document.getElementsByClassName("words")[0].innerHTML = result;
            AddEventListeners();
        })
        .catch(err => {
            console.log("Error found: ", err);
        });
    })
    });
}

function updateAlignment(position, event){
        console.log("position:", position);
        console.log("event:", event);
        var position = position;
        var word =  event.closest(".word");
        var WordId = word.getAttribute("id");
        var NoteId = event.closest(".contents").querySelector(".content").getAttribute("id");
        var Note = event.closest(".contents").querySelector(".replaceContent")

        // Fetch API to send request to update definition
        fetch(`Word/${WordId}/Note/${NoteId}/ChangeAlignment/${position}`, {
            method: 'POST',
            headers: {
                'Content-Type':'application/json'
            },
            // body: JSON.stringify({NoteId: NoteId}, {WordId: WordId}, {Position: 2})
        })
        .then(res => {
            // console.log(res);
            return res.text();
        })
        .then(result => {
            console.log("result", result);
            console.log("note:", Note);
            
            document.getElementsByClassName("words")[0].innerHTML = result;
            AddEventListeners();
        })
        .catch(err => {
            console.log("Error found: ", err);
        });
}