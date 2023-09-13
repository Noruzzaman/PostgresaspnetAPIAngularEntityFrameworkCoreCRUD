
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Furniture } from 'src/app/shared/furniture.model';
import { FurnitureService } from 'src/app/shared/furniture.service';


@Component({
  selector: 'app-furniture-form',
  templateUrl: './furniture-form.component.html',
  styleUrls: ['./furniture-form.component.css']
})
export class FurnitureFormComponent {
  constructor(public furnService: FurnitureService) {

  }

  ngOnInit() {
    this.furnService.getFurnitureType().subscribe(data => {
      this.furnService.listfurnituretype = data;
    });
  }
  submit(form: NgForm) {


    if (this.furnService.furnitureData.furnitureId == 0) {
      this.insertFurniture(form);
    }
    else {
      this.updateFurniture(form);
    }
  }

  insertFurniture(myform: NgForm) {
    this.furnService.saveFurniture().subscribe(d => {

      this.resetForm(myform);
      this.refreshData();
      console.log('save Success');

    });
  }

  updateFurniture(myform: NgForm) {

    this.furnService.updateFurniture().subscribe(d => {

      this.resetForm(myform);
      this.refreshData();
      console.log('Update Success');

    });

  }

  resetForm(myform: NgForm) {
    myform.form.reset();
    this.furnService.furnitureData = new Furniture();
  }

  refreshData() {
    this.furnService.getFurniture().subscribe(res => {

      this.furnService.listfurnitur = res;
    });
  }

}