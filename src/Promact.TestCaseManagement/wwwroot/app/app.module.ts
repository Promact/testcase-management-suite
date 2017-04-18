import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { appRoutes } from './app.routes';

import { TestCaseModule } from './testcase/testcase.module';
import { DashboardModule } from './dashboard/dashboard.module';

@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        BrowserModule,
        RouterModule.forRoot(appRoutes),
        TestCaseModule,
        DashboardModule
    ],
    providers: [
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }