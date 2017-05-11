import { Component } from '@angular/core'
import { modulesRouting } from '../modules-route';

@Component({
    moduleId: module.id,
    templateUrl: './module-testcase-assignment.html'
})

export class ModuleTestcaseAssignComponent {
    assignTestcase: Array<any>=[
        { title: "Testcase" },
        { title: "Testcase" },
        { title: "Testcase" },
        { title: "Testcase" }
    ];
    search = true;

}
