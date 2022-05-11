function addItem()
{
    var theNum = document.getElementById("theNumber").value;
    var listItem = document.createElement("li");
    listItem.setAttribute('id','dynamicEntries');
    listItem.appendChild(document.createTextNode(theNum));
    var enteredNums = document.getElementById("enteredNums");
    enteredNums.appendChild(listItem);
    centralTendencies();
}

function clearList()
{
    document.getElementById("enteredNums").innerHTML='';
    document.getElementById("mean").innerHTML = '';
    document.getElementById("median").innerHTML = '';
    document.getElementById("mode").innerHTML = '';
}

function getNums()
{
    var listItems = document.getElementById('enteredNums').childNodes;
    var theNumArray = [];
    for( var i = 0; i < listItems.length; ++i )
    {
        var LI = listItems[i];
        theNumArray.push(Number(LI.innerText) || Number(LI.textContent));
    }

    return theNumArray;
}

function centralTendencies(){
    var theNums = getNums();
    theNums.sort((a, b) => a - b)
    
    //mean
    var avg = theNums.reduce((x, y) => +y ? x + +y : x) / theNums.length;
    
    //median
    var median;
    var middle = Math.floor(theNums.length / 2);
    median = theNums.length % 2 !== 0 ? theNums[middle] : (theNums[middle - 1] + theNums[middle]) / 2;

    //mode
    var max = 0;
    var counts = {};
    for (let i = 0; i < theNums.length; i++) {
        counts[theNums[i]] = (counts[theNums[i]] + 1) || 1;
    }
    for (var key in counts) {
        if (counts.hasOwnProperty(key)) {
            if(counts[key] >= max){max=key;}
        }
    }

    document.getElementById("mean").innerHTML = avg;
    document.getElementById("median").innerHTML = median;
    document.getElementById("mode").innerHTML = max;

}