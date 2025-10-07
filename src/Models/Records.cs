public record User(Guid Id, string UserName, string PasswordHash, DateTimeOffset CreatedAt);

public record Lobby(Guid Id, Guid Owner, string Status);

public record LobbyMember(Guid LobbyId, Guid UserId, DateTimeOffset JointedAt);

public record ChatMessage(Guid Id, Guid LobbyId, Guid UserId, string Message, DateTimeOffset Timestamp);