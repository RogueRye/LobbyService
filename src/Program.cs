using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LobbyServiceDb>(options => options.UseInMemoryDatabase("LobbyDb"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

app.MapGet("/lobbies", async (LobbyServiceDb db) =>
    await db.Lobbies.ToListAsync());

app.MapGet("/lobbies/{id}", async (Guid id, LobbyServiceDb db) =>
    await db.Lobbies.FindAsync(id) is Lobby lobby
        ? Results.Ok(lobby)
        : Results.NotFound());

app.MapPost("/users/register", async (RegisterUserRequest request, LobbyServiceDb db) =>
{
    var hasher = new PasswordHasher<User>();

    string hashedPassword = hasher.HashPassword(null, request.Password);

    var user = new User(Guid.NewGuid(), request.Name, hashedPassword, DateTimeOffset.UtcNow);

    db.Users.Add(user);

    await db.SaveChangesAsync();

    return Results.Created($"/users/{user.Id}", user);
});


app.MapPost("/lobbies/create", async (CreateLobbyRequest request, LobbyServiceDb db) =>
{
    var lobby = new Lobby(Guid.NewGuid(), request.Creator, request.Name, "Created");

    db.Lobbies.Add(lobby);

    await db.SaveChangesAsync();

    return Results.Created($"/users/{lobby.Id}", lobby);
});

app.MapPost("/lobbies/join", async (JoinLobbyRequest request, LobbyServiceDb db) =>
{
    var member = new LobbyMember(request.Lobby, request.Player, DateTimeOffset.UtcNow);

    db.LobbyMembers.Add(member);

    await db.SaveChangesAsync();

    return Results.Ok;
});

app.Run();
