using GestaoDeProjeto.Api.Configuracao;
using GestaoDeProjeto.Aplicacao.Configuracao;
using GestaoDeProjeto.Infra.Repositorio.Configuracao;
using MediatR;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.Development.json")
    .Build();


builder.Services.CarregaConexaoComBancoDeDados();


builder.Services.AddControllers().AddNewtonsoftJson(opt =>
    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);




builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Projeto.API",
        Description = "API CRUD para gest�o de projetos",
        TermsOfService = new Uri("https://example.com"),
        Contact = new OpenApiContact
        {
            Name = "Amauri Dall'Oglio",
            Email = "amauri@hotmail.com",
            Url = new Uri("https://github.com/amauridalloglio"),
        },
        License = new OpenApiLicense
        {
            Name = "Informa��es de licen�a",
            Url = new Uri("https://example.com/"),
        }
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.DependenciasDoValidator();
builder.Services.DependenciasDoEntity();
builder.Services.ConfigureAutoMapperProfile();
builder.Services.AddHttpContextAccessor();



builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer(); //import ��o do Swagge es e a��es definidos na API.
builder.Services.AddCors(); //permitir um dom�nio acessem recursos em outro dom�nio
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies()); //s�o respons�veis por processar comandos e consultas 


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI(); //https://localhost:7006/swagger/index.html

////https://localhost:7006/swagger/v1/swagger.json



app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseAuthentication();
//app.UseMiddleware<MiddlewareHttp>();
app.Run();