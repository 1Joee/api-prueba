import { Component, computed, inject, OnInit, signal } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { UserService } from '../../services/user.service';
import { UserModel } from '../../models/UserModel';

@Component({
    selector: 'app-dashboard',
    imports: [RouterLink],
    templateUrl: './dashboard.component.html',
    styleUrl: './dashboard.component.css',
})
export class DashboardComponent implements OnInit {
    private userService = inject(UserService);
    private router = inject(Router);

    public users = signal<UserModel[]>([]);
    public loading = signal<boolean>(true);
    public errorMessage = signal<string | null>(null);

    public totalUsers = computed(() => this.users().length);
    public totalAdmins = computed(() => this.users().filter(u => u.role === 'Admin').length);
    public totalCommon = computed(() => this.users().filter(u => u.role === 'User').length);
    public lastUsers = computed(() => this.users().slice(-5).reverse());

    ngOnInit(): void {
        this.userService.getUsers().subscribe({
            next: (users) => {
                this.users.set(users);
                this.loading.set(false);
            },
            error: () => {
                this.errorMessage.set('No se pudieron cargar los datos del dashboard.');
                this.loading.set(false);
            },
        });
    }

    logout(): void {
        localStorage.removeItem('token');
        this.router.navigate(['/login']);
    }
}
