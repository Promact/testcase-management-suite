import { Routes, RouterModule } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';


import { ModuleListComponent } from './module-list.component';
import { ModulesComponent } from './modules.component';

const modulesRoutes: Routes = [
    {
        path: 'modules',
        component: ModulesComponent,
        children: [
            { path: '', component: ModuleListComponent }
        ]
    }
];

export const modulesRouting: ModuleWithProviders = RouterModule.forChild(modulesRoutes);