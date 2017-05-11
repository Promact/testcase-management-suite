import { Routes, RouterModule } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';


import { ScenarioListComponent } from './scenario-list.component';
import { ScenarioComponent } from './scenario.component';
import { ScenarioTestcaseAssignComponent } from './assigntestcases/scenario-testcase-assignment.component';

const scenarioRoutes: Routes = [
    {
        path: 'scenarios',
        component: ScenarioComponent,
        children: [
            { path: '', component: ScenarioListComponent },
            { path: 'assigntestcases', component: ScenarioTestcaseAssignComponent }
        ]
    }
];

export const scenariosRouting: ModuleWithProviders = RouterModule.forChild(scenarioRoutes);