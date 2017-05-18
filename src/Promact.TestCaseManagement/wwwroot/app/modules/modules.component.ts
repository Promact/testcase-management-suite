import { Component } from '@angular/core';
import { modulesRouting } from './modules-route';
import { Md2Dialog } from 'md2';

@Component({
    moduleId: module.id,
    templateUrl: 'modules.html'
})

export class ModulesComponent {

    open(dialog: Md2Dialog) {
        dialog.open();
    }

    close(dialog: any) {
        dialog.close();
    }

}