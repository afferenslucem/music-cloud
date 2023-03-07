using MusicCloud.Server.DataStorage;
using MusicCloud.Server.FileStorage;
using MusicCloud.Server.Music;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
    options.AddPolicy(name: "CORS",
        policyBuilder =>
        {
            policyBuilder.AllowCredentials();
            policyBuilder.AllowAnyHeader();
            policyBuilder.AllowAnyMethod();
        })
);

builder.Services.AddScoped<IMusicManager, MusicManager>();
builder.Services.AddScoped<IFileStorage, FileStorage>();
builder.Services.AddScoped<IMusicStorage, MusicStorage>();


var app = builder.Build();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
