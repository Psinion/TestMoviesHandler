import type { IUserDto } from '../IUserDto';

export interface AuthResponse {
  user: IUserDto;
  token: string;
}
