import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Event } from '../models/event';

@Injectable({
  providedIn: 'root'
})
export class EventService {

  constructor(private http:HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

GetEvents():Observable<Event[]>{
  return this.http.get<Event[]>(`${this.baseUrl}api/Event`);
}

GetEventById(id:number):Observable<Event>{
  return this.http.get<Event>(`${this.baseUrl}api/Event/${id}`);
}

AddEvent(newEvent:Event):Observable<Event>{
  return this.http.post<Event>(`${this.baseUrl}api/Event`, newEvent);
}

DeleteEvent(id:number){
  return this.http.delete<Event>(`${this.baseUrl}api/Event/${id}`);
}

UpdateEvent(updatedEvent: Event): Observable<Event>{
  return this.http.put<Event>(`$(this.baseUrl)api/Order/${updatedEvent.id}`, updatedEvent);
}
}




