//Add Coverage Group Name Script

var groupMemberList = [];
var inputParamsList = ["Param 1", "Param 2", "Param 3", "Param 4", "Param 5"];

//coverage group constructor function
function coveragegroup(name, members) {
    this.name = name;
    this.members = members;
}

//=========================retrieve test ==============================

var inputGet = localStorage.getItem('inputNameSeshStored');
console.log(inputGet);

var inputList = inputGet.split(',');

var finalInputList = [];

for (var i = 0; i <= inputList.length-1; i++)
{
    console.log( "Value " + i);
    if (i === 0)
        {
            var holder = inputList[i].substring(2, inputList[i].length - 1);
            console.log("Holder var " + holder);
            finalInputList.push(holder);
        }
    else if (i !== inputList.length-1)
        {
            var holder2 = inputList[i].substring(1, inputList[i].length - 1);
            finalInputList.push(holder2);
            console.log("Holder2 var " + holder2);
        }
    else if (i === inputList.length - 1)
        {
            var holder1 = inputList[i].substring(1, inputList[i].length - 2);
            finalInputList.push(holder1);
            console.log("Holder1 var " + holder1);
        }
}

console.log(finalInputList);
console.log(inputList);

//===================================================================

//IT WORKS!!!!!!!!!!! MEMBERS DROPDOWN

var nameval5 = 1
var testval5 = 1;
var idval5 = 0;
var select5 = 0;
var appendCount5 = 0;

function appendRow5() {
    select5++;
    var t = document.getElementById('dropDownID5');
    t.innerHTML += "<br><b>Select Members:</b>";
    t.innerHTML += "<select id='selectMemberID" + select5 + "' name='memberSelect" + select5 + "'>";
    var selectTest = document.getElementById('selectMemberID' + select5);
    console.log(selectTest.value);
    for (var i = 0; i <= inputList.length-1; i++) {

        selectTest.innerHTML += "<option name= 'Name" + inputList[i] + "' value = '" + inputList[i] +"'>"
            + inputList[i] + "</option>";

    }
  
    t.innerHTML += "</select><br />";
}


function SubmitGroupName() {
    console.log("SubmitGroupName Select5 num: " + select5);
    for (var i = 1; i <= select5; i++) {
        var members = document.getElementById('selectMemberID' + i);
        var memberValue = members.value;
        console.log("Variable Members " + memberValue);
        groupMemberList.push(memberValue);
        console.log(groupMemberList);
    }

    var res = document.getElementById('results');
    res.innerHTML += "<input type = 'hidden' name='CoverageGroupArrayName' value='"
        + groupMemberList + "' />";
    console.log(groupMemberList);
}
