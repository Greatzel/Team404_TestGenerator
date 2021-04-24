


function submitSpec() {
    var specificationName = document.getElementById("specificationNameId").value;
    var specificationText = document.getElementById("specificationTextId").value;

    var specNameTest = specificationName;
    var specTextTest = specificationText;

    console.log(specNameTest);
    console.log(specTextTest);
    var coverageGroupNameList = localStorage.setItem('specificationName', JSON.stringify(specNameTest));
    var coverageMemberList = localStorage.setItem('specificationText', JSON.stringify(specTextTest));
}