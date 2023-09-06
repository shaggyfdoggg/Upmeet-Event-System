import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EventModel } from 'src/app/models/event-model';
import { EventService } from 'src/app/services/event.service';

@Component({
  selector: 'app-event-details',
  templateUrl: './event-details.component.html',
  styleUrls: ['./event-details.component.css']
})
export class EventDetailsComponent {
 
EventResult:EventModel = {}  as EventModel

constructor(private _route: ActivatedRoute, private _eventService:EventService){}

ngOnInit(){
const routeParams = this._route.snapshot.paramMap;
let id:number = Number(routeParams.get("id"));
console.log(id);

this._eventService.GetEventById(id).subscribe((response:EventModel) => {
  console.log(response);
  this.EventResult = response;
});
}

}
