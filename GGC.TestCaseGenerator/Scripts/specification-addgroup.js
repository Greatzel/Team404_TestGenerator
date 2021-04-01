var inputParamsList = ["Parameter 1", "Parameter 2", "Parameter 3"];

//Add Coverage Group Name Script

var groupNameList = [];
var groupname = document.getElementById("groupname").value;

function GetDynamicTextbox(value) {
    return '<div><input type="text" id="groupmember" name="member" style="width:200px" /><input type ="button" onclick="RemoveTextBox(this)" value="Remove Members"/></div>';
}

function AddInputField() {
    var div = document.createElement('DIV');
    div.innerHTML = GetDynamicTextbox("");
    document.getElementById("CovGroupName").appendChild(div);
    console.log(groupname);    
}

function RemoveTextBox(div) {
    document.getElementById("CovGroupName").removeChild(div.parentNode.parentNode);
}

function SubmitGroupName() {
    groupNameList.push(groupname);
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