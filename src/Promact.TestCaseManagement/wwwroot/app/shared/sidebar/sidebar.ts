import { Component } from '@angular/core';
import { Router, RoutesRecognized } from '@angular/router';

@Component({
  moduleId: module.id,
  selector: 'sidebar-cmp',
  templateUrl: 'sidebar.html'
})

export class SidebarComponent {
  subOptionShow: boolean = true;

  constructor(private router: Router) {
    router.events.filter(event => event instanceof RoutesRecognized).subscribe((val: RoutesRecognized) => {
      this.subOptionShow = val.urlAfterRedirects.includes("projects");
    });
  }
}
