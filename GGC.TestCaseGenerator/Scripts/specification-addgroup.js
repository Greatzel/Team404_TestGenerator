//Add Coverage Group Name Script

var groupMemberList = [];
var inputParamsList = ["Parameter 1", "Parameter 2", "Parameter 3", "Parameter 4", "Parameter 5"];

function GetDynamicTextbox(value) {
    return '<div><input type="text" id="groupmember" name="member" style="width:200px" /><input type ="button" onclick="RemoveTextBox(this)" value="Remove Members"/></div>';
}

function AddInputField() {
    var div = document.createElement('DIV');
    div.innerHTML = GetDynamicTextbox("");
    document.getElementById("CovGroupName").appendChild(div);
    console.log(covGroupName);    
}

function RemoveTextBox(div) {
    document.getElementById("CovGroupName").removeChild(div.parentNode.parentNode);
}

//Generate Group Names List Labels
function GroupNamesList() {
    for (var i = 0; i <= inputParamsList.length; i++) {
        var div = document.createElement('div');
        div.innerHTML = GetMemberSetDropdown("");
        document.getElementById("groupNamesList");
    }
}

function GetMemberSetDropdown(value) {
    return '<div id="selectMember">< label for= "members" > Group A:</label ><input type="button" onclick="AddMemberDropdown()" value="Add Members" /><input type="button" onclick="testReference()" value="TEST REF" /><div id="memberBox" style="padding-left: 50px;"></div></div > <br />';
}

//Generate Member Drop down non-Functional

var select = document.getElementById("selectNumber");

for (var i = 0; i < inputParamsList.length; i++) {
    var opt = inputParamsList[i];
    var el = document.createElement("option");
    el.textContent = opt;
    el.value = opt;
    select.appendChild(el);
}

//Generate Member Dropdown -- Functional

var nameval = 1
var testval = 1;
var idval = 1;
function appendRow2() {
    var t = document.getElementById('dropDownID');
    t.innerHTML += "<br><b>Select Members:</b>"
    t.innerHTML += "<input type='text' value = 'Test" + testval++ +"' name='memberSelect"
        + nameval++ + "' id='selectMember" + idval++ + "'><br >";
}

//non functional test

var nameval1 = 1
var testval1 = 1;
var idval1 = 1;
var select1 = 1;
var appendCount = 0;

function appendRow3() {
    var t = document.getElementById('dropDownID2');
    t.innerHTML += "<br><b>Select Members:</b>"
    t.innerHTML += "<select id='selectMemberID' name='memberSelect>" + testval1++ + "' name='memberSelect"
        + nameval1++ + "' id='selectMember" + idval1++ + "'>";

    for (var i = 0; i <= inputParamsList.length; i++)
    {
        var selectTest = document.getElementById('selectMemberID');
        selectTest.innerHTML += "<option>appendRow3() TEST" + inputParamsList[i]+ "</option>";

    }

    t.innerHTML += "</select><br />"
}

//IT WORKS!!!!!!!!!!! MEMBERS DROPDOWN

var nameval5 = 1
var testval5 = 1;
var idval5 = 0;
var select5 = 0;
var appendCount5 = 0;


function appendRow5() {
    select5++;
    var t = document.getElementById('dropDownID5');
    t.innerHTML += "<br><b>Select Members:</b>"
    t.innerHTML += "<select id='selectMemberID" + select5 + "' name='memberSelect" + select5 + "'>";
    var selectTest = document.getElementById('selectMemberID' + select5);
    console.log(selectTest.value);
    for (var i = 0; i <= inputParamsList.length-1; i++) {

        selectTest.innerHTML += "<option name= 'Name" + inputParamsList[i] + "' value = '" + inputParamsList[i] +"'>appendRow5() TEST "
            + inputParamsList[i] + "</option>";

    }
    console.log("appenRow5 TEST");
    t.innerHTML += "</select><br />"
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
    console.log(groupMemberList);
}

