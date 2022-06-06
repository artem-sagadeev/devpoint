import { Component, OnInit } from '@angular/core';
import { Errors } from '../../models/errors';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../../services/user.service';
import { LoginCredentials } from '../../models/login-credentials';
import { CustomValidationService } from '../../services/custom-validation.service';
import { RegisterDto } from '../../models/register-dto';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  errors: Errors = { errors: {} };
  registerForm: FormGroup;
  isSubmitting = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private userService: UserService,
    private fb: FormBuilder,
    private customValidator: CustomValidationService,
  ) {
    this.registerForm = this.fb.group(
      {
        login: ['', Validators.required],
        email: ['', Validators.required],
        password: [
          '',
          Validators.compose([
            Validators.required,
            this.customValidator.patternValidator(),
          ]),
        ],
        confirmPassword: ['', [Validators.required]],
      },
      {
        validators: this.customValidator.MatchPassword(
          'password',
          'confirmPassword',
        ),
      },
    );
  }

  get registerFormControl() {
    return this.registerForm.controls;
  }

  hasError(control: string, error: string): boolean {
    return (
      (this.registerFormControl[control].touched || this.isSubmitting) &&
      this.registerFormControl[control].errors?.[error]
    );
  }

  hasErrors(control: string): boolean {
    return (
      (this.registerFormControl[control].touched || this.isSubmitting) &&
      !!this.registerFormControl[control].errors
    );
  }

  ngOnInit(): void {}

  submitForm() {
    this.isSubmitting = true;
    this.errors = { errors: {} };

    const credentials: RegisterDto = {
      login: this.registerForm.value.login,
      email: this.registerForm.value.email,
      password: this.registerForm.value.password,
    };

    this.userService.attemptRegister(credentials).subscribe(
      (data) => this.router.navigateByUrl('/profile'),
      (err) => {
        this.errors = err;
        this.isSubmitting = false;
      },
    );
  }
}
