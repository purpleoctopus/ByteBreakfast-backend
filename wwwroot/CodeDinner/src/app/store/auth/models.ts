export interface User {
  id: string;
  email: string;
  name: string;
}

export interface AuthState {
  accessToken: string | null;
  user: User | null;
  loading: boolean;
  error: string | null;
}
