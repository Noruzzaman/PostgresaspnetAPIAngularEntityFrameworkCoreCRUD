import { Component, OnInit } from '@angular/core';
import { Furniture } from '../shared/furniture.model';
import { FurnitureService } from '../shared/furniture.service';
import { DatePipe } from '@angular/common';


@Component({
  selector: 'app-furniture-details',
  templateUrl: './furniture-details.component.html',
  styleUrls: ['./furniture-details.component.css']
})
export class FurnitureDetailsComponent implements OnInit {

  constructor(public furnService: FurnitureService, public datepipe: DatePipe) {

  }

  ngOnInit() {
    this.furnService.getFurniture().subscribe(data => {
      this.furnService.listfurnitur = data;
    });
  }
  populateFurniture(selecetedFurniture: Furniture) {


    this.furnService.furnitureData = selecetedFurniture;
    console.log(this.furnService.furnitureData);


  }

  delete(furnitureId: number) {
    if (confirm('Are you really want to delete this record?' + furnitureId)) {
      this.furnService.deleteFurnitutre(furnitureId).subscribe(data => {
        this.furnService.getFurniture().subscribe(data => {
          this.furnService.listfurnitur = data;

        });
      },
        err => {
        });
    }
  }

}