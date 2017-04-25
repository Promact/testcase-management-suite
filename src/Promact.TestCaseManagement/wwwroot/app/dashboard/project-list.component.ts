import { Component } from '@angular/core';

@Component({
    template: `
    <div class="component-header">
    <div class="row">
        <div class="col-md-8">
            <h3 class="m0">Projects</h3>
        </div>
        <div class="col-md-4">
            <div class="sidebar-search">
                <div class="input-group custom-search-form">
                    <input type="text" class="form-control" placeholder="Search...">
                    <span class="input-group-btn">
                        <button class="btn btn-default" type="button">
                            <i class="fa fa-search"></i>
                        </button>
                    </span>
                </div>
            </div>
        </div>
    </div>
</div>
<div class="project-list">
    <div class="row">
        <div class="col-md-3">
            <div class="project-list-container" [routerLink]="['/projects']">
                <h3 class="text-center">Project 1</h3>
                <h5 class="project-detail">Project Description Project Description Project Description Project DescriptionProject Description Project Description Project Description Project Description Project Description Project Description</h5>
            </div>
        </div>
        <div class="col-md-3">
            <div class="project-list-container" [routerLink]="['/projects']">
                <h3 class="text-center">Project 2</h3>
                <h5 class="project-detail">Project Description Project Description Project Description Project DescriptionProject Description Project Description Project Description Project Description Project Description Project Description</h5>
            </div>
        </div>
        <div class="col-md-3">
            <div class="project-list-container" [routerLink]="['/projects']">
                <h3 class="text-center">Project 3</h3>
                <h5 class="project-detail">Project Description</h5>
            </div>
        </div>
        <div class="col-md-3">
            <div class="project-list-container" [routerLink]="['/projects']">
                <h3 class="text-center">Project 4</h3>
                <h5 class="project-detail">Project Description Project Description Project Description</h5>
            </div>
        </div>
        <div class="col-md-3">
            <div class="project-list-container" [routerLink]="['/projects']">
                <h3 class="text-center">Project 5</h3>
                <h5 class="project-detail">Project Description Project Description Project Description</h5>
            </div>
        </div>
    </div>
</div>
`
})

export class ProjectListComponent { }