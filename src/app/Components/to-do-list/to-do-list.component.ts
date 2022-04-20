import { Component, OnInit } from '@angular/core';
import { toDoItem } from 'src/app/Objects/toDoItem';

// Drag and drop? Delete Item? Editable Table?

@Component({
  selector: 'app-to-do-list',
  templateUrl: './to-do-list.component.html',
  styleUrls: ['./to-do-list.component.css']
})
export class ToDoListComponent implements OnInit {

  itemList: toDoItem[];

  constructor() { }

  ngOnInit(): void {
  this.itemList = [];
  let fakeItem: toDoItem = {
      complete: false,
      name: 'fake',
      additionalNotes: 'xxxx',
      itemNumber: 1
    };


  this.itemList.push(fakeItem);
  }


}
