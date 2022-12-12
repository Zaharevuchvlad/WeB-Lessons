const list = document.getElementsByClassName("table table-hover")[0].querySelector("tbody");

const addBtn = document.getElementById("styled-button");
const clearBtn = document.getElementById("clear-button");

const nameBox = document.getElementById("name");
const terminBox = document.getElementById("termin");
const priorityBox = document.getElementById("priority");
const tegBox = document.getElementById("teg");
const opusBox = document.getElementById("Opus");
const listBox = document.getElementById("list");


const searchBox = document.getElementById("search");

let removed = [];

function addItem(text, type, toLast, innrhtml = "") {
    let item = document.createElement(type);
    item.innerText = text;
    if (innrhtml != "")
    {
        item.innerHTML = innrhtml;
        item.firstChild.addEventListener('click', function handleClick(_event) {
            removed.splice(removed.indexOf(item.parentElement));
            list.removeChild(item.parentElement);
          });
        item.firstChild.value = "X";
    }
    if (toLast) {
        list.lastChild.appendChild(item);
    } else {
        list.appendChild(item);
    }
}

let onin = searchBox.oninput = () => {
    if (searchBox.value != "") {
        for (let i = 0; i < list.children.length; i++) {
            if (!(list.children[i].firstChild.innerText.toLowerCase().startsWith(searchBox.value.toLowerCase()))) {
                removed.push(list.children[i]);
                list.removeChild(list.children[i]);
            }
        }
        for (let i = 0; i < removed.length; i++) {
            if (removed[i].firstChild.innerText.toLowerCase().startsWith(searchBox.value.toLowerCase())) {
                list.appendChild(removed[i]);
            }
        }
    }
    else {
        for (let i = 0; i < removed.length; i++) {
            list.appendChild(removed[i]);
            removed.splice(i);
        }
    }
}

addBtn.onclick = () => {
    if (nameBox.value != "" &&
        terminBox.value != "" &&
        priorityBox.value != "" &&
        tegBox.value != "" &&
        opusBox.value != "") {
        addItem("", "tr", false);
        
        addItem(nameBox.value, "td", true);
        addItem(terminBox.value, "td", true);
        addItem(priorityBox.value, "td", true);
        addItem(tegBox.value, "td", true);
        addItem(opusBox.value,"td", true);

        addItem("","td", true, "<input type=\"checkbox\"></input>");
        addItem("", "td", true, "<input type=\"button\" class=\"btn btn-danger\"></input>");
        
        
        

        buffer = list;
        onin();
    }
}

clearBtn.onclick = () => {
    list.innerHTML = "";
}

var tds = document.querySelectorAll('th')
for(var i =0; i<tds.length; i++)
{
    tds[i].addEventListener('click', function func(){
        var input = document.createElement('input');
        input.value = this.innerHTML;
        this.innerHTML = '';
        this.appendChild(input);

        var td =this;
        input.addEventListener('blur', function(){
td.innerHTML=this.value;
td.addEventListener('click', func);
        });
        this.removeEventListener('click',func);
    })
}