using DesignPatternsWorkshop.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.))
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("WebDesignPatternsWorkshopPolicy");
app.UseHttpsRedirection();

app.Run();