using BlogApp.Data;
using BlogApp.Application;
using BlogApp.Data.Seeders;
using BlogApp.MVC;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMVCServices();
builder.Services.AddDataServices(builder.Configuration);
builder.Services.AddApplicationServices();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await context.Database.EnsureCreatedAsync(); // refactor into migration
    await DbSeeder.SeedRolesAsync(context);
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
