using FinanceManager.Application.UseCases.ContaPagar.Create;
using FinanceManager.Application.UseCases.ContaPagar.Update;
using FinanceManager.Application.UseCases.ContaPagar.Delete;
using FinanceManager.Application.UseCases.ContaPagar.GetByUser;

using FinanceManager.Application.UseCases.ContaReceber.Create;
using FinanceManager.Application.UseCases.ContaReceber.GetByUser;
using FinanceManager.Application.UseCases.ContaReceber.Update;
using FinanceManager.Application.UseCases.ContaReceber.Delete;

using FinanceManager.Application.UseCases.CompraCartao.Create;
using FinanceManager.Application.UseCases.CompraCartao.GetByUser;
using FinanceManager.Application.UseCases.CompraCartao.Update;
using FinanceManager.Application.UseCases.CompraCartao.Delete;
using FinanceManager.Application.UseCases.CompraCartao.List;


using FinanceManager.Application.UseCases.Relatorio.GetDespesaPorCategoria;
using FinanceManager.Application.UseCases.Relatorio.GetSaldoMensal;
using FinanceManager.Application.UseCases.Relatorio.Exportar;




using FinanceManager.Domain.Interfaces;
using FinanceManager.Infrastructure.Data;
using FinanceManager.Infrastructure.Repositories;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore.Design;
using System.IO;




var builder = WebApplication.CreateBuilder(args);

// 1. Configurações de JWT via appsettings / .env
var jwtKey = builder.Configuration["Jwt:Key"];
var jwtIssuer = builder.Configuration["Jwt:Issuer"];
var jwtAudience = builder.Configuration["Jwt:Audience"];

// 2. Adiciona DbContext (SQLite)
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// 3. Adiciona Repositórios e Use Cases
builder.Services.AddScoped<IContaPagarRepository, EfContaPagarRepository>();
builder.Services.AddScoped<IContaReceberRepository, EfContaReceberRepository>();
builder.Services.AddScoped<ICompraCartaoRepository, EfCompraCartaoRepository>();


//3.1 ContaPagar
builder.Services.AddScoped<ICreateContaPagarUseCase, CreateContaPagarUseCase>();
builder.Services.AddScoped<IGetContaPagarByUserUseCase, GetContaPagarByUserUseCase>();
builder.Services.AddScoped<IUpdateContaPagarUseCase, UpdateContaPagarUseCase>();
builder.Services.AddScoped<IDeleteContaPagarUseCase, DeleteContaPagarUseCase>();
//3.2 ContaReceber
builder.Services.AddScoped<ICreateContaReceberUseCase, CreateContaReceberUseCase>();
builder.Services.AddScoped<IGetContaReceberByUserUseCase, GetContaReceberByUserUseCase>();
builder.Services.AddScoped<IUpdateContaReceberUseCase, UpdateContaReceberUseCase>();
builder.Services.AddScoped<IDeleteContaReceberUseCase, DeleteContaReceberUseCase>();
//3.3 CompraCartao
builder.Services.AddScoped<ICompraCartaoRepository, EfCompraCartaoRepository>();
builder.Services.AddScoped<IGetComprasCartaoUseCase, GetComprasCartaoUseCase>();
builder.Services.AddScoped<ICreateCompraCartaoUseCase, CreateCompraCartaoUseCase>();
builder.Services.AddScoped<IGetCompraCartaoByUserUseCase, GetCompraCartaoByUserUseCase>();
builder.Services.AddScoped<IUpdateCompraCartaoUseCase, UpdateCompraCartaoUseCase>();
builder.Services.AddScoped<IDeleteCompraCartaoUseCase, DeleteCompraCartaoUseCase>();

//3.4 Relatorio
builder.Services.AddScoped<IRelatorioRepository, EfRelatorioRepository>();     
builder.Services.AddScoped<IGetDespesaPorCategoriaUseCase, GetDespesaPorCategoriaUseCase>();
builder.Services.AddScoped<IGetSaldoMensalUseCase, GetSaldoMensalUseCase>();
builder.Services.AddScoped<IExportarRelatorioUseCase, ExportarRelatorioUseCase>();







// 4. Adiciona Controllers e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "FinanceManager API", Version = "v1" });
});

// 5. Configura autenticação JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = true;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtIssuer,
        ValidAudience = jwtAudience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey!))
    };
});

builder.Services.AddCors(o => o.AddDefaultPolicy(p =>
    p.AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader()));


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

////// 6. Pipeline de requisição
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

// Agora sempre use Swagger:
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    // Ajuste o endpoint se desejar nomear a UI:
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "FinanceManager API v1");
    // Se quiser servir o Swagger UI na raiz ("/") em vez de "/swagger":
    // c.RoutePrefix = string.Empty;
});
app.UseCors();

app.UseHttpsRedirection();

// 7. Autenticação e autorização
app.UseAuthentication();
app.UseAuthorization();

// 8. Mapeia controllers
app.MapControllers();

app.Run();
