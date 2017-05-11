import { Routes, RouterModule } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';

import { CreateTestCaseComponent } from './create-testcase.component';
import { TestCaseListComponent } from './testcase-list.component';
import { ProjectComponent } from './projects.component';

const testCaseRoutes: Routes = [
    {
        path: 'projects',
        component: ProjectComponent,
        children: [
            { path: '', component: TestCaseListComponent },
            { path: 'create', component: CreateTestCaseComponent }
        ]
    }
];

export const testCaseRouting: ModuleWithProviders = RouterModule.forChild(testCaseRoutes);