function alogrithm1(theText, listItem)
{
    var list1 = document.getElementById("List1");
    theText = theText.toString().toLowerCase();
    let j = theText.length -1;
    
    for( let i = 0 ; i < j/2 ;i++)
    {
        let front = theText[i];
        let back = theText[j-i];
        if(front != back)
        {
            listItem.innerHTML+=": FALSE"
            list1.appendChild(listItem);
            return false;
        }
    }

    listItem.innerHTML+=": TRUE"
    list1.appendChild(listItem);
    return true;
}

function alogrithm2(theText, listItem)
{

    var list2 = document.getElementById("List2");
    theText = theText.toString().toLowerCase();
    var reversed = theText.split( '' ).reverse( ).join( '' );
    if(theText == reversed)
    {
        listItem.innerHTML+=": TRUE"
        list2.appendChild(listItem);
    }
    else
    {
        listItem.innerHTML+=": FALSE"
        list2.appendChild(listItem);
    }
}


function addItem()
{
    var theText = document.getElementById("theText").value;
    var theNum = document.getElementById("theNumber").value;
    var listItem = document.createElement("li");
    listItem.setAttribute('id','dynamicEntries');
    listItem.appendChild(document.createTextNode(theText));
    if(theNum == 1 && theText != "")
    {
        alogrithm1(theText, listItem);
    }
    else if(theNum == 2 && theText != "")
    {
        alogrithm2(theText, listItem);
    }
    else
    {
        alert("empty entry or invalid number");
    }
}

function clearList()
{
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