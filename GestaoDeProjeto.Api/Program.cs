using GestaoDeProjeto.Api.Configuracao;
using GestaoDeProjeto.Aplicacao.Configuracao;
using GestaoDeProjeto.Infra.Repositorio.Configuracao;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.Development.json")
    .Build();


builder.Services.CarregaConexaoComBancoDeDados(configuration);

//builder.Services.AddControllers();
builder.Services.AddControllers().AddNewtonsoftJson(opt =>
    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
 

builder.Services.InformacaoCabecalhoApi();
builder.Services.AddEndpointsApiExplorer(); //import ��o do Swagge es e a��es definidos na API.
builder.Services.AddSwaggerGen();


builder.Services.DependenciasDoValidator();
builder.Services.DependenciasDoEntity();
builder.Services.ConfigureAutoMapperProfile();
builder.Services.AddHttpContextAccessor();
 


builder.Services.AddCors(policyBuilder =>
    policyBuilder.AddDefaultPolicy(policy =>
    policy.WithOrigins("*").AllowAnyHeader().AllowAnyHeader().AllowAnyMethod())); //permitir um dom�nio acessem recursos em outro dom�nio


builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies()); //s�o respons�veis por processar comandos e consultas 

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.ConfiguracaoSwagger();

app.UseRouting();
app.UseSwagger();
app.UseCors(c => c.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseAuthentication();
app.UseMiddleware<MiddlewareHttp>();
app.Run();



