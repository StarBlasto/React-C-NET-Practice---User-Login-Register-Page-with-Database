using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using BCrypt.Net;

// Setup Backend
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
builder.Services.AddDbContext<UserDbContext>(options => options.UseSqlite("Data Source = user.db"));
var app = builder.Build();

// Adjust CORs
app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

// ---- MAPPED APIs
app.MapPost("/login", async (UserDbContext db, UserAuth request) =>
{
    var user = await db.Users.Where(m => m.Username == request.Username).FirstOrDefaultAsync();

    if (user == null)
    {
        // user does not exist
        return Results.BadRequest(new Response(message: "Invalid username or password", status: false));
    } else
    {
        // user does exists
        if (BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
        {
            // passwords match, login
            return Results.Ok(new Response(message: "Valid password", status: true));
        } else
        {
            // password did not match
            return Results.BadRequest(new Response(message: "Invalid username or password", status: false));
        }
    }
});

app.MapPost("/signup", async (UserDbContext db, UserAuth request) =>
{
    var user = await db.Users.Where(m => m.Username == request.Username).FirstOrDefaultAsync();

    if (user != null)
    {
        // user already exists
        return Results.BadRequest(new Response(message: "User already exists", status: false));
    } else
    {
        // no user exists
        var userInfo = new UserInfo
        {
            Username = request.Username,
            Password = BCrypt.Net.BCrypt.HashPassword(request.Password)
        };
        db.Users.Add(userInfo);
        await db.SaveChangesAsync();
        return Results.Ok(new Response(message: "User created", status: true));
    }
});

// Run App
app.Run();


record Response(string message, bool status);