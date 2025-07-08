using Microsoft.AspNetCore.Identity;
using AuthService.Data;
using AuthService.Extensions;
using Microsoft.EntityFrameworkCore;
using Duende.IdentityServer.EntityFramework.DbContexts;
using Duende.IdentityServer.EntityFramework.Mappers;
using AuthService.Configuration;
using AuthService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddIdentityServer()
    .AddAspNetIdentity<IdentityUser>()
    .AddConfigurationStore(options =>
    {
        options.ConfigureDbContext = b =>
            b.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                sql => sql.MigrationsAssembly(typeof(Program).Assembly.FullName));
        options.DefaultSchema = "identity.configuration";
    })
    .AddOperationalStore(options =>
    {
        options.ConfigureDbContext = b =>
            b.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                sql => sql.MigrationsAssembly(typeof(Program).Assembly.FullName));
        options.DefaultSchema = "identity.operational";
    })
    .AddDeveloperSigningCredential(); // Временно для разработки

builder.Services.AddSingleton<IEmailSender<IdentityUser>, DummyEmailSender>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddControllers();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddLogging();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseIdentityServer();

app.UseAuthentication();
app.UseAuthorization();

//app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();

    if (!context.ApiScopes.Any())
    {
        foreach (var apiScope in Config.ApiScopes)
            context.ApiScopes.Add(apiScope.ToEntity());
        context.SaveChanges();
    }

    if (!context.ApiResources.Any())
    {
        foreach (var apiResource in Config.ApiResources)
            context.ApiResources.Add(apiResource.ToEntity());
        context.SaveChanges();
    }

    if (!context.IdentityResources.Any())
    {
        foreach (var identityResource in Config.IdentityResources)
            context.IdentityResources.Add(identityResource.ToEntity());
        context.SaveChanges();
    }

    if (!context.Clients.Any())
    {
        foreach (var client in Config.Clients)
            context.Clients.Add(client.ToEntity());
        context.SaveChanges();
    }
}

app.MapIdentityApi<IdentityUser>();
app.Run();

// проверка авторизации и различных эндпоинтов
// разобраться с refresh токенами и остальными эндпоинтами автоматически созданными
// разобраться что пихать в коммит