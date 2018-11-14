import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { forEach } from '@angular/router/src/utils/collection';

@Component({
  selector: 'app-clubs',
  templateUrl: './clubs.component.html',
  styleUrls: ['./clubs.component.css']
})
export class ClubsComponent implements OnInit {
  page = {
    title: 'Clubs',
    image: 'assets/clubs.jpg'
  };
  response: any;
  data: any;
  prop: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.http.get('https://localhost:44398/api/clubs')
      .subscribe((response) => {
        this.response = response;
        console.log(JSON.parse(this.response));
      })
  }
}
