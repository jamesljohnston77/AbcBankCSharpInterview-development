using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AbcBankUI.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AbcBankUIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AbcBankUIContext") ?? throw new InvalidOperationException("Connection string 'AbcBankUIContext' not found.")));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHttpClient();

builder.Services.AddSingleton<abc_bank.IAccountData, abc_bank.InMemoryAccountData>();
builder.Services.AddSingleton<abc_bank.ICustomerData, abc_bank.inMemoryCustomerData>();
builder.Services.AddSingleton<abc_bank.ITransactionData, abc_bank.InMemoryTransactionData>();
var app = builder.Build();
//builder.Services.AddSingleton<ITweetStatistics>();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
