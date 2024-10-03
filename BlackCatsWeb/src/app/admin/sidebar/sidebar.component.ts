import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../Services/account.service';

@Component({
  selector: 'bcss-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.scss',
})
export class SidebarComponent implements OnInit {
  currentUser: any;
  constructor(private accountService: AccountService) {
  }

  ngOnInit(): void {
    this.currentUser = this.accountService.getCurrentUser();
  }

  logout() {
    this.accountService.logout();
  }
}
