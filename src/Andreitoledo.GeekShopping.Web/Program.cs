using Andreitoledo.GeekShopping.Web.Services;
using Andreitoledo.GeekShopping.Web.Services.IServices;

namespace Andreitoledo.GeekShopping.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // adicionando o serviço para consumir a API - andrei
            builder.Services.AddHttpClient<IProductService, ProductService>(c =>
            c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:ProductAPI"])
                );

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}