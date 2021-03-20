import { Component, OnInit } from '@angular/core';
import { InventoryService } from 'src/app/services/inventory.service';
import { Item } from 'src/app/models/Item';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-item-details',
  templateUrl: './item-details.component.html',
  styleUrls: ['./item-details.component.css']
})
export class ItemDetailsComponent implements OnInit {

  item: Item;
  itemId: number;
  error: string;
  constructor(private inventoryService: InventoryService,
              private route: ActivatedRoute,
              private router: Router) { }

  ngOnInit(): void {
    this.itemId = +this.route.snapshot.paramMap.get('id');
    this.inventoryService.getItem(this.itemId).subscribe((data => {
      if (data.errorMessage == null){
        this.item = data.item;
      } else{
        this.error = data.errorMessage;
      }
   }));
  }

  onBackButtonClick(): void {
    this.router.navigate(['items']);
  }

  onEditButtonClick(): void {
    this.router.navigate(['create', this.item]);
  }
}
