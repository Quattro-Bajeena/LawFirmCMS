using LawFirmCMS.Data;
using LawFirmCMS.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});
builder.Services.AddMemoryCache();

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options
    .UseLazyLoadingProxies()
    .UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<AccountService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.MapRazorPages();

/*app.Map("/pages/{slug}", async context =>
{
	var slug = (string)context.Request.RouteValues["slug"];
	var dbContext = context.RequestServices.GetRequiredService<ApplicationDbContext>();

	var page = await dbContext.CustomPages.FirstOrDefaultAsync(p => p.Title == slug);
	if (page == null)
	{
		context.Response.StatusCode = 404;
		await context.Response.WriteAsync("Page not found");
		return;
	}

	context.Response.ContentType = "text/html";
	//await context.Response.WriteAsync($"<html><body><h1>{page.Title}</h1><p>{page.Content}</p></body></html>");
	await context.Response.WriteAsync($"<html><body><h1>{page.Title}</h1></body></html>");

});*/

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
