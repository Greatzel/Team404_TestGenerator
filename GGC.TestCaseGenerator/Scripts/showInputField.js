var inputParamsList = ["Parameter 1", "Parameter 2","Parameter 3"];

/*document.getElementById('generate').onclick = function () {

    console.log("IM BEING REFEREHNCED");
    var select = document.createElement("select");
    select.name = "Parameter";
    select.id = "params"

        for (const val of inputParamsList) {
            var option = document.createElement("option");
            option.value = val;
            option.text = val.charAt(0).toUpperCase() + val.slice(1);
            select.appendChild(option);
        }

    var label = document.createElement("label");
    label.innerHTML = "Choose parameter: "
    label.htmlFor = "parameters";

    document.getElementById("dropDownContainer").appendChild(label).appendChild(select);
}*/

function showInputParam() {

    console.log("IM BEING REFEREHNCED");
    var select = document.createElement("select");
    select.name = "Parameter";
    select.id = "params";

    for (const val of inputParamsList) {
        var option = document.createElement("option");
        option.value = val;
        option.text = val.charAt(0).toUpperCase() + val.slice(1);
        select.appendChild(option);
    }

    var label = document.createElement("label");
    label.innerHTML = "Choose parameter: ";
    label.htmlFor = "parameters";

    document.getElementById("dropDownContainer").appendChild(label).appendChild(select);
}