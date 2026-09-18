import { Component, signal } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { UserService } from '../../services/user.service';
import { LoginModel } from '../../models/LoginModel';

@Component({
  selector: 'app-login',
  imports: [ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {
  public loginForm = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required]),
  });

  public token = signal<string | null>(null);
  public errorMessage = signal<string | null>(null);

  constructor(private userService: UserService) {}

  login(): void {
    this.errorMessage.set(null);
    this.token.set(null);

    const loginModel: LoginModel = {
      email: this.loginForm.value.email ?? '',
      password: this.loginForm.value.password ?? '',
    };

    this.userService.login(loginModel).subscribe({
      next: (response) => {
        this.token.set(response.token);
        localStorage.setItem('token', response.token);
      },
      error: (error) => {
        this.errorMessage.set(
          error.status === 401
            ? 'Email o contraseña incorrectos.'
            : 'Ocurrió un error al iniciar sesión. Intentá nuevamente.'
        );
      },
    });
  }
}
