public class RegisterUserRequest
{
    public string Name { get; set; }
    public string Password { get; set; }

}

public class CreateLobbyRequest
{
    public Guid Creator { get; set; }

    public string Name { get; set; }
}

public class JoinLobbyRequest
{
    public Guid Lobby { get; set; }
    public Guid Player { get; set; }
}