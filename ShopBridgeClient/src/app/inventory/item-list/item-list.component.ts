import { Component, OnInit, ViewChild } from '@angular/core';
import { InventoryService } from 'src/app/services/inventory.service';
import {Item } from '../../models/Item';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-item-list',
  templateUrl: './item-list.component.html',
  styleUrls: ['./item-list.component.css']
})
export class ItemListComponent implements OnInit {
  @ViewChild('addItem')
  addItemForm: NgForm;
  addedItem: Item;
  error: string;
  items: Item[];
  isEdited: boolean;
  constructor(
              private inventoryService: InventoryService) {
                this.addedItem = {
                  id: '',
                  name: '',
                  price: '',
                  description: ''
                };
   }

  ngOnInit(): void {
    this.inventoryService.getAllItems().subscribe((data => {
      this.items = data.items;
 }));
  }

  addItem(){
    this.error = '';
    this.inventoryService.addItem(this.addedItem).subscribe(data => {
      if (data.addedItemId !== 0){
        this.addedItem.id = data.addedItemId;
        this.items.push(this.addedItem);
        this.addedItem = {
          id: '',
          name: '',
          price: '',
          description: ''
        };
      } else {
        this.error = data.errorMessage;
      }
    });
  }

  updateItem() {
    this.error = '';
    this.inventoryService.updateItem(this.addedItem).subscribe(data => {
      if (data.errorMessage == null){
        this.addedItem = {
          id: '',
          name: '',
          price: '',
          description: ''
        };
      } else {
        this.error = data.errorMessage;
      }
  });
}

  removeItem(item: Item){
    this.error = '';
    this.inventoryService.deleteItem(item.id).subscribe(data => {
      if (data.errorMessage == null){
        const index = this.items.findIndex(x => x.id === item.id);
        this.items.splice(index, 1);
      } else {
        this.error = data.errorMessage;
      }
    });
  }

  editItem(item: Item){
    this.error = '';
    this.addedItem = item;
    this.isEdited = true;
  }

  isItemListEmpty(): boolean {
    if (this.items == null || this.items.length === 0){
      return true;
    }
    return false;
  }

}
