using ApiRest.Context;
using ApiRest.Entities;
using ApiRest.Mapper;
using ApiRest.Repository;
using ApiRest.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MySqlConnector;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


//JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddAuthorization();

// Add DbContext
var connectionString = builder.Configuration.GetConnectionString("SQLServer");
builder.Services.AddDbContext<MyDbContext>(option =>
{
    option.UseLazyLoadingProxies().UseSqlServer(connectionString);
});

// Add Repositories
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<CamareroRepository>();
builder.Services.AddScoped<CocineroRepository>();
builder.Services.AddScoped<GerenteRepository>();
builder.Services.AddScoped<CategoriaRepository>();
builder.Services.AddScoped<ComandaRepository>();
builder.Services.AddScoped<MesaRepository>();
builder.Services.AddScoped<PedidoRepository>();
builder.Services.AddScoped<ProductoRepository>();
builder.Services.AddScoped<ReservaRepository>();

// Add Services
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<CamareroService>();
builder.Services.AddScoped<CocineroService>();
builder.Services.AddScoped<GerenteService>();
builder.Services.AddScoped<CategoriaService>();
builder.Services.AddScoped<ComandaService>();
builder.Services.AddScoped<MesaService>();
builder.Services.AddScoped<PedidoService>();
builder.Services.AddScoped<ProductoService>();
builder.Services.AddScoped<ReservaService>();

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(UsuarioMapper),
    typeof(CamareroMapper),
    typeof(CocineroMapper),
    typeof(GerenteMapper),
    typeof(CategoriaMapper),
    typeof(ComandaMapper),
    typeof(MesaMapper),
    typeof(PedidoMapper),
    typeof(ProductoMapper),
    typeof(ReservaMapper));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//jwt

app.UseAuthorization();

app.UseAuthentication();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();