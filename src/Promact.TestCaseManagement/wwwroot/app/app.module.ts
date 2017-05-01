import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { MaterialModule } from '@angular/material';
import { AppComponent } from './app.component';
import { appRoutes } from './app.routes';

import { TestCaseModule } from './testcase/testcase.module';
import { DashboardModule } from './dashboard/dashboard.module';
import { ModulesModule } from './modules/modules.module';
import { SidebarComponent, TopNavComponent } from './shared/index';
import { CoreModule } from './core/core.module';
import { NotFoundComponent } from './notfound.component';

@NgModule({
    declarations: [
        AppComponent,
        SidebarComponent,
        TopNavComponent,
        NotFoundComponent
    ],
    imports: [
        BrowserModule,
        TestCaseModule,
        DashboardModule,
        ModulesModule,
        CoreModule,
        MaterialModule.forRoot(),
        RouterModule.forRoot(appRoutes)
    ],
    providers: [

    ],
    exports: [
        SidebarComponent,
        TopNavComponent
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }