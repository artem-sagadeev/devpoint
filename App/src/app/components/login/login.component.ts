import { Component, OnInit } from '@angular/core';
import { Errors } from '../../models/errors';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../../services/user.service';
import { LoginCredentials } from '../../models/login-credentials';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  errors: Errors = { errors: {} };
  authForm: FormGroup;
  isSubmitting = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private userService: UserService,
    private fb: FormBuilder,
  ) {
    this.authForm = this.fb.group({
      login: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  ngOnInit(): void {}

  submitForm() {
    this.isSubmitting = true;
    this.errors = { errors: {} };

    const credentials: LoginCredentials = this.authForm.value;
    this.userService.attemptAuth(credentials).subscribe(
      (data) => this.router.navigateByUrl('/'),
      (err) => {
        this.errors = err;
        this.isSubmitting = false;
      },
    );
  }
}
