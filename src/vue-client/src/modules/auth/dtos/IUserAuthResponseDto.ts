import type { IUserDto } from './IUserDto';

export interface IUserAuthResponseDto {
  user: IUserDto;
  accessToken: string;
}
