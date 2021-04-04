
    var counter = 0;
    function appendRow2() {
        counter++;
        var t = document.getElementById('IP2');

        t.innerHTML += "<br><b>Enter other Equilavalence Classes:</br>"
        t.innerHTML += "<br>Enter Equilvalence class Name: <input type='text' id='EquilvalenceClassesName" + counter + "'><br >";
        t.innerHTML += "Enter Equilavalence Class Text:<input type='text' id='EquilvalenceClassesText" + counter + "'><br >";
            }

    //<===========Test data fetching by Greatzel===========>

    function submitTest()
    {
        var classNameArray = [];
        var classTextArray = [];
        console.log("Button Pressed");

        for (var i = 1; i <= counter; i++ )
        {
            var equivalenceClass = document.getElementById('EquilvalenceClassesName' + i);
            var equivalenceText = document.getElementById('EquilvalenceClassesText' + i);
            var equivalanceClassVal = equivalenceClass.value;
            var equivalanceTextVal = equivalenceText.value;
            classNameArray.push(equivalanceClassVal);
            classTextArray.push(equivalanceTextVal);
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
        if (!record3) {
            return;
        }
        if (!record4) {
            return;
        }
        recordsName.push(record);
        recordsText.push(record2);
        recordsName.push(record3);
        recordsText.push(record4);
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
        console.log("im being clicked");
    }
    function displayAll() {

                    alert(recordsName)
        alert(recordsText)
        console.log(recordsName);
        console.log(recordsText);
        console.log(recordsNametst);
    }  