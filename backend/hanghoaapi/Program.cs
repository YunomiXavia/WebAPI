using hanghoaapi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<HangHoaContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("GoodDBOnl")));
builder.Services.AddCors();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("DefaultCorsPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyMethod() // For broader method access during development
              .AllowAnyHeader() // For broader header access during development
              .SetIsOriginAllowed(origin => true)
              .AllowCredentials();
    });
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseCors("DefaultCorsPolicy");
//app.UseCors(x => x
//    .AllowAnyMethod()
//   .AllowAnyHeader()
//   .SetIsOriginAllowed(origin => true)
//   .AllowCredentials());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();
