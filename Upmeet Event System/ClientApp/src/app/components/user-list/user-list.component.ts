import { Component } from '@angular/core';
import { UserModel } from 'src/app/models/user-model';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent {
  UserListResult: UserModel []=[];

  constructor(private _userService: UserService) { }

  ngOnInit():void {
    console.log('bob')
    this._userService.GetUsersDistinct().subscribe((response:UserModel[])=> {
      // console.log(response);
      this.UserListResult = response;
    });
  }



}
