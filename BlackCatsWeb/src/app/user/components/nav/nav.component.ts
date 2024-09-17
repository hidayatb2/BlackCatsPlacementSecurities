import { Component } from '@angular/core';

import {
  aboutUsData,

} from '../../fakeData';
import { AccountService } from '../../../Services/account.services';


@Component({
  selector: 'bcss-nav',
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.scss'
})
export class NavComponent {
  About: any = [];
  constructor(public accountService: AccountService) {}


  ngOnInit(){
    this.getAboutUsData()
  }

  getAboutUsData() {
    this.About = aboutUsData;
  }
}
