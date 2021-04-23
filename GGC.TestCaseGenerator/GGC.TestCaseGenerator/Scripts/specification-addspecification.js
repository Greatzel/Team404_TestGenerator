var specificationName = document.getElementById('specificationName');
var specificationText = document.getElementById('specificationTextName');


function submitSpec() {
    var specificationName = document.getElementById('specificationName');
    var specificationText = document.getElementById('specificationTextName');

    var specNameTest = specificationName.value;
    var specTextTest = specificationText.value;

    console.log(specNameTest);
    console.log(specTextTest);
    var coverageGroupNameList = localStorage.setItem('specificationName', JSON.stringify(specNameTest));
    var coverageMemberList = localStorage.setItem('specificationText', JSON.stringify(specTextTest));
}