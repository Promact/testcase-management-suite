import { NgModule } from '@angular/core';

import { dashboardRouting } from './dashboard-route';
import { ProjectListComponent } from './project-list.component';
import { DashboardComponent } from './dashboard.component';
import { SharedModule } from '../shared/shared.module';
import { ProjectService } from './project.service';

@NgModule({
    imports: [
        SharedModule,
        dashboardRouting
    ],
    declarations: [ProjectListComponent, DashboardComponent],
    providers: [
        ProjectService
    ]
})

export class DashboardModule { }