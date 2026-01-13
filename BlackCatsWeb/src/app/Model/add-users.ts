import { UserRole } from '../Enums/user-role';
import { UserStatus } from '../Enums/user-status';

export class UserRequest {
  name!: string;
  email!: string;
  contactNo!: string;
  userRole!: UserRole;
}

export class UserResponse {
  id!: string;
  userName!: string;
  email!: string;
  name!: string;
  contactNo!: string;
  userRole!: UserRole;
  userStatus!: UserStatus;
  createdAt!: string;
}

export class UpdateUserRequest {
  id!: string;
  name!: string;
  contactNo!: string;
  userRole!: number;
  userStatus!: number;
}
