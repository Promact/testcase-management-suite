import { Component } from '@angular/core';
import { Md2Dialog } from 'md2';

@Component({
    moduleId: module.id,
    templateUrl: './create-testcase.component.html'
})

export class CreateTestCaseComponent {
    accordions: Array<any> = [
        { title: "Pre-Conditions", active: true },
        { title: "Steps", active: true },
        { title: "Post-Conditions", active: true }
    ];

    users: Array<any> = [
        { name: "User must be registered", id: 1},
        { name: "User must be registered", id: 42 }
    ];

    addUser = false;
    clicked = false;
    first = true;
    sec = true;
    third = true;

    tooltip: string = 'Add';
    position: string = 'above';
    delay: number = 0;
    
}

