import { Component, OnInit } from '@angular/core';
import { UserService } from '../../Services/user.service';
import { User } from '../../Interfaces/user';

@Component({
  selector: 'bcss-users',
  templateUrl: './users.component.html',
  styleUrl: './users.component.scss',
})
export class UsersComponent implements OnInit {
  users!: User[];
  constructor(private userService: UserService) {}

  ngOnInit(): void {
    this.getUsers();
  }

  getUsers() {
    this.userService.getUsers().subscribe((res : any) => {
      this.users = res.result;
    })
  }
}
