import {Component, OnInit} from '@angular/core';
import {IApplicationResponse} from '../../models/application.interfaces';
import {ApplicationService} from '../../services/application.service';
import {IPasswordResponse} from '../../models/password.interfaces';
import {PasswordService} from '../../services/password.service';
import {RouterLink, RouterOutlet} from '@angular/router';

@Component({
  selector: 'app-password-list',
  imports: [RouterOutlet, RouterLink],
  templateUrl: './password-list.component.html',
  styleUrl: './password-list.component.scss'
})
export class PasswordListComponent implements OnInit {
  passwords: IPasswordResponse[] = [];
  isDeleting = false;

  constructor(private readonly passwordService: PasswordService) {
  }

  ngOnInit(): void {
    this.passwordService.getPasswords().subscribe((response) => this.passwords = response);
  }

  deletePassword(id : string): void {
    this.isDeleting = true;
    this.passwordService.deletePassword(id).subscribe(() => {
      this.passwordService.getPasswords().subscribe((response) => {
        this.passwords = response
        this.isDeleting = false;
      });
    });
  }
}
