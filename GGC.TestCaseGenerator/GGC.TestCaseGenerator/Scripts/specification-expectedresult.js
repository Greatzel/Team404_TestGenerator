﻿//Expected Results Arrays below:
let ExpectedResultsName = [];
let ExpectedResultsText = [];
let ExpectedResultsCondition = [];
counting = 0;
function appendRow() {
    counting++;
    var h = document.getElementById('ER1');
    h.innerHTML += "<br>Enter Expected Results Name: <input type='text' id='ExpectedResultsName1" + counting + "'><br >";
    h.innerHTML += "Enter Expected Results Text:<input type='text' id='ExpectedResultsText1" + counting + "'><br >";
    h.innerHTML += "Enter Expected Results Condition: <input type='text' id='ExpectedResultsCondition1" + counting + "'><br >";
}

function submittingExtraExpectedResults() {
    console.log("Im being cLicked");
    for (var g = 1; g <= counting; g++) {
        var ECName = document.getElementById('ExpectedResultsName1' + g);
        var ECText = document.getElementById('ExpectedResultsText1' + g);
        var ECCondition = document.getElementById('ExpectedResultsCondition1' + g);

        var ExpectedResultsNameVal = ECName.value;
        var ExpectedResultsTextVal = ECText.value;
        var ExpectedResultsConditionVal = ECCondition.value;

        ExpectedResultsName.push(ExpectedResultsNameVal);
        ExpectedResultsText.push(ExpectedResultsTextVal);
        ExpectedResultsCondition.push(ExpectedResultsConditionVal);

        var ExpectedResultsNameList = localStorage.setItem('ExpectedResultsName1', JSON.stringify(ExpectedResultsName));
        var ExpectedResultsTextVal = localStorage.setItem('ExpectedResultsText1', JSON.stringify(ExpectedResultsText));
        var ExpectedResultsConditionVal = localStorage.setItem('ExpectedResultsCondition1', JSON.stringify(ExpectedResultsCondition));
    }
}

function displayAllArrayData() {
    alert(ExpectedResultsName);
    alert(ExpectedResultsText);
    alert(ExpectedResultsCondition);
    console.log("submitTest ExpectedResultsName Array Check " + ExpectedResultsName);
    console.log("submitTest ExpectedResultstext Array Check " + ExpectedResultsText);
    console.log("submitTest ExpectedResultsCondition Array Check " + ExpectedResultsCondition);
}