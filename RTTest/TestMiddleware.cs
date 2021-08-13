using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp {
    public class TestMiddleware {
        private RequestDelegate nextDelegate;

        public TestMiddleware(RequestDelegate next) {
            nextDelegate = next;
        }

        public async Task Invoke(HttpContext context) {
            if (context.Request.Path == "/test") {
                await context.Response.WriteAsync(
                    $"There are 3 CoffeeKing \n");
                await context.Response.WriteAsync(
                    $"There are 4 Ladies\n");
                await context.Response.WriteAsync(
                    $"There are 6 Boys\n");
            } else {
                await nextDelegate(context);
            }
        }
    }
}
