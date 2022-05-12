function addTableItem() {
    var input = document.getElementById('theText');
    var toDoTable = document.getElementById('ToDoTable');
    var nextValue = input.value;
    if (nextValue == '' || nextValue == null) {
        alert('Please enter the to do list item. ');
        return false;
    }
    var newRow = toDoTable.insertRow(-1);
    var newCell = newRow.insertCell(0);
    var newText = document.createTextNode(nextValue);
    newCell.appendChild(newText);
}
function deleteTableItem() {
    var toDoTable = document.getElementById('ToDoTable');
    var input = document.getElementById('theNumber');
    if (Number(input.value) < 1 || Number(input.value) == null || Number(input.value) > toDoTable.rows.length - 1) {
        alert("Please enter a valid value and ensure the table has values. ");
        return false;
    }
    else {
        toDoTable.deleteRow(Number(input.value));
    }
}
