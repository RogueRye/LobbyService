using Microsoft.EntityFrameworkCore;

public record User(Guid Id, string UserName, string PasswordHash, DateTimeOffset CreatedAt);

public record Lobby(Guid Id, Guid Owner, string Name, string Status);

[PrimaryKey(nameof(LobbyId), nameof(UserId))]
public record LobbyMember(Guid LobbyId, Guid UserId, DateTimeOffset JointedAt);

public record ChatMessage(Guid Id, Guid LobbyId, Guid UserId, string Message, DateTimeOffset Timestamp);