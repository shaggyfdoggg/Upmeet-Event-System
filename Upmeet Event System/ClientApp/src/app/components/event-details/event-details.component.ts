import { Component, EventEmitter, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EventModel } from 'src/app/models/event-model';
import { UserModel } from 'src/app/models/user-model';
import { EventService } from 'src/app/services/event.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-event-details',
  templateUrl: './event-details.component.html',
  styleUrls: ['./event-details.component.css']
})
export class EventDetailsComponent {

EventResult:EventModel = {}  as EventModel

constructor(private _route: ActivatedRoute, private _eventService:EventService, private _userService:UserService){}

ngOnInit(){
const routeParams = this._route.snapshot.paramMap;
let id:number = Number(routeParams.get("id"));
console.log(id);

this._eventService.GetEventById(id).subscribe((response:EventModel) => {
  console.log(response);
  this.EventResult = response;
});
}

//Add to user favorites
f:UserModel = {} as UserModel
@Output() EventFavorited = new EventEmitter<UserModel>();

AddEventTOFavorites(){
  this.f.eventID=this.EventResult.id
  this.EventFavorited.emit(this.f);
}

}
