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

  items: Item[];
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
      }
    });
  }

  removeItem(item: Item){
    this.inventoryService.deleteItem(item.id).subscribe(data => {
      if (data.errorMessage == null){
        const index = this.items.findIndex(x => x.id === item.id);
        this.items.splice(index, 1);
      }
    });
  }

}
