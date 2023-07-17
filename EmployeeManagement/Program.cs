using EmployeeManagement.Controllers;
using EmployeeManagement.Utilities;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IStandardHttpClient, StandardHttpClient>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}else
{
    app.UseExceptionHandler("/error");
}
app.UseRouting();
app.UseHttpsRedirection();
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
