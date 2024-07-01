using GestaoDeProjeto.Api.Configuracao;
using GestaoDeProjeto.Aplicacao.Configuracao;
using GestaoDeProjeto.Infra.Repositorio.Configuracao;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.Development.json")
    .Build();


builder.Services.CarregaConexaoComBancoDeDados();


builder.Services.AddControllers().AddNewtonsoftJson(opt =>
    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


builder.Services.InformacaoCabecalhoApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.DependenciasDoValidator();
builder.Services.DependenciasDoEntity();
builder.Services.ConfigureAutoMapperProfile();
builder.Services.AddHttpContextAccessor();



builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer(); //import ção do Swagge es e ações definidos na API.
builder.Services.AddCors(); //permitir um domínio acessem recursos em outro domínio
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies()); //são responsáveis por processar comandos e consultas 


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI(); 

 



app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseAuthentication();
//app.UseMiddleware<MiddlewareHttp>();
app.Run();