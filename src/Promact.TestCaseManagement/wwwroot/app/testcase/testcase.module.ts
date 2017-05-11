import { NgModule } from '@angular/core'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CreateTestCaseComponent } from './create-testcase.component'
import { TestCaseListComponent } from './testcase-list.component'
import { ProjectComponent } from './projects.component';
import { testCaseRouting } from './testcase-route';
import { SharedModule } from '../shared/shared.module';
import { Md2Module } from 'md2';

@NgModule({
    imports: [
        SharedModule,
        testCaseRouting,
        BrowserAnimationsModule,
        Md2Module.forRoot()
    ],
    declarations: [
        CreateTestCaseComponent,
        TestCaseListComponent,
        ProjectComponent
    ],
    providers: [

    ]
})

export class TestCaseModule { }