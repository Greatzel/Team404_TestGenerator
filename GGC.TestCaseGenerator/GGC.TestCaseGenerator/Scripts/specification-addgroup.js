//Add Coverage Group Name Script

var groupMemberList = [];
var inputParamsList = ["Param 1", "Param 2", "Param 3", "Param 4", "Param 5"];
var groupName = document.getElementById('groupname');

//coverage group constructor function
function coveragegroup(name, members) {
    this.name = name;
    this.members = members;
}

//=========================retrieve test 1 ==============================

var inputGet = localStorage.getItem('inputNameSeshStored');
console.log(inputGet);

var inputList = inputGet.split(',');

var finalInputList = [];



for (var i = 0; i <= inputList.length - 1; i++) {
    console.log("Value " + i);
    if (i === 0) {
        var holder = inputList[i].substring(2, inputList[i].length - 1);
        console.log("Holder var " + holder);
        finalInputList.push(holder);
    }
    else if (i !== inputList.length - 1) {
        var holder2 = inputList[i].substring(1, inputList[i].length - 1);
        finalInputList.push(holder2);
        console.log("Holder2 var " + holder2);
    }
    else if (i === inputList.length - 1) {
        var holder1 = inputList[i].substring(1, inputList[i].length - 2);
        finalInputList.push(holder1);
        console.log("Holder1 var " + holder1);
    }
}

console.log(finalInputList);
console.log(inputList);

//===================================================================================

//IT WORKS!!!!!!!!!!! MEMBERS DROPDOWN

var nameval5 = 1
var testval5 = 1;
var idval5 = 0;
var counter = 0;
var appendCount5 = 0;

var selectedMembers = [];

function appendRow5() {
    counter++;

    var t = document.getElementById('dropDownID5');
    t.innerHTML += "<br><b>Select Members:</b>";
    t.innerHTML += "<select id='selectMemberID" + counter + "' name='memberSelect" + counter + "'>";
    var selectTest = document.getElementById('selectMemberID' + counter);
    console.log(selectTest.value);
    for (var i = 0; i <= finalInputList.length - 1; i++) {

        selectTest.innerHTML += "<option name= 'Name" + finalInputList[i] + "' value = '" + finalInputList[i] + "'>"
            + finalInputList[i] + "</option>";

    }
    var htmlSelectMember = document.getElementById('memberSelect' + counter);
    selectedMembers.push(htmlSelectMember).value;
    console.log("SELECT MEMBERS: " + selectedMembers);
    t.innerHTML += "</select><br />";
}

function SubmitGroupName() {
    console.log("SubmitGroupName Select5 num: " + counter);
    for (var i = 1; i <= counter; i++) {
        var members = document.getElementById('selectMemberID' + i);
        var memberValue = members.value;
        console.log("Variable Members " + memberValue);
        groupMemberList.push(memberValue);
        console.log(groupMemberList);
    }


    var groupNameVar = groupName.value;
    var coverageMemberList = localStorage.setItem('memberList', JSON.stringify(groupMemberList));
    var coverageGroupNameList = localStorage.setItem('groupName', JSON.stringify(groupNameVar));

    var res = document.getElementById('results');
    res.innerHTML += "<input type = 'hidden' name='CoverageGroupArrayName' value='"
        + groupMemberList + "' />";
    console.log(groupMemberList);
}

