using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Todo.Domain.Handler;
using Todo.Domain.Infra.Context;
using Todo.Domain.Infra.Repository;
using Todo.Domain.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
//cbuilder.Services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("Database"));
builder.Services.AddDbContext<TodoContext>
      (opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

builder.Services.AddTransient<ITodoRepository, TodoRepository>();
builder.Services.AddTransient<TodoHandler, TodoHandler>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt => {
                    opt.Authority = "https://securetoken.google.com/todos-df092";
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                      ValidateIssuer = true,
                      ValidIssuer = "https://securetoken.google.com/todos-df092",
                      ValidateAudience = true,
                      ValidAudience = "todos-df092",
                      ValidateLifetime = true
                    };
                });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(x => 
     x.AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader()
);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
