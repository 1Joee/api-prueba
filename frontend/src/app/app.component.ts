import { Component } from '@angular/core';
import { LoginComponent } from './pages/login/login.component';
import { UserListComponent } from './components/user-list/user-list.component';

@Component({
  selector: 'app-root',
  imports: [LoginComponent, UserListComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class App {}
