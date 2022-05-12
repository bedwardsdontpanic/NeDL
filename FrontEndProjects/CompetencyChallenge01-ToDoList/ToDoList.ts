function addTableItem() {
    const input = document.getElementById('theText') as HTMLInputElement
    const toDoTable = document.getElementById('ToDoTable') as HTMLTableElement
    var nextValue = input.value;
    if(nextValue == '' || nextValue == null)
    {
        alert('Please enter the to do list item. ');
        return false;
    }
    let newRow = toDoTable.insertRow(-1);
    let newCell = newRow.insertCell(0);
    let newText = document.createTextNode(nextValue);
    newCell.appendChild(newText);
}


function deleteTableItem(){
    const toDoTable = document.getElementById('ToDoTable') as HTMLTableElement
    const input = document.getElementById('theNumber') as HTMLInputElement
    if(Number(input.value) < 1 || Number(input.value) == null || Number(input.value) > toDoTable.rows.length-1)
    {
        alert("Please enter a valid value and ensure the table has values. ");
        return false; 
    }
    else {
        toDoTable.deleteRow(Number(input.value));
    }

}