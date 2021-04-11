import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-trunks',
  templateUrl: './trunks.component.html',
  styleUrls: ['./trunks.component.scss']
})
export class TrunksComponent implements OnInit {

  public trucks: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getTrucks()
  }

  public getTrucks(): void{

    this.http.get('https://localhost:44393/v1/cadTruck/truck/getAll').subscribe(
      response => this.trucks = response,
      error => console.log(error)
    );

    // this.trucks =[{
    //   Id: '220b06ff-97c3-4260-b5f4-9ba6fb02104c',
    //   Description: 'Caminhao 1',
    //   Model: 'EF',
    //   YearOfManufacture: '2021',
    //   ModelYear: '2021',
    //   Color: 'Red',
    //   Image: null
    // }]
  }

}
