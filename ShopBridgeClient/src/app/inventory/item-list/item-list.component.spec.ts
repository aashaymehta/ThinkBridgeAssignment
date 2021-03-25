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
    price: '111'
},
{
  id: '200',
  name: 'mock',
  description: 'mock',
  price: '111'
},
{
  id: '300',
  name: 'mock',
  description: 'mock',
  price: '111'
}
];

const getAllItemsResponse = {
  items: mockData
};

const deleteItemResponse = {
  errorMessage: null
};

const updateItemResponse = {
  errorMessage: null
};

const addItemResponse = {
  errorMessage: null,
  addedItemId: '501'
};

const addItemErrorResponse = {
  errorMessage: 'Item could not be added'
};

class MockInventoryService {
    getItem(itemId: string) {
        return Observable.create((observer: Observer<Item>) => {
            observer.next(mockData[0]);
          });
    }

    deleteItem(itemId: string) {
      return Observable.create((observer: any) => {
          observer.next(deleteItemResponse);
        });
  }

    getAllItems() {
      return Observable.create((observer: any) => {
          observer.next(getAllItemsResponse);
        });
  }

  addItem() {
    return Observable.create((observer: any) => {
        observer.next(addItemResponse);
      });
}

updateItem() {
  return Observable.create((observer: any) => {
      observer.next(updateItemResponse);
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

  it('should add item in the list', () => {
    component.addedItem = {
      id: '',
      name: 'mock',
      description: 'mock added item',
      price: '300'
    };
    component.addItem();
    const index = component.items.findIndex(x => x.id === addItemResponse.addedItemId);
    expect(index).toBeGreaterThanOrEqual(0);
  });

  it('should list all items', () => {
    expect(component.items.length).toBeGreaterThan(0);
  });

  it('should update item in the list', () => {
    const itemToBeUpdate = Object.assign(mockData[0]);
    component.addedItem = itemToBeUpdate;
    component.addedItem.description = 'updated item description';
    component.updateItem();
    const index = component.items.findIndex(x => x.id === itemToBeUpdate.id);
    expect(component.items[index].description).toBe('updated item description');
  });

  it('should remove the item from the list', () => {
    const removedItemId = mockData[0].id;
    component.removeItem(mockData[0]);
    const index = component.items.findIndex(x => x.id === removedItemId);
    expect(index).toBe(-1);
  });
});

