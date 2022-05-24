using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using custumcore.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;


namespace custumcore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public static void RegisterRoutes(Microsoft.AspNetCore.Routing.RouteCollection routes)
        {
            routes.RouteAsync(
                nameof:"Default",
                url:"{controller}/{action}/{id}",
                default:new {Controllers="Todo",action="getall",id=UrlParameter.Optional}
                );
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //Here is the Database Connection String
            services.AddDbContext<EmployeeDbContext>(option => option.UseInMemoryDatabase("MyDb");
        }
        void IAuthenticationFilter.OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)  
        {  
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)  
            {  
                filterContext.Result = new RedirectToRouteResult(  
                    new RouteValueDictionary {  
                    { "controller", "Views" },  
                    { "action", "login" } });  
            }  
        }  

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            
        }
    }
}
