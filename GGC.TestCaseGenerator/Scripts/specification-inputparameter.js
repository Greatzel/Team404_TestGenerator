function someFunc() {
    addRecord();
    submitTest();
}
let addButton = document.querySelector('#add');
let displayButton = document.querySelector('#display');
//Equilvalence Class Array Below:
let recordsName = [];
let recordsText = [];
//Input Parameters Array Below:
let InputName = [];
let InputText = [];
var counter = 0;
addButton.addEventListener('click', addRecord);
displayButton.addEventListener('click', displayAll);
function appendRow2() {
    counter++;
    var t = document.getElementById('IP2');
    t.innerHTML += "<br>Enter Equilvalence class Name: <input type='text' id='EquilvalenceClassesName" + counter + "'><br >";
    t.innerHTML += "Enter Equilavalence Class Text:<input type='text' id='EquilvalenceClassesText" + counter + "'><br >";
}
//<===========Test data fetching by Greatzel===========>
function submitTest() {
    console.log("Button Pressed");
    for (var i = 1; i <= counter; i++) {
        var equivalenceClass = document.getElementById('EquilvalenceClassesName' + i);
        var equivalenceText = document.getElementById('EquilvalenceClassesText' + i);
        var equivalanceClassVal = equivalenceClass.value;
        var equivalanceTextVal = equivalenceText.value;
        recordsName.push(equivalanceClassVal);
        recordsText.push(equivalanceTextVal);
    }
}
//<====================================================>

//<===========Test data sending by Greatzel===========>

var testArray = ["P1", "P2", "P3", "P4", "P5"];
var inputJsonString = localStorage.setItem('inputNameSeshStored', JSON.stringify(testArray));
console.log(testls);

//<====================================================>

function addRecord() {
    let record = document.querySelector('#IPara1').value;
    let record2 = document.querySelector('#IPara2').value;
    if (!record) {
        return;
    }
    if (!record2) {
        return;
    }
    InputName.push(record);
    InputText.push(record2);
    document.querySelector('#IPara1').value = '';
    document.querySelector('#IPara2').value = '';
}
function displayAll() {
    alert(InputName)
    alert(InputText)
    alert(recordsName)
    alert(recordsText)
    console.log("submitTest className Array Check " + InputName);
    console.log("submitTest classText Array Check " + InputText);
    console.log("submitTest className Array Check " + recordsName);
    console.log("submitTest classText Array Check " + recordsText);
}