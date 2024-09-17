import { AfterViewInit, Component } from '@angular/core';
import {
  aboutUsData,
  CoursalData,
  AchievmentImagesData,
  ServicesData,
} from '../fakeData';
import { Service } from '../Interface/interface';


@Component({
  selector: 'bcss-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
})
export class HomeComponent implements AfterViewInit {
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
  }

  getAchievmentImagesData() {
    this.AchievmentImages = AchievmentImagesData;
  }
  getServiceData() {
    this.Services = ServicesData;
  }

 
ngAfterViewInit() {
  document.querySelectorAll('a[href^="#"]').forEach(anchor => {
    anchor.addEventListener('click', (e) => { // Changed to an arrow function
      e.preventDefault();

      const targetId = anchor.getAttribute('href'); // Use anchor directly
      if (targetId) { // Check if targetId is not null
        document.querySelector(targetId)?.scrollIntoView({
          behavior: 'smooth'
        });
      }
    });
  });
}

}
