using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Net.NetworkInformation;
using WebSurvey_Sales_CRM.Areas.Admin.Reponsitory.Interface;
using WebSurvey_Sales_CRM.Areas.Admin.Reponsitory.Service;
using WebSurvey_Sales_CRM.Data;
using WebSurvey_Sales_CRM.Reponsitory.Interface;
using WebSurvey_Sales_CRM.Reponsitory.Service;
using X.PagedList;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Register connect
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Register DI
	//Register DI Frontend
		builder.Services.AddScoped<IAccount, AccountSevice>();
		builder.Services.AddScoped<IEmployee, EmployeeSevice>();
		builder.Services.AddScoped<IEnterprise, EnterpriseSevice>();
	//Register DI Backend
		builder.Services.AddScoped<ISurvey, SurveyService>();
		builder.Services.AddScoped<INewOption, NewOptionService>();
		builder.Services.AddScoped<IUser, UserService>();
		builder.Services.AddScoped<IDashboard, DashboardService>();

//Configure Session
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(1);
});
//
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
//
app.UseSession();
//
app.UseAuthentication();

app.UseAuthorization();

app.UseRouting();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Account}/{action=Login}");

app.MapControllerRoute(
   name: "area",
   pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");
	
app.Run();
