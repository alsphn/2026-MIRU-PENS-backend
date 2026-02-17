using Microsoft.EntityFrameworkCore;
using MIRU.API.Data;

var builder = WebApplication.CreateBuilder(args);

// DAFTARKAN SERVICE CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173") // Alamat React kamu
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// 1. Add services to the container.
builder.Services.AddControllers();

// Menambahkan Swagger/OpenAPI (Biar muncul UI kotak biru itu)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Menambahkan koneksi ke SQLite (Yang tadi kita buat)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Inisialisasi Database & Seeder
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Terjadi error saat seeding database.");
    }
}

// 2. Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Nyalakan Swagger UI di mode Development
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();