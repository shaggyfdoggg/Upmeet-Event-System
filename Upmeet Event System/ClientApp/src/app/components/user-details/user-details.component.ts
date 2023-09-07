import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EventModel } from 'src/app/models/event-model';
import { UserModel } from 'src/app/models/user-model';
import { EventService } from 'src/app/services/event.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.css']
})
export class UserDetailsComponent {
UserResult:UserModel = {}  as UserModel
username:string = ""
//EventResult:EventModel = {}  as EventModel

constructor(private _route: ActivatedRoute, private _eventService:EventService, private _userService:UserService){}


ngOnInit(){
  const routeParams = this._route.snapshot.paramMap;
  this.username = String(routeParams.get("username"));
  console.log(this.username);
  
  this._userService.GetUserByUserName(this.username).subscribe((response:UserModel) => {
    console.log(response);
    this.UserResult = response;
  }
  
  );
  }



}
