    function someFunc() {
        addRecord();
        submitTest();
        save();
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

        t.innerHTML += "<br><b>Enter other Equilavalence Classes:</br>"
        t.innerHTML += "<br>Enter Equilvalence class Name: <input type='text' id='EquilvalenceClassesName" + counter + "'><br >";
        t.innerHTML += "Enter Equilavalence Class Text:<input type='text' id='EquilvalenceClassesText" + counter + "'><br >";
        }

    //<===========Test data fetching by Greatzel===========>
                console.log("Button Pressed");
            var equivalenceClass = document.getElementById('EquilvalenceClassesName' + i);
            var equivalenceText = document.getElementById('EquilvalenceClassesText' + i);
            var equivalanceClassVal = equivalenceClass.value;
            var equivalanceTextVal = equivalenceText.value;
        }
        console.log("submitTest className Array Check " + classNameArray);
        console.log("submitTest classText Array Check " + classTextArray);
    }
    //<====================================================>

    let addButton = document.querySelector('#add');
    let displayButton = document.querySelector('#display');
    let recordsName = [];
    let recordsNametst = [];
    let recordsText = [];

    addButton.addEventListener('click', addRecord);
    displayButton.addEventListener('click', displayAll);

    function addRecord() {
                let record = document.querySelector('#IPara1').value;
        let record2 = document.querySelector('#IPara2').value;
        let record3 = document.querySelector('#IEC1').value;
        let record4 = document.querySelector('#IEC2').value;
        if (!record) {
            return;
        }
        if (!record2) {
            return;
        }
        document.querySelector('#IPara1').value = '';
        document.querySelector('#IPara2').value = '';
        document.querySelector('#IEC1').value = '';
        document.querySelector('#IEC2').value = '';
        }
    function addrecord2() {
        var tst;
            element = document.querySelector('EquilvalenceClassesName');
        if (element != null) {
                    tst = element.value;
        }
        else {
                    tst = null;
}
        }
function displayAll() {
        
        alert(InputName)
        alert(InputText)
        alert(recordsName)
        alert(recordsText)
    }