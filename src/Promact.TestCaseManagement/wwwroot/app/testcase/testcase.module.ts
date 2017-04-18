import { NgModule } from '@angular/core'

import { CreateTestCaseComponent } from './create-testcase.component'
import { TestCaseListComponent } from './testcase-list.component'
import { ProjectComponent } from './projects.component';
import { testCaseRouting } from './testcase-route';
import { SidebarComponent, TopNavComponent } from '../shared/index';
import { SharedModule } from '../shared/shared.module';

@NgModule({
    imports: [
        SharedModule,
        testCaseRouting
    ],
    declarations: [
        CreateTestCaseComponent,
        TestCaseListComponent,
        ProjectComponent,
        SidebarComponent,
        TopNavComponent
    ],
    providers: [

    ],
    exports: [
        SidebarComponent,
        TopNavComponent
    ]
})

export class TestCaseModule { }