using MyApi;

var builder = WebApplication.CreateBuilder(args);

// This method gets called by the runtime. Use this method to add services to the container.
// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
builder.Services.AddSingleton<ICounter, Counter>();
builder.Services.AddControllers();

var app = builder.Build();
// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

app.UseRouting();
app.MapControllers();

app.Run();
