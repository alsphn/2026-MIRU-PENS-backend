using Microsoft.EntityFrameworkCore;
using MIRU.API.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Add services to the container.
builder.Services.AddControllers();

// Menambahkan Swagger/OpenAPI (Biar muncul UI kotak biru itu)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Menambahkan koneksi ke SQLite (Yang tadi kita buat)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// 2. Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Nyalakan Swagger UI di mode Development
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();