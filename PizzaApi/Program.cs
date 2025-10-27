var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Optional: if HTTPS isn’t configured, you can comment this out to avoid redirect warnings.
// app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();
app.Run();
