function addNewItem() 
{
    let theNewToDo: string = "";
    // place the values in the form into variables
    theNewToDo = document.forms["ToDoForm"]["enterToDo"].value;
    // validate that something was entered as a word
    if (theNewToDo == "") {
      // no word was entered so tell the user
      alert("Please enter a To Do to add");
      return false;
    }
    else
    {
        let tableRef = <HTMLTableElement> document.getElementById("ToDoList");
        var row = tableRef.insertRow(-1);
        row.innerHTML = theNewToDo;
        document.forms["ToDoForm"]["enterToDo"].value = "";
     }
}
function clearoneitem()
{
  let theToDoList = document.getElementById("ToDoList") as HTMLTableElement;
  const inputValue = document.forms["ToDoForm"]["clearItemValue"] as HTMLInputElement;
    if (Number(inputValue.value) == null || Number(inputValue.value) > theToDoList.rows.length) {
        // no number was enter; tell the user
        alert("Please enter the row number of the To Do to remove");
        return false;
      }
       else
      {
        console.log(inputValue.value);
        theToDoList.deleteRow(Number(inputValue.value)-1);
      } 

}

function clearthelist() {
    // clear the table of all rows
    var tableRef = document.getElementById("ToDoList");
    tableRef.innerHTML = " ";
  }