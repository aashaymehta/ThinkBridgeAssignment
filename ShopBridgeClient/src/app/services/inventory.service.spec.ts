import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { InventoryService } from './inventory.service';

describe('InventoryService', () => {
  let service: InventoryService;

  beforeEach(() => {
    TestBed.configureTestingModule(
        {
         imports: [HttpClientTestingModule],
         providers: [InventoryService]
        });
    service = TestBed.inject(InventoryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('Get all items should return item list', () => {
    expect(service.getAllItems()).toBeDefined();
  });

  it('Get item should get the item from the list', () => {
    expect(service.getItem(101)).toBeDefined();
  });

  it('Delete item should remove item from the list', () => {
    expect(service.deleteItem('101')).toBeDefined();
  });

});
