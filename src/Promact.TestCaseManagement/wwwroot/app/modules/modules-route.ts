import { Routes, RouterModule } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';


import { ModuleListComponent } from './module-list.component';
import { ModulesComponent } from './modules.component';
import { ModuleTestcaseAssignComponent } from './assigntestcases/module-testcase-assignment.component';

const modulesRoutes: Routes = [
    {
        path: 'modules',
        component: ModulesComponent,
        children: [
            { path: '', component: ModuleListComponent },
            { path: 'assigntestcases', component: ModuleTestcaseAssignComponent }
        ]
    }
];

export const modulesRouting: ModuleWithProviders = RouterModule.forChild(modulesRoutes);