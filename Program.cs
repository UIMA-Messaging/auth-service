using AuthService.Authentication;
using AuthService.Clients;
using AuthService.TinyMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("read:messages", policy => policy.Requirements.Add(new 
        ScopeRequirements("read:messages", builder.Configuration["Auth0:Domain"])));
});

builder.Services.AddSingleton<IAuthorizationHandler, ScopeHandler>();
builder.Services.AddSingleton(_ => new Auth0Client(
    builder.Configuration["Auth0:Domain"],
    builder.Configuration["Auth0:Audience"],
    builder.Configuration["Auth0:ClientId"], 
    builder.Configuration["Auth0:ClientSecret"]));

builder.Services.AddCors(options =>
{
    options.AddPolicy("",
        builder =>
        {
            builder
                // .WithOrigins("http://localhost:8080")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
        });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = builder.Configuration["Auth0:Domain"];
        options.Audience = builder.Configuration["Auth0:Audience"];
    });

MappingConfigs.Configure();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("");
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
