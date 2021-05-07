﻿document.getElementById('import').onclick = function () {
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
        var specNameRetrieve = localStorage.getItem('specificationName');
        var specTextRetrieve = localStorage.getItem('specificationText');

        //Input Param - TEST
        console.log("Loaded Function");
        var inputParametersList = localStorage.getItem('inputNameSeshStored');
        console.log(inputParametersList);
        var inputParametersList = localStorage.getItem('inputNameSeshStored');
        console.log(inputParametersList);

        //Coverage Group
        var coverageMemberList = localStorage.getItem('memberList');
        var groupName = localStorage.getItem('groupName');
        console.log(inputParametersList);

    //Expected REsults
        var expectedResultsNameRetrieve = localStorage.getItem('ExpectedResultsNameVal');
        var expectedResultsTextRetrieve = localStorage.getItem('ExpectedResultsNameVal');
        var expectedResultsConditionRetrieve = localStorage.getItem('ExpectedResultsNameVal');
        //==============Show result============

        //Specification Tab
        var res = document.getElementById('showRes');
        res.innerHTML += "Specification Name: <input type ='text' id= 'text' value='"
            + specNameRetrieve + "'</input><br><br>";
        var res = document.getElementById('showRes');
        res.innerHTML += "Specification Text: <input type ='text' id= 'text' value='"
            + specTextRetrieve + "'</input><br><br>";

        //Input Param Names List
        res.innerHTML += "Input Parameters List: <input type ='text' id= 'text' value='"
            + inputParametersList + "'</input><br><br>";

        //Equivalence Classes
        res.innerHTML += "Equivalence Classes: <input type ='text' id= 'text' value= </input><br><br>";
        //Coverage Group Tab
        res.innerHTML += "Group Name: <input type ='text' id= 'text' value='"
            + groupName + "'</input><br><br>";
        res.innerHTML += "Member List: <input type ='text' id= 'text' value='"
            + coverageMemberList + "'</input><br><br>";

        //Expected Results Tab
        res.innerHTML += "Expected Result Name: <input type ='text' id= 'text' value='"
        + expectedResultsNameRetrieve + "'</input><br><br>";
        res.innerHTML += "Expected Result Text: <input type ='text' id= 'text' value='"
            + expectedResultsTextRetrieve + "'</input><br><br>";
        res.innerHTML += "Expected Result Condition: <input type ='text' id= 'text' value='"
            + expectedResultsConditionRetrieve + "'</input><br><br>";




}