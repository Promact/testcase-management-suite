import { NgModule } from '@angular/core'

import { ModuleListComponent } from './module-list.component'
import { ModulesComponent } from './modules.component';
import { modulesRouting } from './modules-route';
import { SharedModule } from '../shared/shared.module';

@NgModule({
    imports: [
        SharedModule,
        modulesRouting
    ],
    declarations: [
        ModuleListComponent,
        ModulesComponent       
    ],
    providers: [

    ]
})

export class ModulesModule { }