import { Component } from '@angular/core'
import { scenariosRouting } from '../scenario-route';

@Component({
    moduleId: module.id,
    templateUrl: './scenario-testcase-assignment.html'
})

export class ScenarioTestcaseAssignComponent {
    assignTestcase: Array<any>=[
        { title: "Testcase" },
        { title: "Testcase" },
        { title: "Testcase" },
        { title: "Testcase" }
    ];

    tooltip = "Add";
    delay: number = 1 * 1000;
    position = "above";
    search = true;
}
