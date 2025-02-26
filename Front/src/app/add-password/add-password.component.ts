import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators} from '@angular/forms';
import {ApplicationType, IApplicationResponse} from '../../models/application.interfaces';
import {BehaviorSubject, Observable} from 'rxjs';
import {ApplicationService} from '../../services/application.service';
import {CommonModule} from '@angular/common';
import {PasswordService} from '../../services/password.service';

@Component({
  selector: 'app-add-password',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './add-password.component.html',
  standalone: true,
  styleUrl: './add-password.component.scss'
})
export class AddPasswordComponent implements OnInit{
  accountForm: FormGroup;
  applications: IApplicationResponse[] = []
  filteredApplications: IApplicationResponse[] = [];
  isCreating = false;

  constructor(private readonly fb: FormBuilder, private readonly applicationService: ApplicationService,
              private readonly passwordService: PasswordService) {
    this.accountForm = this.fb.group({
      accountName: ['', Validators.required],
      applicationType: ['', Validators.required],
      application: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  ngOnInit(): void {
    this.applicationService.getApplications().subscribe((response) => {
      this.filteredApplications = response;
      this.applications = response;
    });
  }

  filterApplications(type: ApplicationType): void {
      this.filteredApplications = this.applications.filter(app => app.applicationType === type);
  }

  onSubmit(): void {
    this.isCreating = true;
    if (this.accountForm.valid) {
      const accountName = this.accountForm.get('accountName')?.value;
      const application = this.accountForm.get('application')?.value;
      const password = this.accountForm.get('password')?.value;

      this.passwordService.createPassword(accountName,password, application).subscribe(() => {
        this.isCreating = false;
      })
    }
    this.isCreating = false;
  }
}
