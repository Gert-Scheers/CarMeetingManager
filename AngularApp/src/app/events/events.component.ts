import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Event } from '../Models/event';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.css']
})
export class EventsComponent implements OnInit {
  page = {
    title: 'Events',
    image: 'assets/clubs.jpg'
  };

  response: any;
  data: any;
  list: Object[] = [];

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.http.get('https://localhost:44398/api/events')
      .subscribe((response) => {
        this.response = response;

        for (var i = 0; i < this.response.length; i++) {
          let event = new Event();
          event.Name = response[i].name;
          event.Description = response[i].description;
          event.Location = response[i].location;
          event.Capacity = response[i].capacity;
          event.EventTypeId = response[i].eventTypeId;
          this.list.push(event);
        }
      }
      )
  }

}
