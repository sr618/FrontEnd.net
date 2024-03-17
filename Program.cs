using proj0.DAL;
using proj0.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor(); // Add this line to register IHttpContextAccessor
builder.Services.AddScoped<CartService>(); // Add this line to register CartService
builder.Services.AddScoped<Dal_User>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
   name: "error",
    pattern: "Error/Error404",
    defaults: new { controller = "Home", action = "Error404" });

app.Run();
