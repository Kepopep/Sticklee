namespace TODO.API.Requests;

public record CreateUserRequest(    
    string Email,
    string Password,
    string UserName);