import { Injectable } from '@angular/core';
import { Item } from '../models/Item';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class InventoryService {

  private items: Item[];
  constructor(private http: HttpClient) {
  }

  public getAllItems(): Observable<any> {
    return this.http.get('https://localhost:44333/api/inventory/all');
  }

  public getItem(id: number): Observable<any> {
    return this.http.get('https://localhost:44333/api/inventory/item/' + id);
  }

  public addItem(item: Item): Observable<any> {
    const body = '{ \"item\": ' + JSON.stringify(item) + '}';
    console.log(body);
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const options = { headers };
    return this.http.post('https://localhost:44333/api/inventory/addItem', body, options);
  }

  public deleteItem(itemId: string): Observable<any> {
    let params = new HttpParams();
    params = params.append('itemId', itemId);
    return this.http.delete('https://localhost:44333/api/inventory/removeItem', {params});
  }

}
