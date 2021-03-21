var inputParamsList = ["Parameter 1", "Parameter 2", "Parameter 3"];

//Test if this is referred
function testReference() {
    console.log("IM BEING REFEREHNCED FROM SPECIFICATION-COVERAGE.JS");
}

//Add Coverage Group Name Script

var groupNameList = [];
var groupname = document.getElementById("groupname").value;

var member = document.getElementById('member').value;

function GetDynamicTextbox(value) {
    return '<div><input type="text" name="groupname" style="width:200px" /><input type ="button" onclick="RemoveTextBox(this)" value="Remove Group Name"/></div>';
}

function AddInputField() {
    var div = document.createElement('DIV');
    div.innerHTML = GetDynamicTextbox("");
    document.getElementById("CovGroupName").appendChild(div);
}

function RemoveTextBox(div) {
    document.getElementById("CovGroupName").removeChild(div.parentNode.parentNode);
}

function SubmitGroupName() {
    groupNameList.push(groupname);
    console.log(groupNameList);
    console.log(groupname);
}

//Add Members Script

function GetMemberDropdown(value) {
    return '<div><label for= "member"> Choose member:</label><select id="member" name="member"><option value="Val1">Value 1</option><option value="Val2">Value 2</option><option value="Val3">Value 3</option><option value="Val4">Value 4</option></select><input type="button" onclick="RemoveMemberDropdown()" value="Remove Member" /></div>';
}

function AddMemberDropdown() {
    var div = document.createElement('DIV');
    div.innerHTML = GetMemberDropdown("");
    document.getElementById("memberBox").appendChild(div);
}

function RemoveMemberDropdown(div) {
    document.getElementById("memberBox").removeChild(div.parentNode.parentNode);
}

function SubmitGroupName() {
    groupNameList.push(groupname);
    console.log(groupNameList);
    console.log(groupname);
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