using DIego.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace DIego
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<Context>(opt => opt.UseInMemoryDatabase("ContextList"));
			services.AddMvc();
		}

		public void Configure(IApplicationBuilder app)
		{
			app.UseMvc();
		}
    }
}
