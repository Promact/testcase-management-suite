import { Component, OnInit } from '@angular/core';
import { ProjectService } from './project.service';
import { IProject } from './project.model';

@Component({
    moduleId: module.id,
    templateUrl: './project-list.component.html'
})

export class ProjectListComponent implements OnInit {
    projects: IProject[];
    visibleProject: IProject[];
    searchedProject: string;

    constructor(private projectService: ProjectService) {
    }

    ngOnInit() {
        this.getAllProjects();
    }

    filterProject() {
        if (this.searchedProject) {
            this.visibleProject = this.projects.filter(project => {
                return project.name.toLocaleLowerCase().includes(this.searchedProject.toLocaleLowerCase());
            });
        }
        else {
            this.visibleProject = this.projects.slice(0);
        }
    }

    getAllProjects() {
        this.projectService.getProjectList().subscribe(response => {
            this.projects = response;
            this.visibleProject = this.projects.slice(0);
        });
    }
}