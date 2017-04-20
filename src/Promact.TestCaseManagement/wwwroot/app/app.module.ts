import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { MaterialModule, OverlayContainer, FullscreenOverlayContainer } from '@angular/material';
import { AppComponent } from './app.component';
import { appRoutes } from './app.routes';

import { TestCaseModule } from './testcase/testcase.module';
import { DashboardModule } from './dashboard/dashboard.module';
import { ModulesModule } from './modules/modules.module';
import { SidebarComponent, TopNavComponent } from './shared/index';

@NgModule({
    declarations: [
        AppComponent,
        SidebarComponent,
        TopNavComponent
    ],
    imports: [
        BrowserModule,
        RouterModule.forRoot(appRoutes),
        TestCaseModule,
        DashboardModule,
        ModulesModule,
        MaterialModule.forRoot()
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