using Microsoft.EntityFrameworkCore;

public class LobbyServiceDb : DbContext
{
    public LobbyServiceDb(DbContextOptions<LobbyServiceDb> options)
    : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Lobby> Lobbies => Set<Lobby>();

    public DbSet<LobbyMember> LobbyMembers => Set<LobbyMember>();

    public DbSet<ChatMessage> ChatMessages => Set<ChatMessage>();

}