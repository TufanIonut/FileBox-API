using FileBox_API;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMyDependencyGroup();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policyBuilder =>
    {
        policyBuilder.SetIsOriginAllowed(origin =>
        {
            var host = new Uri(origin).Host;
            var ipAddresses = Dns.GetHostAddresses(host);

            var allowedIPs = new List<IPAddress>
            {
                IPAddress.Parse("192.168.170.64"),
                IPAddress.Parse("192.168.1.2")
            };

            return ipAddresses.Any(ip => allowedIPs.Contains(ip));
        })
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});
//cors policy
builder.Services.AddCors(options => options.AddPolicy(name: "FrontendUI",

    policy =>

    {

        policy.WithOrigins("http://localhost:5500").AllowAnyMethod().AllowAnyHeader();
        policy.WithOrigins("http://127.0.0.1:5500").AllowAnyMethod().AllowAnyHeader();

    }

));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("FrontendUI");
app.UseAuthorization();

app.MapControllers();

app.Run();
