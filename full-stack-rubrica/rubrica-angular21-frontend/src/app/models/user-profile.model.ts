export interface UpdateUserRequest
{
    id: string;
    nomeCompleto: string;
    email: string;
    phoneNumber?: string | null;
}