import { Component } from '@angular/core';

@Component({
    template: `
    <div class="project-list">
        <div class="row">
            <div class="col-md-2">
                <div class="project-list-container" [routerLink]="['/projects']">
                    <img src="http://www.irishplayography.com/attachments/3_85b1ac57-2789-402e-9c82-706a025947e6.JPG" alt="project-logo" class="project-logo" />
                    <h3 class="text-center">Project 1</h3>
                </div>
            </div>
            <div class="col-md-2">
                <div class="project-list-container" [routerLink]="['/projects']">
                    <img src="http://www.irishplayography.com/attachments/3_85b1ac57-2789-402e-9c82-706a025947e6.JPG" alt="project-logo" class="project-logo" />
                    <h3 class="text-center">Project 3</h3>
                </div>
            </div>
            <div class="col-md-2">
                <div class="project-list-container" [routerLink]="['/projects']">
                    <img src="http://www.irishplayography.com/attachments/3_85b1ac57-2789-402e-9c82-706a025947e6.JPG" alt="project-logo" class="project-logo" />
                    <h3 class="text-center">Project 4</h3>
                </div>
            </div>
            <div class="col-md-2">
                <div class="project-list-container" [routerLink]="['/projects']">
                    <img src="http://www.irishplayography.com/attachments/3_85b1ac57-2789-402e-9c82-706a025947e6.JPG" alt="project-logo" class="project-logo" />
                    <h3 class="text-center">Project 5</h3>
                </div>
            </div>
        </div>
    </div>
`
})

export class ProjectListComponent { }