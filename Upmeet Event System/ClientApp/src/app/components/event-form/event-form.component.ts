import { Component, EventEmitter, Input, Output } from '@angular/core';
import { EventModel } from 'src/app/models/event-model';


@Component({
  selector: 'app-event-form',
  templateUrl: './event-form.component.html',
  styleUrls: ['./event-form.component.css']
})
export class EventFormComponent {
  e:EventModel = {} as EventModel;
  @Output() EventCreated = new EventEmitter<EventModel>();

  CreateEvent(){
    this.EventCreated.emit(this.e);
  }
}
