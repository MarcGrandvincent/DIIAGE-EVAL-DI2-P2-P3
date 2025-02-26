import {Component, OnInit} from '@angular/core';
import {ApplicationService} from '../../services/application.service';
import {IApplicationResponse} from '../../models/application.interfaces';
import {RouterLink, RouterOutlet} from '@angular/router';

@Component({
  selector: 'app-application-list',
  imports: [],
  templateUrl: './application-list.component.html',
  styleUrl: './application-list.component.scss'
})
export class ApplicationListComponent implements OnInit {

  applications: IApplicationResponse[] = [];

  constructor(private readonly applicationService: ApplicationService) {
  }

  ngOnInit(): void {
    this.applicationService.getApplications().subscribe((response) => this.applications = response);
  }

}
