using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CartDb;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrdersDb;
using ProductsDb;
using Services.Interfaces;
using Services.Services;

namespace RetailWebsite
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.Name = "Basket";
                options.IdleTimeout = TimeSpan.FromHours(1); //Basket valid for an hour
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddDbContext<OrdersContext>(options => options.UseSqlServer(Configuration.GetConnectionString("OrdersConnection")));
            services.AddDbContext<ProductsContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ProductsConnection")));
            services.AddDbContext<CartContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CartConnection")));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<ICollectionService, CollectionService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ICartService, CartService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IPartOrderingService, PartOrderingService>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "collection page", template: "{controller=CollectionPage}/{action=Index}/{id}");
                routes.MapRoute(name: "buypagepost", template: "{controller=BuyPage}/{action}/{id}");
                routes.MapRoute(name: "buypagepost", template: "{controller=BuyPage}/{action=AddToBasket}/{productId}");
                routes.MapRoute(name: "basketpage", template: "{controller=Checkout}/{action=Index}");
                routes.MapRoute(name: "parts", template: "{controller=Parts}/{action}");
            });
        }
    }
}
