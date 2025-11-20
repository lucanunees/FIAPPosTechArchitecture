using ProjetoInicial;
using ProjetoInicial.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region Injeção de dpendência/ DI
builder.Services.AddSingleton<ILifecycleService, LifecycleServices>();
builder.Services.AddSingleton<Lifecycle2Services>();

builder.Services.AddTransient<ILifecycleTransientService, LifecycleTransientService>();
builder.Services.AddTransient<Lifecycle2TransientService>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseLogMiddleware();
app.UseLog2Middleware();

app.UseAuthorization();

app.MapControllers();

app.Run();
