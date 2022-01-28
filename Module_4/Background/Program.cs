using Background.Filters;
using Background.Middleware;
using MyApi;

var builder = WebApplication.CreateBuilder(args);

var cnt = new Counter();
var data = Environment.GetEnvironmentVariable("TEST");

var val = builder.Configuration.GetSection("MijnCounter:Initial").Value;
builder.Configuration.GetSection("MijnCounter").Bind(cnt);
System.Console.WriteLine(cnt.Initial);
System.Console.WriteLine(data);
// Add services to the container.
builder.Services.AddTransient<MyFirstFilterAttribute>();
builder.Services.AddTransient<ICounter, Counter>();

builder.Services.AddControllers(opts=>{
   opts.Filters.Add<MyFirstFilterAttribute>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//app.UseMiddleware<MijnMiddleware>();

app.UseMijn();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

//app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
