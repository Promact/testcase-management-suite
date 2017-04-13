import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { appRoutes } from './testcase-route';
import { CreateTestCaseComponent } from './testcase/create-testcase.component'
import { TestCaseListComponent } from './testcase/testcase-list.component'

@NgModule({
    declarations: [
        AppComponent,
        CreateTestCaseComponent,
        TestCaseListComponent
    ],
    imports: [
        BrowserModule,
        RouterModule.forRoot(appRoutes)
    ],
    providers: [
    ],
    bootstrap: [AppComponent],
})
export class AppModule { }