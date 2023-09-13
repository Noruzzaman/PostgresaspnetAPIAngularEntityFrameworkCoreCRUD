import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Furniture, FurnitureType } from './furniture.model';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class FurnitureService {

  constructor(private myhttp: HttpClient) { }
  furnitureUrl: string = 'https://localhost:7289/api/Furniture';
  furnitureTypeUrl: string = 'https://localhost:7289/api/FurnitureType';
  listfurnitur: Furniture[] = []; //getting data
  listfurnituretype: FurnitureType[] = [];
  furnitureData: Furniture = new Furniture(); //Post data


  saveFurniture() {
    return this.myhttp.post(this.furnitureUrl, this.furnitureData)
  }

  updateFurniture() {
    return this.myhttp.put(`${this.furnitureUrl}/${this.furnitureData.furnitureId}`, this.furnitureData)
  }

  getFurniture(): Observable<Furniture[]> {

    return this.myhttp.get<Furniture[]>(this.furnitureUrl)
  }

  getFurnitureType(): Observable<FurnitureType[]> {

    return this.myhttp.get<FurnitureType[]>(this.furnitureTypeUrl)
  }

  deleteFurnitutre(furnitureId: number) {
    return this.myhttp.delete(`${this.furnitureUrl}/delete/${furnitureId}`);
  }
}
