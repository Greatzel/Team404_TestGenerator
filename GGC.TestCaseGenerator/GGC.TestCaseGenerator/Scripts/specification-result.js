document.getElementById('import').onclick = function () {
    var files = document.getElementById('selectFiles').files;
    console.log(files);
    if (files.length <= 0) {
        return false;
    }

    var fr = new FileReader();

    fr.onload = function (e) {
        console.log(e);
        var result = JSON.parse(e.target.result);
        var formatted = JSON.stringify(result, null, 2);
        document.getElementById('result').value = formatted;
    }

    fr.readAsText(files.item(0));
};



function resultShow() {

        //=============Retrieve result==========

        //Add Spec
        var specNameRetrieve = JSON.parse(localStorage.getItem('specificationName'));
        var specTextRetrieve = JSON.parse(localStorage.getItem('specificationText'));

        //Input Param - TEST
        console.log("Loaded Function");
        var inputParametersList = JSON.parse(localStorage.getItem('inputNameSeshStored'));
        console.log(inputParametersList);

        var inputParametersList = JSON.parse(localStorage.getItem('inputNameSeshStored'));
        console.log(inputParametersList);

        //Coverage Group

        
        var coverageMemberList = JSON.parse(localStorage.getItem('memberList'));
        var groupName = JSON.parse(localStorage.getItem('groupName'));
        console.log(inputParametersList);

        //Expected REsults
        var expectedResultName = JSON.parse(localStorage.getItem('expectedResName'));
        var expectedResultText = JSON.parse(localStorage.getItem('expectedResText'));
        var expectedResultCondition = JSON.parse(localStorage.getItem('expectedResCon'));


        //==============Show result============

        //Specification Tab
        var res = document.getElementById('showRes');
        res.innerHTML += "Specification Name: <input type ='text' name= 'specNameRes' id= 'text' value='"
            + specNameRetrieve + "'</input><br><br>";
        var res = document.getElementById('showRes');
    res.innerHTML += "Specification Text: <input type ='text'  name= 'specTextRes' id= 'text' value='"
            + specTextRetrieve + "'</input><br><br>";

        //Input Param Names List
    res.innerHTML += "Input Parameters List: <input type ='text' name= 'inputParameters' id= 'text' value='"
            + inputParametersList + "'</input><br><br>";

        //Equivalence Classes
    res.innerHTML += "Equivalence Classes: <input type ='text' name= 'equivalenceClasses' id= 'text' value='Test Value'</input><br><br>";

        //Coverage Group Tab
    res.innerHTML += "Group Name: <input type ='text' name= 'groupNameRes' id= 'text' value='"
            + groupName + "'</input><br><br>";
    res.innerHTML += "Member List: <input type ='text' name= 'groupMemberRes' id= 'text' value='"
            + coverageMemberList + "'</input><br><br>";

        //Expected Results Tab
    res.innerHTML += "Expected Results List: <input type ='text' name= 'expectedResultName' id= 'text' value='"
        + expectedResultName + "'</input><br><br>";
    res.innerHTML += "Expected Results List: <input type ='text' name= 'expectedResultText' id= 'text' value='"
        + expectedResultText + "'</input><br><br>";
    res.innerHTML += "Expected Results List: <input type ='text' name= 'expectedResultCondition' id= 'text' value='"
        + expectedResultCondition + "'</input><br><br>";


}

function storageClear() {
    localStorage.clear();
}