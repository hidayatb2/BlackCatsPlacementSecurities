import { Component } from '@angular/core';

import {
  aboutUsData,

} from '../../fakeData';

@Component({
  selector: 'bcss-nav',
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.scss'
})
export class NavComponent {
  About: any = [];


  ngOnInit(){
    this.getAboutUsData()
  }

  getAboutUsData() {
    this.About = aboutUsData;
    console.log(this.About);
  }
}
