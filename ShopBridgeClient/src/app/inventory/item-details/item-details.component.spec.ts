import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemDetailsComponent } from './item-details.component';
import { Item } from 'src/app/models/Item';
import { Observable, Observer } from 'rxjs';
import { InventoryService } from 'src/app/services/inventory.service';
import { RouterTestingModule } from '@angular/router/testing';

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
}

describe('EmployeeDetailsComponent', () => {
  let component: ItemDetailsComponent;
  let fixture: ComponentFixture<ItemDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ItemDetailsComponent ],
      imports: [RouterTestingModule],
      providers: [ { provide: InventoryService, useClass: MockInventoryService }]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ItemDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
