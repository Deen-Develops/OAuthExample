using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)   // This code is to enable google authentication.
    .AddCookie(options =>
    {
        options.LoginPath = "/account/google-login";     // This LoginPath corresponds to the Account controller GoogleLogin()
    })
    .AddGoogle(options =>
    {
        options.ClientId = "511364786551-oqlj61krgr10hr96uio7dr30kqvdvtqu.apps.googleusercontent.com"; 
        options.ClientSecret = "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";
    });

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

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
