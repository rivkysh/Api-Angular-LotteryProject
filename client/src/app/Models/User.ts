export interface User {
  id: number;
  name: string;
  userName: string;
  email: string;
  phoneNumber: string;
  password: string;
}
export interface LoginRequest {
    email: string;
    password: string;
}

export interface AuthResponse {
    user: User;
    token: string; 
}
