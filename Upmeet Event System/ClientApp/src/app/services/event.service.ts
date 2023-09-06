import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EventModel } from '../models/event-model';


@Injectable({
  providedIn: 'root'
})
export class EventService {

  constructor(private http:HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

GetEvents():Observable<EventModel[]>{
  return this.http.get<EventModel[]>(`${this.baseUrl}api/Events`);
}

GetEventById(id:number):Observable<EventModel>{
  return this.http.get<EventModel>(`${this.baseUrl}api/Events/${id}`);
}

AddEvent(newEvent:EventModel):Observable<EventModel>{
  return this.http.post<EventModel>(`${this.baseUrl}api/Events`, newEvent);
}

DeleteEvent(id:number){
  return this.http.delete<EventModel>(`${this.baseUrl}api/Events/${id}`);
}

UpdateEvent(updatedEvent: EventModel): Observable<EventModel>{
  return this.http.put<EventModel>(`$(this.baseUrl)api/Events/${updatedEvent.id}`, updatedEvent);
}

}