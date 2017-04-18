import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { appRoutes } from './testcase-route';
import { CreateTestCaseComponent } from './testcase/create-testcase.component'
import { TestCaseListComponent } from './testcase/testcase-list.component'
import { SidebarComponent, TopNavComponent } from './shared/index';

@NgModule({
    declarations: [
        AppComponent,
        CreateTestCaseComponent,
        TestCaseListComponent,
        SidebarComponent,
        TopNavComponent
    ],
    imports: [
        BrowserModule,
        RouterModule.forRoot(appRoutes)
    ],
    providers: [
    ],
    bootstrap: [AppComponent],
    exports: [
        SidebarComponent,
        TopNavComponent
    ]
})
export class AppModule { }