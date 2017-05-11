import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { MaterialModule } from '@angular/material';
import { AppComponent } from './app.component';
import { appRoutes } from './app.routes';

import { TestCaseModule } from './testcase/testcase.module';
import { DashboardModule } from './dashboard/dashboard.module';
import { ModulesModule } from './modules/modules.module';
import { ScenariosModule } from './scenarios/scenarios.module';
import { SidebarComponent, TopNavComponent } from './shared/index';
import { CoreModule } from './core/core.module';
import { Md2Module } from 'md2';
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
        ScenariosModule,
        CoreModule,
        MaterialModule.forRoot(),
        RouterModule.forRoot(appRoutes),
        Md2Module.forRoot(),
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