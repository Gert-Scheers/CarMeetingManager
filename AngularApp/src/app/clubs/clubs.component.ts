import { Component, OnInit } from '@angular/core';

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

  constructor() { }

  ngOnInit() {
  }

}
