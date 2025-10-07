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

app.Run();
