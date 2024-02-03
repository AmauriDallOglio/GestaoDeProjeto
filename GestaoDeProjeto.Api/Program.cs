using GestaoDeProjeto.Api.Configuracao;
using GestaoDeProjeto.Aplicacao;
using GestaoDeProjeto.Infra.Repositorio.Configuracao;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.Development.json")
    .Build();

builder.Services.CarregaConexaoComBancoDeDados();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseAuthentication();
//app.UseMiddleware<MiddlewareHttp>();
app.Run();