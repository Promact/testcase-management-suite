import { NgModule } from '@angular/core'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ModuleListComponent } from './module-list.component'
import { ModulesComponent } from './modules.component';
import { modulesRouting } from './modules-route';
import { SharedModule } from '../shared/shared.module';
import { Md2Module } from 'md2';
import { ModuleTestcaseAssignComponent } from './assigntestcases/module-testcase-assignment.component';

@NgModule({
    imports: [
        SharedModule,
        BrowserAnimationsModule,
        modulesRouting,
        Md2Module.forRoot()
    ],
    declarations: [
        ModuleListComponent,
        ModulesComponent,
        ModuleTestcaseAssignComponent
    ],
    providers: [

    ]
})

export class ModulesModule { }