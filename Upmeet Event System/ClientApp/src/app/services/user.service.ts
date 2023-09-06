import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { UserModel } from '../models/user-model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http:HttpClient, @Inject('BASE_URL') private baseUrl: string) { }
  
    GetUsers():Observable<UserModel[]>{
      return this.http.get<UserModel[]>(`${this.baseUrl}api/Favorite`);
    }
    
    AddUser(newUser:UserModel):Observable<UserModel>{
      return this.http.post<UserModel>(`${this.baseUrl}api/Favorite`, newUser);
    }
    
    DeleteUser(id:number){
      return this.http.delete<UserModel>(`${this.baseUrl}api/Favorite/${id}`);
    }
  
    GetEventByUserName(username:string){
      return this.http.get<UserModel[]>(`${this.baseUrl}api/Favorite/${username}`)
    }

}
