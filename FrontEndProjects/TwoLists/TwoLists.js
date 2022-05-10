
function addItem(){
    var theText = document.getElementById("theText");
    var theNum = document.getElementById("theNumber").value;
    var listItem = document.createElement("li");
    listItem.setAttribute('id','dynamicEntries');
    listItem.appendChild(document.createTextNode(theText.value));

    if(theNum == 1 && theText != "")
    {
        var list1 = document.getElementById("List1");
        list1.appendChild(listItem);
    }

    else if(theNum == 2 && theText != "")
    {
        var list2 = document.getElementById("List2");
        list2.appendChild(listItem);
    }

    else
    {
        alert("empty entry or invalid number");
    }
}

function clearList(){
    var theNum = document.getElementById("theNumber").value;
    
    if(theNum == 1)
    {
        document.getElementById("List1").innerHTML='';
    }
    
    else if(theNum == 2)
    {
        document.getElementById("List2").innerHTML='';
    }
    
    else
    {
        alert("invalid number");
    }

}