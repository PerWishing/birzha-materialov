using BirzhaMaterialov.Application;
using BirzhaMaterialov.Persistance;
using BirzhaMaterialov.Persistance.Initializer;
using BirzhaMaterialov.WebApi.Services;
using Hangfire;
using Hangfire.PostgreSql;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddApplication();
builder.Services.AddPersistance(configuration);

var connectionStr = configuration["PgConnection"];

builder.Services.AddHangfire(h =>
                h.UsePostgreSqlStorage(connectionStr));

builder.Services.AddHangfireServer();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<HangfireService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHangfireDashboard("/hangfire");

var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var dbInitializer = scope.ServiceProvider.GetService<IDbInitializer>();
    if (dbInitializer != null)
    {
        dbInitializer.Initialize();
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

RecurringJob.AddOrUpdate<HangfireService>(x => x.SetUpdateDbEveryDay(), Cron.Minutely);

app.Run();
