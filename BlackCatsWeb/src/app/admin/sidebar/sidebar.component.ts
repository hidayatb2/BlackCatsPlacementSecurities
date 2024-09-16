import { Component, ElementRef } from '@angular/core';

@Component({
  selector: 'bcss-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.scss'
})
export class SidebarComponent {
  constructor(private elementRef: ElementRef) { }

  ngAfterViewInit(): void {
    const arrows = this.elementRef.nativeElement.querySelectorAll('.arrow');
    arrows.forEach((arrow: any) => {
      arrow.addEventListener('click', (e: any) => {
        const arrowParent = e.target.parentElement.parentElement; // selecting main parent of arrow
        arrowParent.classList.toggle('showMenu');
      });
    });

    const sidebar = this.elementRef.nativeElement.querySelector('.sidebar');
    const sidebarBtn = this.elementRef.nativeElement.querySelector('.bx-menu');
    console.log(sidebarBtn);
    sidebarBtn.addEventListener('click', () => {
      sidebar.classList.toggle('close');
    });
  }
}
