import { Component, Inject, ViewChild, TemplateRef } from '@angular/core';
import { DOCUMENT } from '@angular/platform-browser';
import { MdDialog, MdDialogRef, MdDialogConfig, MD_DIALOG_DATA } from '@angular/material';
import { Md2Dialog } from 'md2';

@Component({
    moduleId: module.id,
    templateUrl: './module-list.component.html'
})

export class ModuleListComponent {
    numTemplateOpens = 0;
    @ViewChild(TemplateRef) template: TemplateRef<any>;

    constructor(public dialog: MdDialog, @Inject(DOCUMENT) doc: any) {
        // Adding a class to the body if a dialog opens and
        // removing it after all open dialogs are closed
        dialog.afterOpen.subscribe((ref: MdDialogRef<any>) => {
            if (!doc.body.classList.contains('no-scroll')) {
                doc.body.classList.add('no-scroll');
            }
        });
        dialog.afterAllClosed.subscribe(() => {
            doc.body.classList.remove('no-scroll');
        });
    }
    openAddModuleDialog() {
        this.numTemplateOpens++;
        this.dialog.open(this.template);
    }
    closeAddModuleDialog() {
        this.dialog.closeAll();
    }

    newModule = true;

    open(dialog: Md2Dialog) {
        dialog.open();
    }

    close(dialog: any) {
        dialog.close();
    }
    title = "Add New Module";

    moduleList: Array<any> = [
        { name: "Module Name", des: "Module Des..." },
        { name: "Module Name", des: "Module Des..." },
        { name: "Module Name", des: "Module Des..." },
        { name: "Module Name", des: "Module Des..." },
        { name: "Module Name", des: "Module Des..." }
    ];

}