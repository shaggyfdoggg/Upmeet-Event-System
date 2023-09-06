import { Component } from '@angular/core';
import { EventService } from 'src/app/services/event.service';
import { EventModel } from 'src/app/models/event-model';

@Component({
  selector: 'app-list-events',
  templateUrl: './list-events.component.html',
  styleUrls: ['./list-events.component.css']
})
export class ListEventsComponent {
    ListEventsResult: EventModel[]=[];

    constructor(private _eventService: EventService) { }

    ngOnInit():void {
      this._eventService.GetEvents().subscribe((response:EventModel[])=> {
        console.log(response);
        this.ListEventsResult = response;
      });
    }

      NewEvent(newEvent:EventModel){
    
        this._eventService.AddEvent(newEvent).subscribe((response: EventModel) =>{
          console.log(response);
          this.ListEventsResult.push(response);
        })
      }


}