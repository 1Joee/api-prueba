import { Component, inject, signal } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { UserService } from '../../services/user.service';
import { UserCreateModel } from '../../models/UserCreateModel';
import { passwordMatchValidator } from '../../validators/password-match.validator';

@Component({
    selector: 'app-user-form',
    imports: [ReactiveFormsModule, RouterLink],
    templateUrl: './user-form.component.html',
    styleUrl: './user-form.component.css',
})
export class UserFormComponent {
    private formBuilder = inject(FormBuilder);
    private userService = inject(UserService);
    private router = inject(Router);

    public errorMessage = signal<string | null>(null);

    public userForm = this.formBuilder.nonNullable.group({
        name: ['', [Validators.required, Validators.maxLength(50)]],
        age: [null as number | null, [Validators.required, Validators.min(1), Validators.max(100)]],
        dni: ['', [Validators.required, Validators.pattern(/^\d{7,8}$/)]],
        role: [0, Validators.required],
        credentials: this.formBuilder.nonNullable.group({
            email: ['', [Validators.required, Validators.email, Validators.maxLength(100)]],
            password: ['', [Validators.required, Validators.minLength(8)]],
            confirmPassword: ['', Validators.required],
        }, { validators: passwordMatchValidator }),
    });

    get name() {
        return this.userForm.controls.name;
    }

    get age() {
        return this.userForm.controls.age;
    }

    get dni() {
        return this.userForm.controls.dni;
    }

    get credentials() {
        return this.userForm.controls.credentials;
    }

    // Devuelve true si el campo es inválido y el usuario ya interactuó con él
    hasError(control: { invalid: boolean; touched: boolean }): boolean {
        return control.invalid && control.touched;
    }

    onSubmit(): void {
        if (this.userForm.invalid) {
            this.userForm.markAllAsTouched();
            return;
        }

        this.errorMessage.set(null);

        const { name, age, dni, role, credentials } = this.userForm.getRawValue();
        const newUser: UserCreateModel = {
            name: name,
            age: age ?? 0,
            dni: dni,
            email: credentials.email,
            password: credentials.password,
            role: Number(role),
        };

        this.userService.createUser(newUser).subscribe({
            next: () => {
                this.router.navigate(['/users']);
            },
            error: (error) => {
                this.errorMessage.set(
                    typeof error.error === 'string'
                        ? error.error
                        : 'No se pudo crear el usuario. Revisá los datos ingresados.'
                );
            },
        });
    }
}
