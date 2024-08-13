import { Component } from '@angular/core';
import {
  aboutUsData,
  CoursalData,
  AchievmentImagesData,
  ServicesData,
} from '../fakeData';

import { About , Service } from '../Interface/interface';

@Component({
  selector: 'bcss-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
})
export class HomeComponent {
  About: any = [];
  Coursal: String[] = [];
  AchievmentImages: String[] = [];
  Services: Service[] = [];
  ngOnInit() {
    this.getCoursalData();
    this.getAboutUsData();
    this.getAchievmentImagesData();
    this.getServiceData();
  }

  getAboutUsData() {
    this.About = aboutUsData;
    // console.log(this.About);
  }

  getCoursalData() {
    this.Coursal = CoursalData;
    // console.log(this.Coursal);
  }

  getAchievmentImagesData() {
    this.AchievmentImages = AchievmentImagesData;
  }
  getServiceData() {
    this.Services = ServicesData;
    // console.log(this.Services);
  }
}
