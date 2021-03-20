import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemListComponent } from './item-list.component';
import { InventoryService } from 'src/app/services/inventory.service';
import { Observable, Observer } from 'rxjs';
import { Item } from 'src/app/models/Item';
import { NgForm } from '@angular/forms';

const mockData: Item[] = [{
    id: '100',
    name: 'mock',
    description: 'mock',
    price: ''
}];

class MockInventoryService {
    getItem(itemId: string) {
        return Observable.create((observer: Observer<Item>) => {
            observer.next(mockData[0]);
          });
    }

    getAllItems() {
      return Observable.create((observer: Observer<Item[]>) => {
          observer.next(mockData);
        });
  }
  }

describe('ItemListComponent', () => {
  let component: ItemListComponent;
  let fixture: ComponentFixture<ItemListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ItemListComponent, NgForm ],
      providers: [ { provide: InventoryService, useClass: MockInventoryService } ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ItemListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
