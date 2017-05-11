import { NgModule } from '@angular/core'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ScenarioListComponent } from './scenario-list.component'
import { ScenarioComponent } from './scenario.component';
import { scenariosRouting } from './scenario-route';
import { SharedModule } from '../shared/shared.module';
import { Md2Module } from 'md2';
import { ScenarioTestcaseAssignComponent } from './assigntestcases/scenario-testcase-assignment.component';

@NgModule({
    imports: [
        SharedModule,
        scenariosRouting,
        BrowserAnimationsModule,
        Md2Module.forRoot()
    ],
    declarations: [
        ScenarioTestcaseAssignComponent,
        ScenarioListComponent,
        ScenarioComponent
    ],
    providers: [

    ]
})

export class ScenariosModule { }