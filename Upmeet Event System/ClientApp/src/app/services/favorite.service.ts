// import { HttpClient } from '@angular/common/http';
// import { Inject, Injectable } from '@angular/core';
// import { Observable } from 'rxjs';
// import { UserModel } from '../models/user-model';

// @Injectable({
//   providedIn: 'root'
// })
// export class FavoriteService {

//   constructor(private http:HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

//   GetFavorites():Observable<FavoriteModel[]>{
//     return this.http.get<FavoriteModel[]>(`${this.baseUrl}api/Favorite`);
//   }
  
//   AddFavorite(newFavorite:FavoriteModel):Observable<FavoriteModel>{
//     return this.http.post<FavoriteModel>(`${this.baseUrl}api/Favorite`, newFavorite);
//   }
  
//   DeleteFavorite(id:number){
//     return this.http.delete<FavoriteModel>(`${this.baseUrl}api/Favorite/${id}`);
//   }

//   GetEventByUserName(username:string){
//     return this.http.get<FavoriteModel[]>(`${this.baseUrl}api/Favorite/${username}`)
//   }

// }
