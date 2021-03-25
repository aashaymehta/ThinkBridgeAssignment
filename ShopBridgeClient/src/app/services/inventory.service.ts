import { Injectable } from '@angular/core';
import { Item } from '../models/Item';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable()
export class InventoryService {

  private baseUrl: string;
  constructor(private http: HttpClient) {
    this.baseUrl = environment.baseUrl;
  }

  public getAllItems(): Observable<any> {
    return this.http.get(this.baseUrl + '/all');
  }

  public getItem(id: number): Observable<any> {
    return this.http.get(this.baseUrl + '/item/' + id);
  }

  public addItem(item: Item): Observable<any> {
    const body = '{ \"item\": ' + JSON.stringify(item) + '}';
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const options = { headers };
    return this.http.post(this.baseUrl + '/addItem', body, options);
  }

  public updateItem(item: Item): Observable<any> {
    const body = '{ \"item\": ' + JSON.stringify(item) + '}';
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const options = { headers };
    return this.http.post(this.baseUrl + '/updateItem', body, options);
  }

  public deleteItem(itemId: string): Observable<any> {
    let params = new HttpParams();
    params = params.append('itemId', itemId);
    return this.http.delete(this.baseUrl + '/removeItem', {params});
  }

}
