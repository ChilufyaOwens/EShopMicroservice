var builder = WebApplication.CreateBuilder(args);
{
    builder.AddServiceDefaults();

    // Add services to the container.

    builder.Services.AddControllers();

}

var app = builder.Build();
{
    app.MapDefaultEndpoints();

    app.UseHttpsRedirection();

    app.MapControllers();

    app.Run();
}


