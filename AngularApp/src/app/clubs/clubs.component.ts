import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Club } from '../Models/club';

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
  list: Object[] = [];

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.http.get('https://localhost:44398/api/clubs')
      .subscribe((response) => {
        this.response = response;

        for (var i = 0; i < this.response.length; i++) {
          let club = new Club();
          club.Name = response[i].name;
          club.Description = response[i].description;
          club.Photo = response[i].photo;
          club.Contact = response[i].contact;
          this.list.push(club);
        }
      }
      )
  }
}
