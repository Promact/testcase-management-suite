import { Component } from '@angular/core';
import { Router, RoutesRecognized } from '@angular/router';
import 'rxjs/add/operator/filter';

@Component({
    selector: 'my-app',
    moduleId: module.id,
    templateUrl: 'index.html'
})
export class AppComponent {
    name = 'Angular';
    isDashboard: boolean;

    constructor(private router: Router) {
        router.events.filter(event => event instanceof RoutesRecognized).subscribe((val: RoutesRecognized) => {
            this.isDashboard = val.urlAfterRedirects.indexOf('dashboard') !== -1;
        });
    }
}