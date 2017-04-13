import { Routes } from '@angular/router';
import { CreateTestCaseComponent } from './testcase/create-testcase.component';
import { TestCaseListComponent } from './testcase/testcase-list.component';

export const appRoutes: Routes = [
    { path: 'testcase', component: TestCaseListComponent },
    { path: 'testcase/create', component: CreateTestCaseComponent },
    { path: '', redirectTo: '/testcase', pathMatch: 'full' }
]