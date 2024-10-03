import { Component, OnInit } from '@angular/core';
import { AccountService } from '../Services/account.service';

@Component({
  selector: 'bcss-user',
  templateUrl: './user.component.html',
  styleUrl: './user.component.scss'
})
export class UserComponent implements OnInit {
   constructor(private accountService: AccountService) {}

   ngOnInit(): void {
   }
}
