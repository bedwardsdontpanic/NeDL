export interface toDoItem {
    name: string;
    complete: boolean;
    additionalNotes: string;
    itemNumber: number;
}


function toDoItem(name, complete, additionalNotes, itemNumber) {
    this.name = name;
    this.complete = complete;
    this.additionalNotes = additionalNotes;
    this.itemNumber = itemNumber;
}
