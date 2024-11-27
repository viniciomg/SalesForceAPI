using SalesForce.Api;

var builder = WebApplication.CreateBuilder(args);

// Instancia a classe Startup
var startup = new Startup(builder.Configuration);

// Configura os serviços usando a classe Startup
startup.ConfigureServices(builder.Services);

var app = builder.Build();

// Configura o pipeline HTTP usando a classe Startup
startup.Configure(app, app.Environment);

app.Run();
