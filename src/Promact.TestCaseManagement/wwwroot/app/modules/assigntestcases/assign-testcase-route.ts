import { Routes, RouterModule } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';

import { ModuleTestcaseAssignComponent } from './module-testcase-assignment.component';


const testCaseRoutes: Routes = [
    {
        path: 'assigntestcases',
        component: ModuleTestcaseAssignComponent,
    }
];

export const testCaseRouting: ModuleWithProviders = RouterModule.forChild(testCaseRoutes);