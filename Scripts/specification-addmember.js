//Add Members Script

function GetMemberDropdown(value) {
    return '<div><label for= "member"> Choose member:</label><input type = "text" id="member" name="member"><input type="button" onclick="RemoveMemberDropdown()" value="Remove Member" /></div>';
}

function AddMemberDropdown() {
    var div = document.createElement('DIV');
    div.innerHTML = GetMemberDropdown("");
    document.getElementById("memberBox").appendChild(div);
}

function RemoveMemberDropdown(div) {
    document.getElementById("memberBox").removeChild(div.parentNode.parentNode);
}

function SubmitGroup() {
    groupNameList.push(groupname);

}

//Test if this is referred
function testReference() {
    console.log("IM BEING REFEREHNCED FROM SPECIFICATION-COVERAGE.JS");
}

function SubmitGroupName() {
    groupNameList.push(groupname);
    console.log(groupNameList);
    console.log(groupname);
}