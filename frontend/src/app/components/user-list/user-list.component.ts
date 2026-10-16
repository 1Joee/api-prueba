import { Component, inject } from '@angular/core';
import { AsyncPipe } from '@angular/common';
import { Observable } from 'rxjs';
import { UserService } from '../../services/user.service';
import { UserModel } from '../../models/UserModel';

@Component({
  selector: 'app-user-list',
  imports: [AsyncPipe],
  templateUrl: './user-list.component.html',
  styleUrl: './user-list.component.css',
})
export class UserListComponent {
  private userService = inject(UserService);

  public users$: Observable<UserModel[]> = this.userService.getUsers();
}
